using System.Collections.Generic;
using System.Linq;
using System.Windows.Controls;
using Telerik.Windows.Controls.ChartView;
using System.Collections.ObjectModel;

namespace Telerik.Windows.Examples.ChartView.PieSmartLabels
{
    public partial class Example : UserControl
    {
        public Example()
        {
            InitializeComponent();

        }

        private void Regions_Loaded(object sender, System.Windows.RoutedEventArgs e)
        {
            Animations.ChartAnimationUtilities.SetPieAnimation(this.PieChart.Series[0], Animations.PieAnimation.Slice);
            Animations.ChartAnimationUtilities.DispatchRunAnimations(this.PieChart);
            this.Dispatcher.BeginInvoke((System.Action)(() => 
            {
                Animations.ChartAnimationUtilities.SetPieAnimation(this.PieChart.Series[0], Animations.PieAnimation.None);
            }));
        }

        private void RadioButtonDisableSmartLabels_Click(object sender, System.Windows.RoutedEventArgs e)
        {
            this.PieChart.SmartLabelsStrategy = null;
        }

        private void RadioButtonBasic_Click(object sender, System.Windows.RoutedEventArgs e)
        {
            this.PieChart.SmartLabelsStrategy = new PieChartSmartLabelsStrategy();
        }

        private void RadioButtonOutside_Click(object sender, System.Windows.RoutedEventArgs e)
        {
            this.PieChart.SmartLabelsStrategy = new PieChartSmartLabelsStrategy() { DisplayMode = PieChartLabelsDisplayMode.Outside };
        }

        private void RadioButtonSpider_Click(object sender, System.Windows.RoutedEventArgs e)
        {
            this.PieChart.SmartLabelsStrategy = new PieChartSmartLabelsStrategy() { DisplayMode = PieChartLabelsDisplayMode.Spider };
        }

        private void RadioButtonSpiderUnaligned_Click(object sender, System.Windows.RoutedEventArgs e)
        {
            this.PieChart.SmartLabelsStrategy = new PieChartSmartLabelsStrategy() { DisplayMode = PieChartLabelsDisplayMode.SpiderUnaligned };
        }

        private void RadioButtonSpiderAlignedOutwards_Click(object sender, System.Windows.RoutedEventArgs e)
        {
            this.PieChart.SmartLabelsStrategy = new PieChartSmartLabelsStrategy() { DisplayMode = PieChartLabelsDisplayMode.SpiderAlignedOutwards };
        }

        private void RadioButtonCustomStrategy_Click(object sender, System.Windows.RoutedEventArgs e)
        {
            this.PieChart.SmartLabelsStrategy = new CustomSpiderLabelsStrategy();
        }

        private void Regions_SelectionChanged(object sender, System.EventArgs e)
        {
            Regions map = (Regions)sender;
            List<string> selectedRegions = map.GetSelectedRegions();
            ExampleViewModel vm = (ExampleViewModel)this.DataContext;

            vm.SelectedRegions.Clear();
            foreach (string regionTag in selectedRegions)
            {
                Region region = vm.Regions.First(r => r.Name.ToLower().Contains(regionTag));
                vm.SelectedRegions.Add(region);
            }
        }
    }
}
