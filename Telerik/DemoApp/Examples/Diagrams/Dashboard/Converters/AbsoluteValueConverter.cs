using System;
using System.Globalization;
using System.Windows.Data;

namespace Telerik.Windows.Examples.Diagrams.Dashboard
{
	public sealed class AbsoluteValueConverter : IValueConverter
	{
		public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
		{
			if (value == null)
				return 0d;
			var val = DataProvider.GetDecimal(value.ToString());
			if (val != null)
				return Math.Abs(val.Value);
			return 0d;
		}

		public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
		{
			throw new NotImplementedException();
		}
	}
}