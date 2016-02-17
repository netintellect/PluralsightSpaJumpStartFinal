using System;
using System.Collections;
using Telerik.Windows.Controls.Scheduling;
using System.Collections.Generic;
using Telerik.Windows.Core;

namespace Telerik.Windows.Examples.GanttView.Deadline
{
	public class TimeRulerDeadlineBehavior : DefaultTimeRulerVisualizationBehavior
	{
		public override IEnumerable GetVisibleItems(TimeRulerVisualizationState state)
		{
			foreach (var item in base.GetVisibleItems(state))
			{
				yield return item;
			}

			var visibleItems = state.VisibleItems as IEnumerable<HierarchicalItem>;

			foreach (var item in visibleItems)
			{
				var task = item.SourceItem as GanttDeadlineTask;
				if (task != null && task.GanttDeadLine.HasValue && task.GanttDeadLine.Value.Subtract(task.End).TotalHours < 0)
				{
					yield return new TimeRulerOverdueTickInfo(task.GanttDeadLine.Value, task);
				}
			}

			yield return new TimeRulerAlternatingInfo(state.VisibleRange);
		}

		public event EventHandler DataChanged;
	}
}
