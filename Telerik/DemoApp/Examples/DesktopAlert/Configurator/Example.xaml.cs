using System.Windows.Controls;

namespace Telerik.Windows.Examples.DesktopAlert.Configurator
{
	public partial class Example : UserControl
	{
		public Example()
		{
			InitializeComponent();
            this.Unloaded += OnExampleUnloaded;
		}

        private void OnExampleUnloaded(object sender, System.Windows.RoutedEventArgs e)
        {
            (this.DataContext as ViewModel).CloseAllAlerts();
        }
	}
}
