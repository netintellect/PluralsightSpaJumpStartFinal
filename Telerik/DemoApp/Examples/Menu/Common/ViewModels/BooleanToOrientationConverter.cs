using System;
using System.Globalization;
using System.Windows.Controls;
using System.Windows.Data;

namespace Examples.Menu.Common
{
	public class BooleanToOrientationConverter : IValueConverter
	{
		public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
		{
			return ((bool)value) ? Orientation.Horizontal : Orientation.Vertical;
		}

		public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
		{
			throw new NotImplementedException();
		}
	}
}