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

namespace Telerik.Windows.Examples.ChartView.Gallery.ScatterPoint
{
    public class LegendFigureSwitch : DependencyObject
    {
        public static readonly DependencyProperty SeriesTypeProperty = DependencyProperty.RegisterAttached("SeriesType",
                                                                                                           typeof(string),
                                                                                                           typeof(LegendFigureSwitch),
                                                                                                           new PropertyMetadata("", OnSeriesTypeChanged));

        public static string GetSeriesType(DependencyObject obj)
        {
            return (string)obj.GetValue(SeriesTypeProperty);
        }

        public static void SetSeriesType(DependencyObject obj, string value)
        {
            obj.SetValue(SeriesTypeProperty, value);
        }

        private static void OnSeriesTypeChanged(DependencyObject sender, DependencyPropertyChangedEventArgs e)
        {
            if (e.NewValue == null)
                return;

            StackPanel stackPanel = sender as StackPanel;
            if (stackPanel == null)
                return;

            string newValue = (string)e.NewValue;

            if (newValue == "Scatter point")
            {
                (stackPanel.Children[0] as Path).Style = stackPanel.Resources["ScatterPointLegend1"] as Style;
                (stackPanel.Children[2] as Path).Style = stackPanel.Resources["ScatterPointLegend2"] as Style;
            }
            else if (newValue == "Scatter line")
            {
                (stackPanel.Children[0] as Path).Style = stackPanel.Resources["ScatterLineLegend1"] as Style;
                (stackPanel.Children[2] as Path).Style = stackPanel.Resources["ScatterLineLegend2"] as Style;
            }
            else if (newValue == "Scatter area")
            {
                (stackPanel.Children[0] as Path).Style = stackPanel.Resources["ScatterAreaLegend1"] as Style;
                (stackPanel.Children[2] as Path).Style = stackPanel.Resources["ScatterAreaLegend2"] as Style;
            }
        }
    }
}
