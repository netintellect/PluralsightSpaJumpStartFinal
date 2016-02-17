using System;
using Telerik.Windows.Controls.Scheduling;
using Telerik.Windows.Core;
using Telerik.Windows.Core.Internal;

namespace Telerik.Windows.Examples.GanttView.Deadline
{
	public class ProjectDeadlineEventInfo : IEventInfo, IGroupCellCoordinates, IEquatable<ProjectDeadlineEventInfo>
	{
		public ProjectDeadlineEventInfo(Range<long> timeRange, int startIndex, int endIndex)
		{
			this.TimeRange = timeRange;
			this.CellCoordinates = new Range<int>(startIndex, endIndex);
		}

		public Range<long> TimeRange { get; private set; }
		public Range<int> CellCoordinates { get; private set; }

		public override bool Equals(object obj)
		{
			return base.Equals(obj as ProjectDeadlineEventInfo);
		}

		public bool Equals(ProjectDeadlineEventInfo other)
		{
			return other != null && this.TimeRange == other.TimeRange && this.CellCoordinates == other.CellCoordinates;
		}

		public override int GetHashCode()
		{
			return base.GetHashCode();
		}
	}
}
