using Telerik.Windows.Controls.Scheduling;

namespace Telerik.Windows.Examples.GanttView.GanttTimeline
{
	public class CustomResizeBehavior : SchedulingResizeBehavior
	{
		protected override bool CanResize(SchedulingResizeState state)
		{
			return false;
		}

		protected override bool CanStartResize(SchedulingResizeState state)
		{
			return false;
		}
	}
}
