using System;
using System.Globalization;
using System.Windows.Data;
using Telerik.Windows.Controls;

namespace Telerik.Windows.Examples.ScheduleView.TimeBar
{
	public class TimeMarkerToIconConverter : IValueConverter
	{
		public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
		{
			TimeMarker tm = value as TimeMarker;
			if (tm != null)
			{
				if (tm.TimeMarkerName == "Normal")
				{
					return "/ScheduleView;component/Images/ScheduleView/TimeBar/Normal.png";
				}
				else if (tm.TimeMarkerName == "High")
				{
					return "/ScheduleView;component/Images/ScheduleView/TimeBar/HighPriority.png";
				}
			}
			return null;
		}
		public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
		{
			throw new NotImplementedException();
		}
	}
}
