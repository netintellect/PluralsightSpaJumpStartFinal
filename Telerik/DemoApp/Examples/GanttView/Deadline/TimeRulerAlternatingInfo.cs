using Telerik.Windows.Controls.Scheduling;
using Telerik.Windows.Core;

namespace Telerik.Windows.Examples.GanttView.Deadline
{
	public class TimeRulerAlternatingInfo : IEventInfo, ICellCoordinates
	{
		private Range<long> timeRange;

		public TimeRulerAlternatingInfo(Range<long> timeRange)
		{
			this.timeRange = timeRange;
		}

		public Range<long> TimeRange
		{
			get { return this.timeRange; }
		}

		public Range<int> CellCoordinates
		{
			get { return new Range<int>(3); }
		}
	}
}
