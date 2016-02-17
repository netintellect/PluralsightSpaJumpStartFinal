using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Windows;
using Telerik.Windows.Controls.ScheduleView;
using Telerik.Windows.Controls.Scheduling;
using Telerik.Windows.DragDrop.Behaviors;


namespace Telerik.Windows.Examples.GanttView.TaskPlanner
{
	public class ScheduleViewDragDropBehavior : Telerik.Windows.Controls.ScheduleViewDragDropBehavior
	{
		public override IEnumerable<Controls.ScheduleView.IOccurrence> ConvertDraggedData(object data)
		{
			if (data is IDataObject)
			{
				return Enumerable.Empty<IOccurrence>();
			}

			return base.ConvertDraggedData(data);
		}

        public override void DragDropCompleted(Controls.DragDropState state)
        {
            if (state.DestinationAppointmentsSource != null)
            {
                base.DragDropCompleted(state);
            }
        }
	}
}
