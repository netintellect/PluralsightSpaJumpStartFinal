using System.Windows;
using System.Windows.Controls;
using Telerik.Windows.Controls.Charting;

namespace Telerik.Windows.Examples.Chart.FirstLook
{
    /// <summary>
    /// Interaction logic for Example.xaml
    /// </summary>
    public partial class Example : UserControl
    {
        public Example()
        {
            InitializeComponent();
            AttachClickEvent();
        }

        private void AttachClickEvent()
        {
            barChart.DefaultView.ChartArea.ItemClick += this.ChartArea_ItemClick;
        }

        private void ChartArea_ItemClick(object sender, ChartItemClickEventArgs e)
        {
            barChart.DefaultView.ChartArea.StartTransitionAnimation();
            lineChart.DefaultView.ChartArea.StartTransitionAnimation();
            (sender as ChartArea).ItemClick -= this.ChartArea_ItemClick;
        }

        private void HierarchyManager_Drill(object sender, HierarchyDrillEventArgs e)
        {
            Region region = e.DataItem as Region;

            if (e.HierarchyDrillAction == HierarchyDrillAction.Drill)
                TotalSalesTitle.Text = TotalSalesTitle.Text.Replace("Worldwide", "in " + region.Name);

            SparklineWrapper.PrepareAnimation();
            SparklineWrapper.StartAnimation();
        }

        private void GoBack1_Click(object sender, RoutedEventArgs e)
        {
            barChart.DefaultView.ChartArea.StartTransitionAnimation();
            lineChart.DefaultView.ChartArea.StartTransitionAnimation();

            this.AttachClickEvent();
        }

        private void GoBack2_Click(object sender, RoutedEventArgs e)
        {
            TotalSalesTitle.Text = "Total sales worldwide for 2009";
        }
    }
}
