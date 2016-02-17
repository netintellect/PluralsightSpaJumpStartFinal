using System.Windows;
using Telerik.Windows.Controls.GanttView;
using Telerik.Windows.Controls.Scheduling;

namespace Telerik.Windows.Examples.GanttView.Programming.LockingFunctions
{
	public class CustomDragDependenciesBehavior : GanttDragDependenciesBehavior
	{
		protected override bool CanStartLink(SchedulingLinkState state)
		{
			if (!base.CanStartLink(state))
			{
				return false;
			}

			return !((LockingTask)state.LinkSourceItem).AreDependenciesLocked;
		}

		protected override bool CanLink(SchedulingLinkState state)
		{
			if (!base.CanLink(state))
			{
				return false;
			}
			return !((LockingTask)state.TargetElementGroupKey).AreDependenciesLocked;
		}
	}
}
