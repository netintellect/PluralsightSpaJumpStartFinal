using System.Windows;
using Telerik.Windows.Controls;
using Telerik.Windows.Controls.Charting; 
using System.Windows.Controls;

namespace Telerik.Windows.Examples.Chart.Integration.ChartContextMenuIntegration
{
	/// <summary>
	/// Interaction logic for Example.xaml
	/// </summary>
    public partial class Example : UserControl
	{
		public Example()
		{
			InitializeComponent();

            this.DataContext = new ChartViewModel();
		}

        private void OnContextMenuClick(object sender, Telerik.Windows.RadRoutedEventArgs e)
        {
            // Get the clicked item
            MenuItem menuItem = (e.OriginalSource as RadMenuItem).Header as MenuItem;

            if (menuItem.Text == "Foo 0")
            {
                //...
            }
        }
	}
}
