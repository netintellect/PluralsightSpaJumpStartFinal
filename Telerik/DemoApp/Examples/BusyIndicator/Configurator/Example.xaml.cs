using System.Windows;
using System.Windows.Controls;
using Telerik.Windows.Controls.QuickStart;

namespace Telerik.Windows.Examples.BusyIndicator.Configurator
{
	public partial class Example : UserControl
	{
		public Example()
		{
			InitializeComponent();

			QuickStart.GetConfigurationPanel(this).DataContext = this.DataContext;
		}
	}
}