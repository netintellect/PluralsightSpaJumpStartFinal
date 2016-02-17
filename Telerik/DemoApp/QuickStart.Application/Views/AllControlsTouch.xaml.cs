using Telerik.Windows.QuickStart.ViewModel;

namespace Telerik.Windows.QuickStart
{
	/// <summary>
	/// Interaction logic for AllControls.xaml
	/// </summary>
	public partial class AllControlsTouch : ViewBase
	{
		private AllControlsTouchViewModel viewModel;
		private ExamplesListScrollHelper examplesListScrollHelper;

		public AllControlsTouch()
		{
			this.viewModel = (AllControlsTouchViewModel)ViewModelLocator.GetViewModel(this);
			this.DataContext = viewModel;

			InitializeComponent();
			this.examplesListScrollHelper = new ExamplesListScrollHelper(this.allControlsTileList, this.rootAllControls);
			this.examplesListScrollHelper.Initialize();
		}

		public override void OnNavigatedTo(object parameter)
		{
			base.OnNavigatedTo(parameter);
			this.allControlsTileList.SelectedIndex = -1;
			this.viewModel.ToggleApplicationTouchMode(true);
		}
	}
}
