using System;
using System.Globalization;
using System.Windows.Data;
using Telerik.Windows.Controls;

namespace Telerik.Windows.Examples.ChartView.Gallery.Range.Converters
{
	public class TileStateToBoolConverter : IValueConverter
	{
		public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
		{
			return (TileViewItemState)value == TileViewItemState.Maximized;
		}

		public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
		{
			throw new NotImplementedException();
		}
	}
}
