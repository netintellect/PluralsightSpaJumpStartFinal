using System;
using System.Windows.Data;

namespace Telerik.Windows.Examples.ChartView.Gallery.PolarLineArea
{
    public class AxisLabelConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
        {
            double doubleValue = double.Parse(value.ToString());
            if (doubleValue == 0 || doubleValue == 1)
                return " ";

            return string.Format("-{0}dB", 25 * (1 - doubleValue));
        }

        public object ConvertBack(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}
