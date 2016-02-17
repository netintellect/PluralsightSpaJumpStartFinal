using System;
using System.Windows.Data;
using System.Windows.Media;

namespace Telerik.Windows.Examples.GanttView.Deadline.Converters
{
	public class BoolToBrushConverter : IValueConverter
	{
		public object Convert(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
		{
			if (value is bool)
			{
				var isExpired = (bool)value;
				if (isExpired)
				{
					return new SolidColorBrush(Color.FromArgb(255,230,30,38));
				}
			}
			return new SolidColorBrush(Color.FromArgb(255, 48, 155, 70));
		}

		public object ConvertBack(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
		{
			throw new NotImplementedException();
		}
	}
}
