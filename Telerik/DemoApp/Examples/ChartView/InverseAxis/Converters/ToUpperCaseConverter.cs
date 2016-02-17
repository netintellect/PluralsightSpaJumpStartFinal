using System;
using System.Windows.Data;

namespace Telerik.Windows.Examples.ChartView.InverseAxis.Converters
{
	public class ToUpperCaseConverter : IValueConverter
	{
		public object Convert(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
		{
			return value.ToString().ToUpper();
		}

		public object ConvertBack(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
		{
			throw new NotImplementedException();
		}
	}
}
