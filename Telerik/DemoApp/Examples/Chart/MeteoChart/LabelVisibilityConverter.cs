using System;
using System.Windows;
using System.Windows.Data;
using Telerik.Windows.Controls.Charting;

namespace Telerik.Windows.Examples.Chart.MeteoChart
{
    public class LabelVisibilityConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
        {
            DataPoint point = value as DataPoint;
            if (point.YValue == 0)
                return Visibility.Collapsed;

            return Visibility.Visible;
        }

        public object ConvertBack(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}
