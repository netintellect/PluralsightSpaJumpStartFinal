using Telerik.Windows.Controls.GanttView;
using Telerik.Windows.Controls.Scheduling;

namespace Telerik.Windows.Examples.GanttView.Programming.LockingFunctions
{
	public class CustomDragDropBehavior : GanttDragDropBehavior
	{
		protected override bool CanStartDrag(SchedulingDragDropState state)
		{
			if (!base.CanStartDrag(state))
			{
				return false;
			}

			if (state.IsReorderOperation)
			{
				return !((LockingTask)state.DraggedItem).IsDragReorderLocked;
			}
			return !((LockingTask)state.DraggedItem).IsDragDropLocked;
		}
	}
}
