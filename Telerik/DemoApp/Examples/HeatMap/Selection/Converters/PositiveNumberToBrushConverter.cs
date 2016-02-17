using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Data;
using Telerik.Windows.Controls.Map;
using System.Windows.Media;
using System.Globalization;

namespace Telerik.Windows.Examples.HeatMap.Selection.Converters
{
    public class PositiveNumberToBrushConverter : IValueConverter
    {
        public Brush PositiveBrush { get; set; }
        public Brush NegativeBrush { get; set; }

        public object Convert(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
        {
            double doubleValue;
            if (double.TryParse("" + value, NumberStyles.Float, CultureInfo.InvariantCulture, out doubleValue) &&
                doubleValue < 0)
            {
                return this.NegativeBrush;
            }

            return this.PositiveBrush;
        }

        public object ConvertBack(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
        {
            return null;
        }
    }
}
