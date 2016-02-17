using System;
using System.Globalization;
using Telerik.Windows.Controls.Scheduling;

namespace Telerik.Windows.Examples.GanttView.Deadline
{
	public class CustomTickInterval : TickIntervalBase
	{
		public TimeRulerTickInterval Interval
		{
			get { return TimeRulerTickInterval.OneYear; }
		}

		public string FormatString
		{
			get { return string.Empty; }
		}

		protected override string FormatValue(Telerik.Windows.Core.Range<long> timeRange)
		{
			var formatString = this.FormatString ?? DefaultTickProvider.GetFormatString(this.Interval);

			var formatInfo = CultureInfo.CurrentUICulture.DateTimeFormat;

			var dateTime = new DateTime(timeRange.Start);

			var weekNumber = formatInfo.Calendar.GetWeekOfYear(dateTime, formatInfo.CalendarWeekRule, formatInfo.FirstDayOfWeek);

			return string.Format(formatInfo, formatString, dateTime, weekNumber);

			return "";
		}

		public override long GetAverageLength()
		{
			return TimeSpan.TicksPerMillisecond;
		}

		protected override DateTime GetFirst(DateTime dateTime, DayOfWeek firstDayOfWeek)
		{
			return new DateTime(dateTime.Year, dateTime.Month, dateTime.Day, dateTime.Hour, dateTime.Minute, dateTime.Second, dateTime.Millisecond);
		}

		protected override DateTime GetNext(DateTime dateTime)
		{
			return DateTime.MaxValue;
		}
	}
}
