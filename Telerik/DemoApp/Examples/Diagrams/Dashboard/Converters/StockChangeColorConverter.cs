using System;
using System.Globalization;
using System.Windows.Data;
using System.Windows.Media;
using Telerik.Windows.Diagrams.Core;

namespace Telerik.Windows.Examples.Diagrams.Dashboard
{
	public sealed class StockChangeColorConverter : IValueConverter
	{
		public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
		{
			if (value == null)
				return KnownBrushes.DimGray;
			var val = DataProvider.GetDecimal(value.ToString());
			if (val != null)
				return val > 50 ? new SolidColorBrush(Colors.Orange) : new SolidColorBrush(Colors.Green);
			return KnownBrushes.DimGray;
		}

		public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
		{
			throw new NotImplementedException();
		}
	}
}