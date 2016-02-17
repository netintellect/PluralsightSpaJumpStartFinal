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
    public class MeasureToListConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
        {
            KeyMeasure measure = value as KeyMeasure;
            return new List<KeyMeasure>() { measure };
        }

        public object ConvertBack(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
        {
            return value;
        }
    }
}

