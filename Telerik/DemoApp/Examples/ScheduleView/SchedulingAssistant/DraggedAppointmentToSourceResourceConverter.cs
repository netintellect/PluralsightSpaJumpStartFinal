using System;
using System.Collections;
using System.Linq;
using System.Windows.Data;
using Telerik.Windows.Controls.ScheduleView;

namespace Telerik.Windows.Examples.ScheduleView.SchedulingAssistant
{
    public class DraggedAppointmentToSourceResourceConverter: IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
        {
            var draggedAppointment = ((IList)value)[0];

            if (draggedAppointment is Occurrence)
            {
                draggedAppointment = (draggedAppointment as Occurrence).Appointment;
            }

            if (draggedAppointment != null)
            {
                return "Dragged from: " + (draggedAppointment as SupportMeetingAppointment).SourceResource;
            }

            return null;
        }

        public object ConvertBack(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}
