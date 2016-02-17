using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Windows;
using Telerik.Windows.Controls;
using Telerik.Windows.Controls.ScheduleView;
using Telerik.Windows.DragDrop.Behaviors;

namespace Telerik.Windows.Examples.ScheduleView.SchedulingAssistant
{
    public class CustomScheduleViewDragDropBehavior : Telerik.Windows.Controls.ScheduleViewDragDropBehavior
    {
        public override IEnumerable<IOccurrence> ConvertDraggedData(object data)
        {
            if (DataObjectHelper.GetDataPresent(data, typeof(Employee), false))
            {
                var employee = ((IEnumerable)DataObjectHelper.GetData(data, typeof(Employee), true)).Cast<Employee>().First() as Employee;

                if (employee != null)
                {
                    var appointment = new SupportMeetingAppointment { IsDraggedFromListBox = true };
                    appointment.Attendees.Add(employee);
                    return new List<SupportMeetingAppointment>() { appointment };
                }
            }

            return base.ConvertDraggedData(data);
        }

        public override bool CanStartDrag(Controls.DragDropState state)
        {
            var appointment = state.Appointment as SupportMeetingAppointment;

            if (appointment == null)
            {
                // should be recurring Appointment
                appointment = (state.Appointment as Occurrence).Appointment as SupportMeetingAppointment;
            }

            var scheduleView = state.ServiceProvider.GetService<IDialogProvider>() as RadScheduleView;
            scheduleView.BeginEdit(appointment);
            appointment.SourceResource = state.SourceResources.First().DisplayName;
            scheduleView.Commit();

            return base.CanStartDrag(state);
        }

        public override bool CanDrop(Controls.DragDropState state)
        {
            var appointment = state.Appointment as SupportMeetingAppointment;

            if (appointment == null)
            {
                // should be recurring Appointment
                appointment = (state.Appointment as Occurrence).Appointment as SupportMeetingAppointment;
            }

            if (appointment.IsDraggedFromListBox && state.TargetedAppointment != null)
            {
                var targetedAppointment = state.TargetedAppointment as SupportMeetingAppointment;
                var attendee = appointment.Attendees.First();
                if (targetedAppointment.Attendees.Contains(attendee))
                {
                    return false;
                }
                else
                {
                    return true;
                }
            }
            else if (appointment.IsDraggedFromListBox)
            {
                return false;
            }
            else
            {
                return base.CanDrop(state);
            }
        }

        public override void Drop(Controls.DragDropState state)
        {
            var appointment = state.Appointment as SupportMeetingAppointment;

            if (appointment == null)
            {
                // should be recurring Appointment
                appointment = (state.Appointment as Occurrence).Appointment as SupportMeetingAppointment;
            }

            var scheduleView = state.ServiceProvider.GetService<IDialogProvider>() as RadScheduleView;

            if (appointment.IsDraggedFromListBox && state.TargetedAppointment != null)
            {
                var targetedAppointment = state.TargetedAppointment as SupportMeetingAppointment;
                var attendee = appointment.Attendees.First();
                if (!targetedAppointment.Attendees.Contains(attendee))
                {
                    if (targetedAppointment.Attendees.Count > 3)
                    {
                        var alertText = "No more space for this meeting. \r\nPlease remove one of the attendees from the appointment dialog!";
#if SILVERLIGHT
                        Deployment.Current.Dispatcher.BeginInvoke(() => RadWindow.Alert(alertText));
#else
                        Application.Current.Dispatcher.BeginInvoke(new Action(() => RadWindow.Alert(alertText)));
#endif
                    }
                    else
                    {
                        scheduleView.BeginEdit(targetedAppointment);
                        targetedAppointment.Attendees.Add(attendee);
                        scheduleView.Commit();
                    }
                }
                
            }
            else if (appointment.Resources.Count > 1 && !appointment.Resources.Contains(state.DestinationSlots.First().Resources.First()))
            {
                scheduleView.BeginEdit(appointment);
                appointment.Resources.Remove(state.SourceResources.First());
                appointment.Resources.Add(state.DestinationSlots.First().Resources.First() as Resource);
                scheduleView.Commit();
            }
            else
            {
                base.Drop(state);
            }
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