using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Data;
using Telerik.Windows.Examples.ChartView.LargeData.Views;
using System.Windows;

namespace Telerik.Windows.Examples.ChartView.LargeData
{
    public class YearToInitialVisibilityConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
        {
            string startYearString = parameter as string;
            int startYear;

            if (startYearString == null || !Int32.TryParse(startYearString, out startYear) || !(value is int))
                return Visibility.Visible;

            int year = (int)value;
            return year >= startYear ? Visibility.Visible : Visibility.Collapsed;
        }

        public object ConvertBack(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}
