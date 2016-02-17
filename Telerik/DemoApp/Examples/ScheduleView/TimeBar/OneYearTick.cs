using System;
using Telerik.Windows.Controls.ScheduleView;

namespace Telerik.Windows.Examples.ScheduleView.TimeBar
{
	public class OneYearTick : ITickProvider
	{
		public string GetFormatString(IFormatProvider formatInfo, string formatString, DateTime currentStart)
		{
			return string.Empty;
		}
		public DateTime GetNextStart(TimeSpan pixelLength, DateTime currentStart)
		{
			return currentStart.AddYears(1);
		}
	}
}
