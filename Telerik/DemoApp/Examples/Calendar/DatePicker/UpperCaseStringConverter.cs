using System;
using System.Windows.Data;

namespace Telerik.Windows.Examples.Calendar.DatePicker
{
    public class UpperCaseStringConverter : IValueConverter
    {

        public object Convert(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
        {
            string currentString = (string)value.ToString();
            return currentString.ToUpper();
        }

        public object ConvertBack(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}
