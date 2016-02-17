using System;
using System.Windows.Data;

namespace Telerik.Windows.Examples.ChartView.Gallery.Range.Converters
{
	public class SeriesTypeConverter : IValueConverter
	{
		public object Convert(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
		{
            string seriesString = (string)value;

            if (seriesString.Contains("Bar"))
            {
                return "Bar";
            }
            else if (seriesString.Contains("Spline"))
            {
                return "SplineArea";
            }
            else
            {
                return "Area";
            }
		}

		public object ConvertBack(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
		{
			throw new NotImplementedException();
		}
	}
}
