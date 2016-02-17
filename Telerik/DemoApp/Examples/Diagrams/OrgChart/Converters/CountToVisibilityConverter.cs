﻿using System;
using System.Linq;
using System.Windows;
using System.Windows.Data;

namespace Telerik.Windows.Examples.Diagrams.OrgChart.Converters
{
    public class CountToVisibilityConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
        {
            int minimumValue = 0;
            if (parameter != null)
            {
                int.TryParse(parameter.ToString(), out minimumValue);
            }

            return (int)value > minimumValue ? Visibility.Visible : Visibility.Collapsed;

        }

        public object ConvertBack(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}