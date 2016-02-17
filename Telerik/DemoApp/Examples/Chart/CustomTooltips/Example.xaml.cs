using System.Windows.Controls;
using System.Windows.Data;
using Telerik.Windows.Controls;
using Telerik.Windows.Controls.Charting;

namespace Telerik.Windows.Examples.Chart.CustomTooltips
{
    /// <summary>
    /// Interaction logic for Example.xaml
    /// </summary>
    public partial class Example : UserControl
    {
        public Example()
        {
            InitializeComponent();
        }

        private void ChartArea_ItemToolTipOpening(ItemToolTip2D tooltip, ItemToolTipEventArgs e)
        {
            RadChart chart = new RadChart();
            
            string bindingPath = string.Format("TotalRevenueData[{0}]", e.ItemIndex);
            Binding binding = new Binding(bindingPath);
            binding.Source = this.DataContext;
            chart.SetBinding(RadChart.ItemsSourceProperty, binding);

            chart.Height = 200;
            chart.Width = 350;
            chart.DefaultView.ChartLegend.Visibility = System.Windows.Visibility.Collapsed;
            chart.DefaultView.ChartArea.AxisX.LayoutMode = AxisLayoutMode.Between;

            TextBlock customChartTitle = new TextBlock();
            customChartTitle.Text = string.Format("Total Revenue for {0} \n(in millions)", e.DataPoint.LegendLabel);
            customChartTitle.TextWrapping = System.Windows.TextWrapping.Wrap;
            customChartTitle.TextAlignment = System.Windows.TextAlignment.Center;
            customChartTitle.FontSize = 12;
            chart.DefaultView.ChartTitle.Content = customChartTitle;

            SeriesMapping _seriesMapping = new SeriesMapping();
            _seriesMapping.SeriesDefinition = new LineSeriesDefinition();
            _seriesMapping.SeriesDefinition.ShowItemLabels = false;
            _seriesMapping.ItemMappings.Add(new ItemMapping("Volume", DataPointMember.YValue));
            _seriesMapping.ItemMappings.Add(new ItemMapping("Category", DataPointMember.XCategory));
            chart.SeriesMappings.Add(_seriesMapping);

            tooltip.Content = chart;
        }
    }
}
