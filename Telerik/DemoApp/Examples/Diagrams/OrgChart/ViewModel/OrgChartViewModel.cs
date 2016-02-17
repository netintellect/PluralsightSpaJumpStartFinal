using System;
using System.Collections.ObjectModel;
using System.Linq;
using System.Windows;
using System.Windows.Input;
using System.Xml.Linq;
using Telerik.Windows.Controls;
using Telerik.Windows.Controls.Diagrams.Extensions.ViewModels;
using Telerik.Windows.Diagrams.Core;
using Telerik.Windows.Examples.Diagrams.OrgChart.CustomControls;
using Telerik.Windows.Examples.Diagrams.OrgChart.ViewModel;

namespace Telerik.Windows.Examples.Diagrams.OrgChart
{
	public class OrgChartViewModel : ViewModelBase
	{
		private GraphSource graphSource;
		private TreeLayoutType currentTreeLayoutType;
		private bool shouldLayoutAfterExpandCollapse;
		private TreeLayoutViewModel childTreeLayoutViewModel;
		private readonly OrgTreeRouter router = new OrgTreeRouter();
		private double zoomFactor;

		public OrgChartViewModel()
		{
			this.GraphSource = new GraphSource();
			this.HierarchicalDataSource = new ObservableCollection<OrgTeamViewModel>();
			this.PopulateWithData();
			this.PopulateGraphSources();
            this.SetInitialView();
			this.ChildRouterViewModel = new OrgRouterViewModel(this.router);
			this.ChildTreeLayoutViewModel = new TreeLayoutViewModel();
			this.CurrentTreeLayoutType = TreeLayoutType.TreeDown;
			this.ShouldLayoutAfterExpandCollapse = true;
			this.ZoomFactor = 1.0d;
		}

		public event EventHandler<VisibilityChangedEventArgs> NodeVisibilityChanged;
		public event EventHandler CurrentLayoutTypeChanged;
		public event EventHandler CurrentLayoutTypeSettingsChanged;
		public event EventHandler<TeamExpandCollapseChangeEventArgs> ChildrenIsExpandedChanged;
        public event EventHandler<TeamExpandCollapseChangeEventArgs> TeamMembersVisibilityChanged;

		public double ZoomFactor
		{
			get { return this.zoomFactor; }
			set
			{
				if (this.zoomFactor != value)
				{
					this.zoomFactor = value;
					this.OnPropertyChanged("ZoomFactor");
				}
			}
		}

		public TreeLayoutType CurrentTreeLayoutType
		{
			get { return currentTreeLayoutType; }
			set
			{
				this.currentTreeLayoutType = value;
				this.ChildTreeLayoutViewModel.CurrentTreeLayoutType = value;
				this.ChildRouterViewModel.CurrentTreeLayoutType = value;
				this.OnPropertyChanged("CurrentTreeLayoutType");
				this.OnCurrentLayoutTypeChanged();
			}
		}

		public GraphSource GraphSource
		{
			get
			{
				return this.graphSource;
			}
			set
			{
				if (this.graphSource != value)
				{
					this.graphSource = value;
					this.OnPropertyChanged("GraphSource");
				}
			}
		}

		public ObservableCollection<OrgTeamViewModel> HierarchicalDataSource { get; private set; }

		public OrgTreeRouter Router { get { return this.router; } }

		public TreeLayoutViewModel ChildTreeLayoutViewModel
		{
			get { return this.childTreeLayoutViewModel; }
			protected set
			{
				if (this.childTreeLayoutViewModel != value)
				{
					this.childTreeLayoutViewModel = value;
					this.OnPropertyChanged("ChildTreeLayoutViewModel");
				}
			}
		}

		public OrgRouterViewModel ChildRouterViewModel { get; protected set; }

		public bool ShouldLayoutAfterExpandCollapse
		{
			get { return this.shouldLayoutAfterExpandCollapse; }
			set
			{
				if (this.shouldLayoutAfterExpandCollapse != value)
				{
					this.shouldLayoutAfterExpandCollapse = value;
					this.OnPropertyChanged("ShouldLayoutAfterExpandCollapse");
				}
			}
		}

		public void PopulateGraphSources()
		{
			foreach (var item in this.HierarchicalDataSource)
			{
				this.GraphSource.PopulateGraphSource(item);
			}
		}

        internal void OpenDropMembersDialog(OrgTeamViewModel team, OrgTeamMemberViewModel member)
        {
            DropDialogViewModel dropModel = new DropDialogViewModel()
            {
                Header = string.Format("Drop in {0} team", team.Name),
                DropMessage = string.Format("Are you sure you want to drop {0} in {1} team?", member.Name, team.Name)
            };
            DropDialog dialog = new DropDialog();
            dialog.DataContext =  dropModel;
            dropModel.OkCommand = new DelegateCommand(x =>
                {
                    member.Team.TeamMembers.Remove(member);
                    member.Team = team;
                    team.TeamMembers.Add(member);
                    if (this.TeamMembersVisibilityChanged != null)
                    {
                        TeamExpandCollapseChangeEventArgs args = new TeamExpandCollapseChangeEventArgs(team);
                        this.TeamMembersVisibilityChanged(this, args);
                    }
                    dialog.Close();
                });
            dropModel.CancelCommand = new DelegateCommand(x => dialog.Close());
            dialog.ShowDialog();
        }

        private void PopulateWithData()
        {
            var stream = Application.GetResourceStream(new Uri("/Diagrams;component/OrgChart/XmlSource/Organization.xml", UriKind.RelativeOrAbsolute));
            XElement dataXml = XElement.Load(stream.Stream);

            foreach (XElement element in dataXml.Elements("Node"))
            {
                OrgTeamViewModel node = this.CreateNode(element, null);   
                node.Children.AddRange(this.GetSubNodes(element, node));
                this.HierarchicalDataSource.Add(node);
            }
        }

        private ObservableCollection<OrgTeamMemberViewModel> GetTeamMembers(XContainer element, OrgTeamViewModel team)
        {
            var members = new ObservableCollection<OrgTeamMemberViewModel>();
            foreach (var xmlNodeMember in element.Elements("NodeMember"))
            {
                OrgTeamMemberViewModel member = new OrgTeamMemberViewModel();
                member.Team = team;
                member.Name = xmlNodeMember.Attribute("Name").Value;
                member.ImagePath = string.Format("../../Images/Diagrams/OrgChart/{0}.png", member.Name); 
                member.Position = xmlNodeMember.Attribute("Position").Value;
                members.Add(member);
            }
            return members;
        }

		private ObservableCollection<HierarchicalNodeViewModel> GetSubNodes(XContainer element, OrgTeamViewModel parent)
		{
			var nodes = new ObservableCollection<HierarchicalNodeViewModel>();
			foreach (var subElement in element.Elements("Node"))
			{
				OrgTeamViewModel node = this.CreateNode(subElement, parent);
				node.Children.AddRange(this.GetSubNodes(subElement, node));
				nodes.Add(node);
			}
			return nodes;
		}

		private OrgTeamViewModel CreateNode(XElement element, OrgTeamViewModel parentNode)
		{
			OrgTeamViewModel orgTeam = new OrgTeamViewModel()
			{
				Name = element.Attribute("Name").Value,
			};
#if WPF
            orgTeam.Branch = (Branch)Enum.Parse(typeof(Branch), element.Attribute("Branch").Value);
#else
            orgTeam.Branch = (Branch)Enum.Parse(typeof(Branch), element.Attribute("Branch").Value, false);
#endif
            orgTeam.TeamMembers.AddRange(this.GetTeamMembers(element, orgTeam));
            orgTeam.Path = parentNode == null ? orgTeam.Name : parentNode.Path + "|" + orgTeam.Name;		
            orgTeam.PropertyChanged += this.OnNodePropertyChanged;
            orgTeam.IsExpandedChanged += this.OnNodeIsExpandedChanged;
            orgTeam.MembersVisibilityChanged += this.OrgTeamMembersVisibilityChanged;
            return orgTeam;
		}

        private void OrgTeamMembersVisibilityChanged(object sender, TeamExpandCollapseChangeEventArgs args)
        {
            if (this.TeamMembersVisibilityChanged != null)
            {
                this.TeamMembersVisibilityChanged(this, args);
            }
        }

		private void OnNodeIsExpandedChanged(object sender, EventArgs e)
		{
			var team = sender as OrgTeamViewModel;
			if (team != null)
			{
				this.graphSource.ToggleChildrenVisibility(team, team.IsExpanded);
				if (this.ChildrenIsExpandedChanged != null)
				{
                    TeamExpandCollapseChangeEventArgs args = new TeamExpandCollapseChangeEventArgs(team);
                    this.ChildrenIsExpandedChanged(this, args);
				}
			}
		}		

		private void OnNodePropertyChanged(object sender, System.ComponentModel.PropertyChangedEventArgs e)
		{
			if (e.PropertyName == "Visibility")
			{
				if (this.NodeVisibilityChanged != null)
				{
					this.NodeVisibilityChanged(sender, new VisibilityChangedEventArgs((sender as OrgTeamViewModel).Visibility == Visibility.Visible));
				}
			}
		}		

		private void OnCurrentLayoutTypeChanged()
		{
			if (this.CurrentLayoutTypeChanged != null)
			{
				this.CurrentLayoutTypeChanged(this, EventArgs.Empty);
			}
		}

        internal void FindAndRemove(OrgTeamViewModel team)
        {
            if (team == this.HierarchicalDataSource[0])
            {
                this.HierarchicalDataSource.Clear();
            }
            else
            {
                this.FindAndRemoveRecursive(this.HierarchicalDataSource[0], team);
            }
        }
        private void FindAndRemoveRecursive(OrgTeamViewModel parent, OrgTeamViewModel toDelete)
        {
            foreach (var item in parent.Children)
            {
                if (item == toDelete)
                {
                    parent.Children.Remove(item);
                    parent.DeleteTeamCommand.InvalidateCanExecute();
                    return;
                }
                this.FindAndRemoveRecursive(item as OrgTeamViewModel, toDelete);
            }
        }

        private void SetInitialView()
        {
            var rootItem = this.HierarchicalDataSource[0];
            if (rootItem != null)
            {
                rootItem.AreMembersVisible = true;
                if (rootItem.Children.Count > 1)
                {
                    (rootItem.Children[0] as OrgTeamViewModel).AreMembersVisible = true;
                    (rootItem.Children[1] as OrgTeamViewModel).AreMembersVisible = true;
                }
            }
        }
	}

	public class VisibilityChangedEventArgs : EventArgs
	{
		public VisibilityChangedEventArgs(bool isVisible)
		{
			this.IsVisible = isVisible;
		}
		public bool IsVisible { get; private set; }
	}
}
