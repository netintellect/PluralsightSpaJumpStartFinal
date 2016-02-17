using Telerik.Windows.Controls.ScheduleView;
using Telerik.Windows.DragDrop.Behaviors;

namespace Telerik.Windows.Examples.ScheduleView.DragDrop
{
	public class AppointmentConverter : DataConverter
	{
		/// <summary>
		/// Returns a list of all formats that the data in this data object can be converted to.
		/// </summary>
		public override string[] GetConvertToFormats()
		{
			return new string[] { typeof(Appointment).AssemblyQualifiedName };
		}

		/// <summary>
		/// Retrieves a data object in a specified format; the data format is specified by a string.
		/// </summary>
		public override object ConvertTo(object data, string format)
		{
			if (DataObjectHelper.GetDataPresent(data, typeof(ScheduleViewDragDropPayload), false))
			{
				ScheduleViewDragDropPayload payload = (ScheduleViewDragDropPayload)DataObjectHelper.GetData(data, typeof(ScheduleViewDragDropPayload), false);
				if (payload != null)
				{
					return payload.DraggedAppointments;
				}
			}
			return null;
		}
	}
}