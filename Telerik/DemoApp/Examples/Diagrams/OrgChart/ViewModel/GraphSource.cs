using Telerik.Windows.Controls.Diagrams.Extensions.ViewModels;
using System.Linq;
using System;
using System.Windows;

namespace Telerik.Windows.Examples.Diagrams.OrgChart
{
	public class GraphSource :  ObservableGraphSourceBase<OrgTeamViewModel, Link>
	{
		public void PopulateGraphSource(OrgTeamViewModel team)
		{
            this.AddNode(team);
            this.SubscribeForTeamEvents(team);
            foreach (OrgTeamViewModel subNode in team.Children)
			{
                Link link = new Link(team, subNode);
                this.PopulateGraphSource(subNode);
				this.AddLink(link);
			}
		}

        private void SubscribeForTeamEvents(OrgTeamViewModel team)
        {
            team.TeamOrMemberSelecting += OnTeamOrMemberSelecting;
            team.DeleteTeamRequested += OnDeleteTeamRequested;
            team.AddSubTeamRequested += OnAddSubTeamRequested;
            team.IsExpandedChanged += OnTeamIsExpandedChanged;
        }

        private void OnTeamIsExpandedChanged(object sender, EventArgs e)
        {
            OrgTeamViewModel team = sender as OrgTeamViewModel;
            if (sender != null)
            {
                this.ToggleChildrenVisibility(team, team.IsExpanded);
            }
        }

        internal void ToggleChildrenVisibility(HierarchicalNodeViewModel node, bool isExpanded)
        {
            var visibility = isExpanded ? Visibility.Visible : Visibility.Collapsed;

            foreach (OrgTeamViewModel subNode in node.Children)
            {
                subNode.Visibility = visibility;
                subNode.IsSelected = false;

                if (subNode.IsExpanded)
                {
                    this.ToggleChildrenVisibility(subNode, isExpanded);
                }
            }
            this.InternalLinks.Where(link => link.Source == node).ToList()
                        .ForEach(link =>
                        {
                            link.Visibility = visibility;
                            link.IsSelected = false;
                        });
        }

        private void OnAddSubTeamRequested(object sender, EventArgs e)
        {
            var parentTeam = sender as OrgTeamViewModel;
            OrgTeamViewModel newTeam = new OrgTeamViewModel()
            {
                Name = "New " +parentTeam.Branch.ToString() + " Team",
                Branch = parentTeam.Branch,       
                AreMembersVisible = true,
            };
            newTeam.Path = parentTeam == null ? newTeam.Name : parentTeam.Path + "|" + newTeam.Name;	
            this.SubscribeForTeamEvents(newTeam);
            if (!parentTeam.IsExpanded)
                parentTeam.IsExpanded = true;

            this.AddNode(newTeam);
            parentTeam.Children.Add(newTeam);
            Link link = new Link(parentTeam, newTeam);
            this.AddLink(link);           
        }       

        private void OnDeleteTeamRequested(object sender, System.EventArgs e)
        {
            var linkToDelete = this.InternalLinks.Where(x => x.Target == sender).FirstOrDefault();
            if (linkToDelete != null)
            {
                this.RemoveLink(linkToDelete);
            }
            this.RemoveItem(sender as OrgTeamViewModel);   
        }

        private void OnTeamOrMemberSelecting(object sender, System.EventArgs e)
        {
            this.InternalItems.ToList().ForEach(team => team.IsSelected = false);
            foreach (var item in this.InternalItems)
            {
                item.TeamMembers.ToList().ForEach(member => member.IsSelected = false);
            }
        }
	}
}
