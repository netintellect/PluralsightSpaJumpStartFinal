using System;
using System.Collections;
using System.Collections.Generic;
using Telerik.Windows.Controls;
using Telerik.Windows.Controls.GanttView;
using Telerik.Windows.Controls.Scheduling;
using Telerik.Windows.Core;

namespace Telerik.Windows.Examples.GanttView.Deadline
{
	public class TimeLineDeadlineBehavior : DefaultGanttTimeLineVisualizationBehavior
	{
		private DateTime projectDeadLine;

		public TimeLineDeadlineBehavior(DateTime deadLine)
		{
			this.projectDeadLine = deadLine;
		}

		protected override IEnumerable<IEventInfo> GetEventInfos(TimeLineVisualizationState state, HierarchicalItem hierarchicalItem)
		{
			foreach (var eventInfo in base.GetEventInfos(state, hierarchicalItem))
			{
				yield return eventInfo;
			}

			var task = hierarchicalItem.SourceItem as GanttDeadlineTask;
			var deadline = task != null ? task.GanttDeadLine : default(DateTime?);

			if (deadline.HasValue)
			{
				if (task.GanttDeadLine.HasValue && projectDeadLine < task.GanttDeadLine.Value)
				{
					deadline = task.GanttDeadLine = projectDeadLine;
					task.Refresh();
				}

				var roundedDeadline = state.Rounder.Round(new DateRange(deadline.Value, deadline.Value));
				var deadlineRange = new Range<long>(roundedDeadline.Start.Ticks, roundedDeadline.End.Ticks);

				if (deadlineRange.IntersectsWith(state.VisibleTimeRange))
				{
					yield return new TimeLineDeadlineEventInfo(deadlineRange, hierarchicalItem.Index, hierarchicalItem.SourceItem as GanttDeadlineTask);
				}
			}

			yield return new ProjectDeadlineEventInfo(new Range<long>(this.projectDeadLine.Ticks), 0, state.VisibleItems.Count - 1);
		}
	}
}
