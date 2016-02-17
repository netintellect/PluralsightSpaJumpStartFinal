using System;
using System.Collections.ObjectModel;
using System.Linq;
using System.Windows;
using System.Windows.Controls;
using Telerik.Windows.Controls;

namespace Telerik.Windows.Examples.PivotGrid.PivotChart
{
    /// <summary>
    /// Interaction logic for Example.xaml
    /// </summary>
    public partial class Example : UserControl
    {
        public Example()
        {
            InitializeComponent();

            this.ChartType.SelectionChanged += ChartType_SelectionChanged_1;
            this.chart.SeriesProvider.SeriesDescriptors.First().Style = this.Resources["barCategoricalSeriesDescriptorStyle"] as Style;
            this.Unloaded += this.OnExampleUnloaded;
        }

        private void OnExampleUnloaded(object sender, RoutedEventArgs e)
        {
            RadWindowManager.Current.CloseAllWindows();
        }

        private void RefreshChartType(Style style)
        {
            this.chart.SeriesProvider.SeriesDescriptors.First().Style = style;
            this.chart.SeriesProvider.RefreshAttachedCharts();
        }

        private void ChartType_SelectionChanged_1(object sender, SelectionChangedEventArgs e)
        {
            var listBox = sender as ListBox;
            ChartType type = ((ChartType)listBox.SelectedItem);

            if (type.ChartSeriesType == ChartSeriesType.Bar)
            {
                this.RefreshChartType(this.Resources["barCategoricalSeriesDescriptorStyle"] as Style);
            }
            else
            {
                if (type.ChartSeriesType == ChartSeriesType.Area)
                {
                    this.RefreshChartType(this.Resources["areaCategoricalSeriesDescriptorStyle"] as Style);
                }
                else
                {
                    this.RefreshChartType(this.Resources["lineCategoricalSeriesDescriptorStyle"] as Style);
                }

            }
        }
    }
}
