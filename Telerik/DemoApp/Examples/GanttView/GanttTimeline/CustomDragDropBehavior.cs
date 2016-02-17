using Telerik.Windows.Controls.Scheduling;

namespace Telerik.Windows.Examples.GanttView.GanttTimeline
{
	public class CustomDragDropBehavior : SchedulingDragDropBehavior
	{
		protected override bool CanStartDrag(SchedulingDragDropState state)
		{
			return false;
		}

		protected override bool CanDrop(SchedulingDragDropState state)
		{
			return false;
		}
	}
}
