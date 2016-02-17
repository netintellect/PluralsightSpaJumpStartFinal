using System;
using Telerik.Windows.Controls.Scheduling;
using Telerik.Windows.Core;

namespace Telerik.Windows.Examples.GanttView.Programming.CustomTickInterval
{
	public class QuarterlyInterval : TickIntervalBase
	{
		public override long GetAverageLength()
		{
			return TimeSpan.TicksPerDay * 30 /*days*/ * 3 /*months*/;
		}

		protected override DateTime GetFirst(DateTime dateTime, DayOfWeek firstDayOfWeek)
		{
			return new DateTime(dateTime.Year, GetQ(dateTime) * 3 + 1, 1);
		}

		private int GetQ(DateTime dateTime)
		{
			return (dateTime.Month - 1) / 3;
		}

		protected override DateTime GetNext(DateTime dateTime)
		{
			var month = dateTime.Month + 3;
			return new DateTime(month > 12 ? dateTime.Year + 1 : dateTime.Year, month > 12 ? 1 : month, 1);
		}

		protected override string FormatValue(Range<long> timeRange)
		{
			var dateTime = new DateTime(timeRange.Start);

			return string.Format("Q{0} {1}", GetQ(dateTime) + 1, dateTime.Year);
		}
	}
}