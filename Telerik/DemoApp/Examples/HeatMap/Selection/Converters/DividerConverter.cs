using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Data;
using Telerik.Windows.Controls.Map;
using Telerik.Windows.Examples.HeatMap.Selection.ViewModels;
using System.Globalization;

namespace Telerik.Windows.Examples.HeatMap.Selection.Converters
{
    public class DividerConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
        {
            double divident;
            double divisor;
            if (double.TryParse("" + value, NumberStyles.Float, CultureInfo.InvariantCulture,  out divident) && 
                double.TryParse("" + parameter, NumberStyles.Float, CultureInfo.InvariantCulture, out divisor))
            {
                return divident / divisor;
            }

            return value;
        }

        public object ConvertBack(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
        {
            return value;
        }
    }
}
