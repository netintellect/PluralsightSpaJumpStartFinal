using System;
using System.Windows.Data;

namespace Telerik.Windows.Examples.ChartView.MultipleAxes
{
    public class ShortenerConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
        {
            return (value as string).Split(new[] { ',' })[0];
        }

        public object ConvertBack(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
        {
            return value;
        }
    }
}
