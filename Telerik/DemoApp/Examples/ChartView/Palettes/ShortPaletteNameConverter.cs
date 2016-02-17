using System;
using System.Windows.Data;

namespace Telerik.Windows.Examples.ChartView.Palettes
{
    public class ShortPaletteNameConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
        {
            return "VisualStudio2013" == (string)value ? "VS2013" : value;
        }

        public object ConvertBack(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}
