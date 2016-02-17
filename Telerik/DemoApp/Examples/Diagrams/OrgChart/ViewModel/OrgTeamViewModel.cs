using System.Collections.ObjectModel;
using System.Collections.Specialized;
using System.Linq;
using Telerik.Windows.Controls;
using Telerik.Windows.Controls.Diagrams.Extensions.ViewModels;
using System;
using Telerik.Windows.Examples.Diagrams.OrgChart.ViewModel;
using Telerik.Windows.Diagrams.Core;
using Telerik.Windows.Examples.Diagrams.OrgChart.Interfaces;
using System.Windows.Input;

namespace Telerik.Windows.Examples.Diagrams.OrgChart
{
	public class OrgTeamViewModel : HierarchicalNodeViewModel, ISelectable, IPathEnabled
	{
		public OrgTeamViewModel()
		{
            this.childrenAndMembersCollection = new ObservableCollection<ISelectable>();
			this.Children.CollectionChanged += OnChildrenCollectionChanged;
			this.IsExpanded = true;
			this.ToggleVisibilityCommand = new DelegateCommand((_) => this.IsExpanded = !this.IsExpanded, (_) => this.Children.Count > 0);
            this.ToggleMembersVisibilityCommand = new DelegateCommand(x => this.OnMembersVisiblityChanged());
            this.DeleteTeamCommand = new DelegateCommand(x => this.OnDeleteTeamRequested(), x => !this.HasChildren);
            this.AddSubTeamCommand = new DelegateCommand(x => this.OnAddSubTeamRequested());
            this.RenameCommand = new DelegateCommand(x => this.BeginRename());
            this.TeamMembers = new ObservableCollection<OrgTeamMemberViewModel>();

            // Every member is collapsed on start.
            this.AreMembersVisible = false;
            this.TeamMembers.CollectionChanged += MembersCollectionChanged;
		}

        public void RaiseMemberSelectedEvent()
        {
            if (this.TeamOrMemberSelecting != null)
            {
                this.TeamOrMemberSelecting(this, null);
            }
        }

        public DelegateCommand RenameCommand { get; set; }

        public DelegateCommand AddSubTeamCommand { get; set; }

        public DelegateCommand DeleteTeamCommand { get; set; }

        public DelegateCommand ToggleVisibilityCommand { get; set; }

        public DelegateCommand ToggleMembersVisibilityCommand { get; set; }

        public ObservableCollection<OrgTeamMemberViewModel> TeamMembers { get; set; }

        public event EventHandler AddSubTeamRequested;

        public event EventHandler DeleteTeamRequested;

		public event EventHandler IsExpandedChanged;

        public event EventHandler<TeamExpandCollapseChangeEventArgs> MembersVisibilityChanged;

        public event EventHandler TeamOrMemberSelecting;

        public Branch Branch { get; set; }

		public int HeadCount { get; set; }

        private string name;				
		public string Name 
		{
			get{ return this.name;}
			set
			{
                if(this.name != value)
                {
				    this.name = value;
                    if (this.IsInEditMode)
                    {
                        this.IsInEditMode = false;
                    }
				    this.OnPropertyChanged("Name");
                }
			}
		}

        private bool isExpanded;
        public bool IsExpanded
        {
            get { return this.isExpanded; }
            set
            {
                if (this.isExpanded != value)
                {                   
                    this.isExpanded = value;
                    this.OnPropertyChanged("IsExpanded");
                    this.OnIsExpandedChanged();
                }
            }
        }

        private bool isDropTarget;
        public bool IsDropTarget
        {
            get { return this.isDropTarget; }
            set
            {
                if (this.isDropTarget != value)
                {
                    this.isDropTarget = value;
                    this.OnPropertyChanged("IsDropTarget");
                }
            }
        }        

        private bool isExpandedInTree;
        public bool IsExpandedInTree
        {
            get { return this.isExpandedInTree; }
            set
            {
                if (this.isExpandedInTree != value)
                {
                    this.isExpandedInTree = value;
                    this.OnPropertyChanged("IsExpandedInTree");
                }
            }
        }

        private bool areMembersVisible;
        public bool AreMembersVisible
        {
            get { return this.areMembersVisible; }
            set
            {
                if (this.areMembersVisible != value)
                {
                    this.areMembersVisible = value;
                    this.OnPropertyChanged("AreMembersVisible");
                    this.ThrowMembersVisibilityChanged();
                }
            }
        }       

        private bool isInEditMode;
        public bool IsInEditMode
        {
            get { return this.isInEditMode; }
            set
            {
                if (this.isInEditMode != value)
                {
                    this.isInEditMode = value;
                    this.OnPropertyChanged("IsInEditMode");
                }
            }
        }

        private bool isSettingsButtonopen;
        public bool IsSettingsButtonOpen
        {
            get { return this.isSettingsButtonopen; }
            set
            {
                if (this.isSettingsButtonopen != value)
                {
                    this.isSettingsButtonopen = value;
                    this.OnPropertyChanged("IsSettingsButtonOpen");
                }
            }
        }        

        private readonly ObservableCollection<ISelectable> childrenAndMembersCollection;
        public ObservableCollection<ISelectable> ChildrenAndMembers
        {
            get
            {
                return this.childrenAndMembersCollection;
            }
        }

		public string Path { get; set; }

		private void OnChildrenCollectionChanged(object sender, NotifyCollectionChangedEventArgs e)
		{
            this.DeleteTeamCommand.InvalidateCanExecute();
            this.ToggleVisibilityCommand.InvalidateCanExecute();
            this.UpdateAllChildrenCollection();
			if (e.Action == NotifyCollectionChangedAction.Add)
			{
				OrgTeamViewModel firstChild = e.NewItems[0] as OrgTeamViewModel;
				this.HeadCount += firstChild.HeadCount + 1;
			}
			else if (e.Action == NotifyCollectionChangedAction.Remove)
			{
				OrgTeamViewModel firstChild = e.OldItems[0] as OrgTeamViewModel;
				this.HeadCount -= (firstChild.HeadCount + 1);
			}
		}

		private void OnIsExpandedChanged()
		{
			if (this.IsExpandedChanged != null)
			{
				this.IsExpandedChanged(this, EventArgs.Empty);
			}
		}

        private void OnMembersVisiblityChanged()
        {
            this.AreMembersVisible = !this.AreMembersVisible;
            this.ThrowMembersVisibilityChanged();
        }

        private void ThrowMembersVisibilityChanged()
        {
            if (this.MembersVisibilityChanged != null)
            {
                TeamExpandCollapseChangeEventArgs args = new TeamExpandCollapseChangeEventArgs(this);
                this.MembersVisibilityChanged(this, args);
            }
        }

        private void MembersCollectionChanged(object sender, NotifyCollectionChangedEventArgs e)
        {
            this.UpdateAllChildrenCollection();
            this.DeleteTeamCommand.InvalidateCanExecute();
        }

        private void UpdateAllChildrenCollection()
        {
            this.childrenAndMembersCollection.Clear();
            this.childrenAndMembersCollection.AddRange(this.TeamMembers);
            this.Children.ForEach(ch => this.childrenAndMembersCollection.Add(ch as ISelectable));
        }

        private void RaiseTeamSelectedEvent()
        {
            if (this.TeamOrMemberSelecting != null)
            {
                this.TeamOrMemberSelecting(this, null);
            }
        }

        private void OnDeleteTeamRequested()
        {
            if (this.DeleteTeamRequested != null)
            {
                this.DeleteTeamRequested(this, null);
            }
        }

        private void OnAddSubTeamRequested()
        {           
            if (this.AddSubTeamRequested != null)
            {
                this.AddSubTeamRequested(this, null);
            }
            this.IsSettingsButtonOpen = false;
        }

        private void BeginRename()
        {
            this.IsInEditMode = true;
            this.IsSettingsButtonOpen = false;
        }

        private bool isSelected;
        bool ISelectable.IsSelected
        {
            get { return this.isSelected; }
            set
            {
                if (this.isSelected != value)
                {
                    if (value)
                    {
                        this.RaiseTeamSelectedEvent();
                    }
                    this.isSelected = value;
                    this.OnPropertyChanged("IsSelected");
                }
            }
        }
    }
}