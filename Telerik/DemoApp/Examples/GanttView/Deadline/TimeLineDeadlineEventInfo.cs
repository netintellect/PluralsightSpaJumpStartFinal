using System;
using Telerik.Windows.Controls.Scheduling;
using Telerik.Windows.Core;
using Telerik.Windows.Core.Internal;

namespace Telerik.Windows.Examples.GanttView.Deadline
{
	public class TimeLineDeadlineEventInfo : SlotInfo
	{
		private GanttDeadlineTask task;

		public TimeLineDeadlineEventInfo(Range<long> timeRange, int index, GanttDeadlineTask task)
			: base(timeRange, index, index)
		{
			this.task = task;
		}

		public string Deadline
		{
			get
			{
				return this.task.GanttDeadLine.Value.ToShortDateString();
			}
		}

		public bool IsExpired
		{
			get
			{
				return this.task.IsExpired;
			}
		}

		public override bool Equals(object obj)
		{
			return this.Equals(obj as TimeLineDeadlineEventInfo);
		}

		public override int GetHashCode()
		{
			return base.GetHashCode();
		}
	}
}
