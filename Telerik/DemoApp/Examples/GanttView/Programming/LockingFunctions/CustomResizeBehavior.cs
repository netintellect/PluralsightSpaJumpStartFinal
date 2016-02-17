using Telerik.Windows.Controls.Scheduling;

namespace Telerik.Windows.Examples.GanttView.Programming.LockingFunctions
{
	public class CustomResizeBehavior : SchedulingResizeBehavior
	{
		protected override bool CanStartResize(SchedulingResizeState state)
		{
			if (!base.CanStartResize(state))
			{
				return false;
			}

			return !((LockingTask)state.ResizedItem).IsResizeLocked;
		}
	}
}
