using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows;
using Telerik.Windows.Controls.ChartView;

namespace Telerik.Windows.Examples.ChartView.BrowsersChart.Utilities
{
    public static class ChartSeriesLabelDefinitionUtilities
    {
        public static DataTemplate GetTemplate(DependencyObject obj)
        {
            return (DataTemplate)obj.GetValue(TemplateProperty);
        }

        public static void SetTemplate(DependencyObject obj, DataTemplate value)
        {
            obj.SetValue(TemplateProperty, value);
        }

        public static readonly DependencyProperty TemplateProperty = DependencyProperty.RegisterAttached(
            "Template", 
            typeof(DataTemplate),
            typeof(ChartSeriesLabelDefinitionUtilities),
            new PropertyMetadata(null, TemplateChanged));

        private static void TemplateChanged(DependencyObject target, DependencyPropertyChangedEventArgs args)
        {
            BarSeries barSeries = (BarSeries)target;
            barSeries.LabelDefinitions.Clear();
            DataTemplate template = (DataTemplate)args.NewValue;
            if (template != null)
            {
                barSeries.LabelDefinitions.Add(new ChartSeriesLabelDefinition() { Template = template });
            }
        }
    }
}
