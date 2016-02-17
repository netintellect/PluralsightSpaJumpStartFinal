using System.Collections;
using System.Collections.Generic;
using System.Linq;
using Telerik.Windows.Controls.ScheduleView;
using Telerik.Windows.DragDrop.Behaviors;

namespace Telerik.Windows.Examples.ScheduleView.DragDrop
{
	public class ScheduleViewDragDropBehavior : Telerik.Windows.Controls.ScheduleViewDragDropBehavior
	{
		public override IEnumerable<IOccurrence> ConvertDraggedData(object data)
		{
			if (DataObjectHelper.GetDataPresent(data, typeof(Appointment), false))
			{
				return ((IEnumerable)DataObjectHelper.GetData(data, typeof(Appointment), false)).OfType<IOccurrence>();
			}
			return base.ConvertDraggedData(data);
		}
	}
}