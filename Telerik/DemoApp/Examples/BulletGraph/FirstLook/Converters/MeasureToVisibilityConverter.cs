using System;
using System.Collections;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.IO;
using System.Windows;
using System.Windows.Media;
using Telerik.Windows.Controls.BulletGraph;
using System.Windows.Data;

namespace Telerik.Windows.Examples.BulletGraph.FirstLook
{
    public class MeasureToVisibilityConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
        {
            KeyMeasure measure = value as KeyMeasure;
            if (measure == null || measure.ActualYTDProfit > measure.TargetYTDProfit)
                return Visibility.Collapsed;

            return Visibility.Visible;
        }

        public object ConvertBack(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
        {
            return value;
        }
    }
}

