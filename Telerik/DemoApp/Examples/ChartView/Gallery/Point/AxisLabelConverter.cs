﻿using System;
using System.Windows.Data;

namespace Telerik.Windows.Examples.ChartView.Gallery.Point
{
    public class AxisLabelConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
        {
            DateTime date = (DateTime)value;
            if (date.Month == 1)
                return String.Format("{0:MMM}" + Environment.NewLine + "{0:yyyy}", date);
            else
                return String.Format("{0:MMM}", date);
        }

        public object ConvertBack(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }

}
