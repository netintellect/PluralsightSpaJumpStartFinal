using System;
using System.Windows.Data;
using Telerik.Windows.Controls.ScheduleView;

namespace Telerik.Windows.Examples.ScheduleView.ScheduleViewConfigurator
{
	public class TickConverter : IValueConverter
	{
		public object Convert(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
		{
			FixedTickProvider provider = value as FixedTickProvider;

			if (provider != null)
			{
				string interval = string.Format("{0:d2}:{1:d2}:00", provider.Interval.Hours, provider.Interval.Minutes);
				if (provider.Interval.Hours == 0 && provider.Interval.Minutes == 0)
				{
					if (provider.Interval.Days == 1)
					{
						interval = "1 day";
					}
					else
					{
						interval = string.Format("{0} days", provider.Interval.Days);
					}
				}
				return interval;
			}
			return "Automatic conversion";
		}

		public object ConvertBack(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
		{
			throw new NotImplementedException();
		}
	}
}