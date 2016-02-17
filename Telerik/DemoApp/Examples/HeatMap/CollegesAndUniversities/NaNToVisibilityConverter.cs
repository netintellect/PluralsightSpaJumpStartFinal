using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Data;
using System.Windows;

namespace Telerik.Windows.Examples.HeatMap.CollegesAndUniversities
{
    public class NaNToVisibilityConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
        {
            bool negate = parameter as string == "Negate";

            if (value is double && double.IsNaN((double)value))
                return negate ? Visibility.Visible : Visibility.Collapsed;
            else
                return negate ? Visibility.Collapsed : Visibility.Visible;
        }

        public object ConvertBack(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}
