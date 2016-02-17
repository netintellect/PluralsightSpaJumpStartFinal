using System.Linq;
using System.Windows.Controls;
using System.Windows.Data;
using Telerik.Windows.Controls.QuickStart.Infrastructure;
using Telerik.Windows.QuickStart.ViewModel;

namespace Telerik.Windows.QuickStart
{
	/// <summary>
	/// Interaction logic for SingleControl.xaml
	/// </summary>
	public partial class SingleExample : ViewBase
	{
		public SingleExample()
		{
			SingleExampleViewModel viewModel = (SingleExampleViewModel)ViewModelLocator.GetViewModel(this);
			this.DataContext = viewModel;

			InitializeComponent();
		}

		public override void OnNavigatedFrom(object parameter)
		{
			base.OnNavigatedFrom(parameter);
			this.ExampleArea.Content = null;
			this.Configurator.Content = null;
		}

		public override void OnNavigatedTo(object parameter)
		{
			base.OnNavigatedTo(parameter);
			(this.DataContext as SingleExampleViewModel).Initialize(parameter as IExampleInfo, () =>
			{

				//TODO: find a way to fix this properly
				// refresh binding, so content is properly updated
				// this fixes an issue where inside the example Window.GetWindow(this.LayoutRoot); returns null

				this.ExampleArea.Content = null;
				this.ExampleArea.SetBinding(ContentControl.ContentProperty, new Binding("CurrentExampleInstance"));

				//reset this binding in order to refresh the proper styles for the Configurator
				this.Configurator.Content = null;
				this.Configurator.SetBinding(ContentControl.ContentProperty, new Binding("(ContentControl.Content).(telerikQuickStart:QuickStart.ConfigurationPanel)") { ElementName = "ExampleArea" });

				(this.DataContext as SingleExampleViewModel).RaiseCurrentThemePropertyChanged();
			});
		}
	}
}
