using System;
using System.Globalization;
using System.Windows.Data;

namespace Telerik.Windows.Examples.Map.Theatre
{
    public class SeatAvailabilityConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            return Enum.GetName(typeof(SeatAvailability), value);
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            return Enum.Parse(typeof(SeatAvailability), value.ToString(), true);
        }
    }
}
