using Telerik.Windows.QuickStart.ViewModel;

namespace Telerik.Windows.QuickStart
{
	/// <summary>
	/// Interaction logic for AllControls.xaml
	/// </summary>
	public partial class AllControls : ViewBase
	{
		public AllControls()
		{
			QuickStartViewModelBase viewModel = ViewModelLocator.GetViewModel(this);
			this.DataContext = viewModel;

			InitializeComponent();
		}
	}
}
