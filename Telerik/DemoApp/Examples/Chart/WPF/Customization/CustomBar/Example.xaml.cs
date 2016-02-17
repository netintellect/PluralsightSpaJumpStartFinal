using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes; 
using Telerik.Windows.Controls.Charting;

namespace Telerik.Windows.Examples.Chart.Customization.CustomBar
{
	/// <summary>
	/// Interaction logic for Example.xaml
	/// </summary>
    public partial class Example : UserControl
	{
		public Example()
		{
			InitializeComponent();
			this.FillSampleChartData();
		}

		private void FillSampleChartData()
		{
			DataSeries barSeries = new DataSeries();
            barSeries.Definition = new BarSeriesDefinition();
            barSeries.Definition.ShowItemLabels = false;
			barSeries.Definition.ItemStyle = (Style) this.FindResource("MyStyle");
			SeriesExtensions.FillWithSampleData(barSeries);

			this.RadChart1.DefaultView.ChartArea.DataSeries.Add(barSeries);
		}
	}
}
