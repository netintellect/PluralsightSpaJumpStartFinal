using System;
using Telerik.Windows.Controls;

namespace Telerik.Windows.Examples.GanttView
{
	public class CurrentWeekVisibleRange : IDateRange
	{
		public DateTime End
		{
			get
			{
				return this.Start.AddDays(7);
			}
			set
			{
			}
		}

		public DateTime Start
		{
			get
			{
				return GetFirstDayOfWeek(DateTime.Now, DayOfWeek.Monday);
			}
			set
			{
			}
		}

		private const int DaysInWeek = 7;

		private static DateTime GetFirstDayOfWeek(DateTime dateTime, DayOfWeek weekStart)
		{
			var selectedDay = (int)dateTime.DayOfWeek;
			if (selectedDay < (int)weekStart)
			{
				selectedDay += DaysInWeek;
			}

			int daysToSubtract = selectedDay - (int)weekStart;
			var result = dateTime.Subtract(TimeSpan.FromDays(daysToSubtract));
			return result.Date;
		}
	}
}