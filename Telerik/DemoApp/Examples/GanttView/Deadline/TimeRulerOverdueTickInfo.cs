using System;
using Telerik.Windows.Controls.Scheduling;
using Telerik.Windows.Core;

namespace Telerik.Windows.Examples.GanttView.Deadline
{
	public class TimeRulerOverdueTickInfo : IEventInfo, ICellCoordinates, IEquatable<TimeRulerOverdueTickInfo>
	{
		private Range<long> timeRange;
		private GanttDeadlineTask task;

		public TimeRulerOverdueTickInfo(DateTime deadline, GanttDeadlineTask task)
		{
			this.timeRange = new Range<long>(deadline.Ticks);
			this.task = task;
		}

		public Range<long> TimeRange
		{
			get { return this.timeRange; }
		}

        public GanttDeadlineTask Task
        {
            get { return this.task; }
        }

		public Range<int> CellCoordinates
		{
			get { return new Range<int>(3); }
		}

		public double Overdue
		{
			get
			{
				return this.task.Overdue;
			}
		}

		public override bool Equals(object obj)
		{
			return this.Equals(obj as TimeRulerOverdueTickInfo);
		}

		public override int GetHashCode()
		{
			return this.timeRange.GetHashCode();
		}

		public bool Equals(TimeRulerOverdueTickInfo other)
		{
			return other != null && this.timeRange == other.timeRange && this.task == other.task;
		}
	}
}
