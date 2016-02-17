using System;
using System.Windows;
using Telerik.Windows.Controls;
using Telerik.Windows.Controls.ScheduleView;

namespace Telerik.Windows.Examples.ScheduleView.CustomStyles.CustomAppointmentHeight
{
    public class AppointmentStyleSelector : OrientedAppointmentItemStyleSelector
    {
        public Style SmallAppointmentStyle { get; set; }
        public Style RegularAppointmentStyle { get; set; }
        public Style BigAppointmentStyle { get; set; }
        public override Style SelectStyle(object item, DependencyObject container, ViewDefinitionBase activeViewDefinition)
        {
            var appointment = item as Appointment;
            if (appointment != null)
            {
                if (appointment.IsAllDayEvent)
                {
                    return this.BigAppointmentStyle;
                }
                else if (appointment.Duration() <= new TimeSpan(1, 0, 0))
                {
                    return this.SmallAppointmentStyle;
                }
                else if (appointment.Duration() <= new TimeSpan(2, 0, 0))
                {
                    return this.RegularAppointmentStyle;
                }
                else if (appointment.Duration() > new TimeSpan(2, 0, 0))
                {
                    return this.BigAppointmentStyle;
                }
            }

            return base.SelectStyle(item, container, activeViewDefinition);
        }
    }
}