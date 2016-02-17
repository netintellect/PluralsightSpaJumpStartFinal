using System;
using System.Windows.Data;

namespace Telerik.Windows.Examples.ScheduleView.ScheduleViewConfigurator
{
	public class DateTimeToTimeSpanConverter : IValueConverter
	{
		public object Convert(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
		{
			TimeSpan time = (TimeSpan)value;
			DateTime date = DateTime.Today;
			date = date.AddHours(time.Hours);
			date = date.AddMinutes(time.Minutes);
			return date;
		}

		public object ConvertBack(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
		{
			DateTime? dateTime = (DateTime?)value;
			TimeSpan time;
			if (dateTime.HasValue)
			{
				time = new TimeSpan(dateTime.Value.Hour, dateTime.Value.Minute, 0);
				return time;
			}
			return null;
		}
	}
}
