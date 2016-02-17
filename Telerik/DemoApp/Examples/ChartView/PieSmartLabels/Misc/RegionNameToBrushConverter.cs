using System;
using System.Globalization;
using System.Windows.Data;
using System.Windows.Media;

namespace Telerik.Windows.Examples.ChartView.PieSmartLabels
{
#if WPF
    [ValueConversion(typeof(string), typeof(Brush))]
#endif
    public class RegionNameToBrushConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            return RegionBrushUtils.GetBrush((string)value);
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}
