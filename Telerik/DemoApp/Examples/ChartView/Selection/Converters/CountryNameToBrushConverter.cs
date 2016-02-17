using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Data;
using System.Windows.Media;
using Telerik.Windows.Examples.ChartView.Selection.Utilities;

namespace Telerik.Windows.Examples.ChartView.Selection.Converters
{
    public class CountryNameToBrushConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
        {
            string countryName = (string)value;
            return CountryUtilities.GetBrush(countryName);
        }

        public object ConvertBack(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}
