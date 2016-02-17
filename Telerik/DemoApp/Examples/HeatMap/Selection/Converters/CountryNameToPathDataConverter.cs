using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Data;
using Telerik.Windows.Controls.Map;
using Telerik.Windows.Examples.HeatMap.Selection.ViewModels;

namespace Telerik.Windows.Examples.HeatMap.Selection.Converters
{
    public class CountryNameToPathDataConverter : IValueConverter
    {
        private List<CountryShape> countryShapes = new List<CountryShape>();
        public List<CountryShape> CountryShapes { get { return this.countryShapes; } }

        public object Convert(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
        {
            string countryName = value as string;
            CountryShape countryShape = null;
            if (countryName != null)
            {
                countryShape = this.CountryShapes.FirstOrDefault(c => c.CountryName == countryName);
            }

            return countryShape != null ? countryShape.Data : null;
        }

        public object ConvertBack(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
        {
            return null;
        }
    }
}
