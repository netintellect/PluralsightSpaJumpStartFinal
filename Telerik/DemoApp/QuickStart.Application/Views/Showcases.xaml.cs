using Telerik.Windows.QuickStart.ViewModel;

namespace Telerik.Windows.QuickStart
{
	/// <summary>
	/// Interaction logic for Showcases.xaml
	/// </summary>
	public partial class Showcases : ViewBase
	{
        public Showcases()
		{
			QuickStartViewModelBase viewModel = ViewModelLocator.GetViewModel(this);
            this.DataContext = viewModel;

			InitializeComponent();
		}
	}
}
