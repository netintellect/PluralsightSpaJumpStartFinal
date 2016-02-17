using System;
using System.Globalization;
using System.Windows.Data;

namespace Telerik.Windows.Examples.Buttons.FirstLook.Common
{
    public class AvailabilityConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            if (value == null)
            {
                return false;
            }
            else
            {
                return true;
            }
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            // TODO: Implement this method
            throw new NotImplementedException();
        }
    }
}