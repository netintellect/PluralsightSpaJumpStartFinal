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

namespace Telerik.Windows.Examples.Chart.Customization.StarBar
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
			barSeries.Definition = new Bar3DSeriesDefinition();
			barSeries.Definition.ItemStyle = (Style) this.FindResource("MyStyle");
			SeriesExtensions.FillWithSampleData(barSeries);

			this.RadChart1.DefaultView.ChartArea.DataSeries.Add(barSeries);
			this.RadChart1.DefaultView.ChartLegend.Visibility = System.Windows.Visibility.Collapsed;
		}

        private void ExampleControl_Loaded(object sender, RoutedEventArgs e)
        {
            CameraExtension cameraExtension = new CameraExtension();
            cameraExtension.ZoomEnabled = true;
            cameraExtension.SpinAxis = SpinAxis.XY;
            cameraExtension.RotateX(10);
			cameraExtension.RotateY(10);
            RadChart1.DefaultView.ChartArea.Extensions.Add(cameraExtension);
        }

        private void ExampleControl_Unloaded(object sender, RoutedEventArgs e)
        {
            RadChart1.DefaultView.ChartArea.Extensions.Clear();
        }

	}
}
