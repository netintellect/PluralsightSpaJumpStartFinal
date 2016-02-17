using System;
using System.Windows.Data;
using Telerik.Windows.Controls;

namespace Telerik.Windows.Examples.ScheduleView.TimeBar
{
	public class VisibleDaysConverter : IValueConverter
	{
		public object Convert(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
		{
			SelectionRange<DateTime> selection = (SelectionRange<DateTime>)value;
			return selection.End.Subtract(selection.Start).TotalDays;
		}

		public object ConvertBack(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
		{
			throw new NotImplementedException();
		}
	}
}
