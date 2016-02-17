using System;
using System.Globalization;
using System.Windows.Data;
using System.Windows.Media;

namespace Telerik.Windows.Examples.ChartView.PieSmartLabels
{
#if WPF
    [ValueConversion(typeof(string), typeof(Brush))]
#endif
    public class SubregionToConnectorBrushConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            Subregion subregion = value as Subregion;
            if (subregion != null)
            {
                return RegionBrushUtils.GetBrush(subregion.ColorRegionName);
            }

            return new SolidColorBrush(Colors.Transparent);
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}
