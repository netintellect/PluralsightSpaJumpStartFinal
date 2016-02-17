using System;
using System.Windows.Data;

namespace Telerik.Windows.Examples.PivotGrid.CustomHeaderTemplate
{
    public class ProductToImageConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
        {
            string product = System.Convert.ToString(value);
            return string.Format("/PivotGrid;component/Icons/{0}.png", product);
        }

        public object ConvertBack(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}
