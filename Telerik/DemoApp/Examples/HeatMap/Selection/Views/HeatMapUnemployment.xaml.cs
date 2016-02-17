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
using Telerik.Windows.Examples.HeatMap.Selection.ViewModels;
using Telerik.Windows.Controls;
using Telerik.Windows.Controls.QuickStart.Common.Helpers;

namespace Telerik.Windows.Examples.HeatMap.Selection.Views
{
    /// <summary>
    /// Interaction logic for HeatMapUnemployment.xaml
    /// </summary>
    public partial class HeatMapUnemployment : UserControl
    {
        public HeatMapUnemployment()
        {
            if (ApplicationThemeManager.GetInstance().CurrentTheme == "Windows8Touch")
            {
                this.Resources.MergedDictionaries.Add(new System.Windows.ResourceDictionary() { Source = new Uri("/HeatMap;component/Selection/Resources/Win8TouchResources.xaml", UriKind.RelativeOrAbsolute) });
            }
            else
            {
                this.Resources.MergedDictionaries.Add(new System.Windows.ResourceDictionary() { Source = new Uri("/HeatMap;component/Selection/Resources/Win8Resources.xaml", UriKind.RelativeOrAbsolute) });
            }
            this.Resources.MergedDictionaries.Add(new System.Windows.ResourceDictionary() { Source = new Uri("/HeatMap;component/Selection/Resources/Resources.xaml", UriKind.RelativeOrAbsolute) });
            InitializeComponent();
        }

        private void RadHeatMap_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            var heatMap = sender as RadHeatMap;
            var vm = this.DataContext as CountriesViewModel;
            if (vm != null && heatMap != null && heatMap.HoveredCellDataPoint != null)
            {
                vm.UnemploymentRateColor = heatMap.HoveredCellDataPoint.Color;
            }
        }
    }
}
