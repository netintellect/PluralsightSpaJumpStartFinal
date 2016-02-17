using System;
using System.Net;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Documents;
using System.Windows.Ink;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Animation;
using System.Windows.Shapes;
using Telerik.Charting;
using Telerik.Windows.Controls;
using Telerik.Windows.Controls.ChartView;
using Telerik.Windows.Examples.HeatMap.Selection.Models;
using Telerik.Windows.Examples.HeatMap.Selection.ViewModels;

namespace Telerik.Windows.Examples.HeatMap.Selection.Utilities
{
    public class ChartPointTemplateSelector : DataTemplateSelector
    {
        public DataTemplate NormalTemplate { get; set; }
        public DataTemplate SelectedTemplate { get; set; }

        public override DataTemplate SelectTemplate(object item, DependencyObject container)
        {
            FrameworkElement series = (FrameworkElement)container;
            CountriesViewModel vm = series.DataContext as CountriesViewModel;
            CategoricalDataPoint dp = item as CategoricalDataPoint;
            CountryInfo info = dp.DataItem as CountryInfo;

            if (info.Year == vm.SelectedCountry.Year)
                return this.SelectedTemplate;
            else
                return this.NormalTemplate;
        }
    }
}
