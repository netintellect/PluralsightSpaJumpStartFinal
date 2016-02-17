using System;
using System.Linq;
using System.Windows.Media;
using Telerik.Windows.Controls;
using Telerik.Windows.Examples.Diagrams.OrgChart.Interfaces;

namespace Telerik.Windows.Examples.Diagrams.OrgChart.ViewModel
{
    public class OrgTeamMemberViewModel : ViewModelBase, ISelectable, IPathEnabled
    {
        public OrgTeamMemberViewModel()
        {
            this.BeginEditCommand = new DelegateCommand(x => this.BeginEdit());
        }

        public DelegateCommand BeginEditCommand { get; set; }

        public string ImagePath { get; set; }      
        public OrgTeamViewModel Team { get; set; }

        private string name;
        public string Name
        {
            get { return this.name; }
            set
            {
                if (this.name != value)
                {
                    this.name = value;                  
                    this.OnPropertyChanged("Name");
                }
            }
        }

        private bool isButtonOpen;
        public bool IsButtonOpen
        {
            get { return this.isButtonOpen; }
            set
            {
                if (this.isButtonOpen != value)
                {
                    this.isButtonOpen = value;
                    this.OnPropertyChanged("IsButtonOpen");
                }
            }
        }

        private object dropTarget;
        public object DropTarget
        {
            get { return this.dropTarget; }
            set
            {
                if (this.dropTarget != value)
                {
                    this.dropTarget = value;
                    this.OnPropertyChanged("DropTarget");
                }
            }
        }      

        private string position;
        public string Position
        {
            get { return this.position; }
            set
            {
                if (this.position != value)
                {
                    this.position = value;
                    if (this.IsInEditMode)
                    {
                        this.IsInEditMode = false;
                    }
                    this.OnPropertyChanged("Position");
                }
            }
        }   

        private bool isSelected;
        public bool IsSelected
        {
            get { return this.isSelected; }
            set
            {
                if (this.isSelected != value)
                {
                    if (value && this.Team != null)
                    {
                        this.Team.RaiseMemberSelectedEvent();
                    }
                    this.isSelected = value;
                    this.OnPropertyChanged("IsSelected");
                }
            }
        }

        private bool isSettingsButtonVisible;
        public bool IsSettingsButtonVisible
        {
            get { return this.isSettingsButtonVisible; }
            set
            {
                if (this.isSettingsButtonVisible != value)
                {
                    this.isSettingsButtonVisible = value;
                    this.OnPropertyChanged("IsSettingsButtonVisible");
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

        public string Path
        {
            get
            {
                return this.Team.Path + "|" + this.Name;
            }
            set
            { 
            }
        }
        public Branch Branch 
        {
            get
            {
                return this.Team.Branch;
            }
            set
            { 
            }
        }

        private void BeginEdit()
        {
            this.IsInEditMode = true;
            this.IsButtonOpen = false;
        }
    }
}
