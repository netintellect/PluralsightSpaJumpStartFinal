using System;
using System.Linq;
using Telerik.Windows.Controls;

namespace Telerik.Windows.QuickStart.ViewModel
{
    public class SingleControlExamplesViewModel : QuickStartViewModelBase
    {
        private IControlInfo controlInfo;
        private bool hasUpdatedExamples;
        private bool hasCtpExamples;
        private bool hasBetaExamples;
        private bool hasNewExamples;

        public SingleControlExamplesViewModel(INotifyUser ownerView)
            :base(ownerView)
        {
        }

        public IControlInfo ControlInfo
        {
            get
            {
                return this.controlInfo;
            }
            set
            {
                this.controlInfo = value;
                this.OnPropertyChanged("ControlInfo");
            }
        }

        public bool HasUpdatedExamples
        {
            get
            {
                return this.hasUpdatedExamples;
            }
            set
            {
                this.hasUpdatedExamples = value;
                this.OnPropertyChanged("HasUpdatedExamples");
            }
        }

        public bool HasCtpExamples
        {
            get
            {
                return this.hasCtpExamples;
            }
            set
            {
                this.hasCtpExamples = value;
                this.OnPropertyChanged("HasCtpExamples");
            }
        }

        public bool HasBetaExamples
        {
            get
            {
                return this.hasBetaExamples;
            }
            set
            {
                this.hasBetaExamples = value;
                this.OnPropertyChanged("HasBetaExamples");
            }
        }

        public bool HasNewExamples
        {
            get
            {
                return this.hasNewExamples;
            }
            set
            {
                this.hasNewExamples = value;
                this.OnPropertyChanged("HasNewExamples");
            }
        }

        public void Initialize(IControlInfo controlInfo)
        {
            this.ControlInfo = controlInfo;
            
            this.HasBetaExamples = this.ControlInfo.TouchExamples.Count(ex => ex.Status == Enums.StatusMode.Beta) > 0;
            this.HasUpdatedExamples = this.ControlInfo.TouchExamples.Count(ex => ex.Status == Enums.StatusMode.Updated) > 0;
            this.HasCtpExamples = this.ControlInfo.TouchExamples.Count(ex => ex.Status == Enums.StatusMode.Ctp) > 0;
            this.HasNewExamples = this.ControlInfo.TouchExamples.Count(ex => ex.Status == Enums.StatusMode.New) > 0;

            this.NavigateCommand = new DelegateCommand(this.OnNavigateCommandExecuted);
        }
    }
}