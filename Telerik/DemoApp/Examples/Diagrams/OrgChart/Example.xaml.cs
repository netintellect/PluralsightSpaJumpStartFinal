using System;
using System.Windows.Controls;

namespace Telerik.Windows.Examples.Diagrams.OrgChart
{
	public partial class Example : UserControl
	{
		public Example()
		{
			InitializeComponent();
			var datacontext = this.orgChart.RootGrid.Resources["ViewModel"];
			this.configStackPanel.DataContext = datacontext;
		}		
	}
}
