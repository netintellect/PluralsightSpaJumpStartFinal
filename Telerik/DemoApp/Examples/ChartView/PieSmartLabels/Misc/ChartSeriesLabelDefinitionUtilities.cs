using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using Telerik.Windows.Controls.ChartView;

namespace Telerik.Windows.Examples.ChartView.PieSmartLabels
{
    public static class ChartSeriesLabelDefinitionUtilities
    {
        public static readonly DependencyProperty LabelDefinitionProperty = DependencyProperty.RegisterAttached(
            "LabelDefinition",
            typeof(ChartSeriesLabelDefinition),
            typeof(ChartSeriesLabelDefinitionUtilities),
            new PropertyMetadata(new ChartSeriesLabelDefinition(), LabelDefinitionChanged));

        public static ChartSeriesLabelDefinition GetLabelDefinition(DependencyObject obj)
        {
            return (ChartSeriesLabelDefinition)obj.GetValue(LabelDefinitionProperty);
        }

        public static void SetLabelDefinition(DependencyObject obj, ChartSeriesLabelDefinition value)
        {
            obj.SetValue(LabelDefinitionProperty, value);
        }

        private static void LabelDefinitionChanged(DependencyObject target, DependencyPropertyChangedEventArgs args)
        {
            ChartSeries series = (ChartSeries)target;
            series.LabelDefinitions.Clear();
            series.LabelDefinitions.Add((ChartSeriesLabelDefinition)args.NewValue);
        }
    }
}
