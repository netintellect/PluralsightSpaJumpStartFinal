using System;
using System.Windows;
using System.Windows.Data;

namespace Telerik.Windows.Examples.ChartView.Annotations
{
    public class VisibilityConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
        {
            int index = System.Convert.ToInt32(parameter);
            int selectedIndex = System.Convert.ToInt32(value);
            if (selectedIndex == index)
            {
                return Visibility.Visible;
            }
            return Visibility.Collapsed;
        }

        public object ConvertBack(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
        {
            throw new NotSupportedException();
        }
    }
}
