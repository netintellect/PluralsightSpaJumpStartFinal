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

namespace Telerik.Windows.Examples.Chart.Customization.Combo
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
			DataSeries splineSeries = new DataSeries();
			splineSeries.Definition = new SplineArea3DSeriesDefinition();
			splineSeries.Definition.ShowItemLabels = false;
			SeriesExtensions.FillWithSampleData(splineSeries, 10);

			this.RadChart1.DefaultView.ChartArea.DataSeries.Add(splineSeries);

            DataSeries barSeries = new DataSeries();
            barSeries.Definition = new Bar3DSeriesDefinition();
            barSeries.Definition.ShowItemLabels = false;
            SeriesExtensions.FillWithSampleData(barSeries, 10);

            this.RadChart1.DefaultView.ChartArea.DataSeries.Add(barSeries);
		}

		private void UserControl_Loaded(object sender, RoutedEventArgs e)
		{
			CameraExtension cameraExtension = new CameraExtension();
			RadChart1.DefaultView.ChartArea.Extensions.Add(cameraExtension);
		}

		private void UserControl_Unloaded(object sender, RoutedEventArgs e)
		{
			RadChart1.DefaultView.ChartArea.Extensions.Clear();
		}
	}
}
