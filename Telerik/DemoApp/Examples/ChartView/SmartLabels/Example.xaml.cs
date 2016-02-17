using System.Windows.Controls;
using Telerik.Windows.Controls.ChartView;

namespace Telerik.Windows.Examples.ChartView.SmartLabels
{
    public partial class Example : UserControl
    {
        public Example()
        {
            InitializeComponent();
        }

        private void RadioButtonDisable_Click(object sender, System.Windows.RoutedEventArgs e)
        {
            FuelChart.SmartLabelsStrategy = null;
        }

        private void RadioButtonChartStrategy_Click(object sender, System.Windows.RoutedEventArgs e)
        {
            FuelChart.SmartLabelsStrategy = new ChartSmartLabelsStrategy();
        }

        private void RadioButtonCustomStrategy_Click(object sender, System.Windows.RoutedEventArgs e)
        {
            FuelChart.SmartLabelsStrategy = new TwoLineSeriesLabelsStrategy();
        }
    }
}
