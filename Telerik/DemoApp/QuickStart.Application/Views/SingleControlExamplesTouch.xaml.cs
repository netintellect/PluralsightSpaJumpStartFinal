using System;
using System.Linq;
using Telerik.Windows.QuickStart.ViewModel;

namespace Telerik.Windows.QuickStart
{
    /// <summary>
    /// Interaction logic for SingleControlExamplesTouch.xaml
    /// </summary>
    public partial class SingleControlExamplesTouch : ViewBase
    {
        private SingleControlExamplesViewModel viewModel;
        private ExamplesListScrollHelper examplesListScrollHelper;

        public SingleControlExamplesTouch()
        {
            this.viewModel = (SingleControlExamplesViewModel) ViewModelLocator.GetViewModel(this);
            this.DataContext = this.viewModel;

            this.InitializeComponent();
            this.examplesListScrollHelper = new ExamplesListScrollHelper(this.ListView, this.rootSingleControlExamplesTouch);
            this.examplesListScrollHelper.Initialize();
        }

        public override void OnNavigatedTo(object parameter)
        {
            base.OnNavigatedTo(parameter);
            this.ListView.SelectedIndex = -1;
            this.viewModel.Initialize(parameter as IControlInfo);
        }
    }
}