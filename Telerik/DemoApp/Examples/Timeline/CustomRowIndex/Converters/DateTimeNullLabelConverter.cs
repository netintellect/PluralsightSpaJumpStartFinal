using System;
using System.Windows.Data;

namespace Telerik.Windows.Examples.Timeline.CustomRowIndex
{
    public class DateTimeLabelConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
        {
            DateTime date = (DateTime)value;
            if (date == DateTime.MinValue || date == DateTime.MaxValue)
            {
                return string.Empty;
            }
            else
            {
                return date.ToString("MMMM dd, yyy");
            }
        }

        public object ConvertBack(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}
