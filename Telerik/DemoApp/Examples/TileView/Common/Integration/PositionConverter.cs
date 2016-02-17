using System;
using System.Windows.Data;

namespace Telerik.Windows.Examples.TileView.Common
{
	public class PositionConverter : IValueConverter
	{
		public object Convert(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
		{
			return (int)value - 1;
		}

		public object ConvertBack(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
		{
			return (int)value + 1;
		}
	}
}
