using System.Globalization;
using System;
using System.Windows.Data;

namespace Telerik.Windows.Examples.DataServiceDataSource.LoadDelay
{
	public class MillisecondsToTimeSpanConverter : IValueConverter
	{
		public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
		{
			double milliseconds = (double)value;
			return TimeSpan.FromMilliseconds(milliseconds);
		}

		public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
		{
			TimeSpan timeSpan = (TimeSpan)value;
			return timeSpan.TotalMilliseconds;
		}
	}
}
