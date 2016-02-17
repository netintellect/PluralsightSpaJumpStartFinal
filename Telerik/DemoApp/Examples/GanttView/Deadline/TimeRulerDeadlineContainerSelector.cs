using Telerik.Windows.Controls.Scheduling;
using Telerik.Windows.Rendering;
using Telerik.Windows.Rendering.Virtualization;

namespace Telerik.Windows.Examples.GanttView.Deadline
{
	public class TimeRulerDeadlineContainerSelector : DefaultTimeRulerContainerSelector
	{
		protected static readonly ContainerTypeIdentifier TimeRulerDeadlineContainerType = ContainerTypeIdentifier.FromType<TimeRulerOverdueContainer>();
		protected static readonly ContainerTypeIdentifier TimeRulerAlternatingContainerType = ContainerTypeIdentifier.FromType<TimeRulerAlternatingContainer>();

		public override ContainerTypeIdentifier GetContainerType(object item)
		{
			if (item is TimeRulerOverdueTickInfo)
			{
				return TimeRulerDeadlineContainerType;
			}
			if (item is TimeRulerAlternatingInfo)
			{
				return TimeRulerAlternatingContainerType;
			}
			return base.GetContainerType(item);
		}
	}
}
