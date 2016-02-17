using System;
using System.Collections.ObjectModel;
using Telerik.Windows.Controls;
using Telerik.Windows.Controls.ScheduleView;

namespace Telerik.Windows.Examples.ScheduleView.CustomStyles.CustomAppointmentHeight
{
	public class ViewModel : ViewModelBase
	{
        private DateTime startingDate;

        public ViewModel()
        {
            this.startingDate = this.FindFirstMondayFromCurrentMonth();
            this.Appointments = GenerateAppointments();
        }

        public ObservableCollection<Appointment> Appointments { get; set; }

        private ObservableCollection<Appointment> GenerateAppointments()
        {
            var appointments = new ObservableCollection<Appointment>();

            appointments.Add(new Appointment { Start = this.startingDate.AddHours(9), End = this.startingDate.AddHours(10) });
            appointments.Add(new Appointment { Start = this.startingDate.AddHours(10), End = this.startingDate.AddHours(12) });
            appointments.Add(new Appointment { Start = this.startingDate.AddHours(12), End = this.startingDate.AddHours(18) });
            appointments.Add(new Appointment { Start = this.startingDate.AddDays(1).AddHours(9), End = this.startingDate.AddDays(1).AddHours(10) });
            appointments.Add(new Appointment { Start = this.startingDate.AddDays(2).AddHours(10), End = this.startingDate.AddDays(2).AddHours(12) });
            appointments.Add(new Appointment { Start = this.startingDate.AddDays(3).AddHours(12), End = this.startingDate.AddDays(3).AddHours(18) });
            appointments.Add(new Appointment { Start = this.startingDate.AddDays(4).AddHours(10), End = this.startingDate.AddDays(4).AddHours(12) });
            appointments.Add(new Appointment { Start = this.startingDate.AddDays(4).AddHours(12), End = this.startingDate.AddDays(4).AddHours(18) });
            
            this.startingDate = this.startingDate.AddDays(7);

            appointments.Add(new Appointment { Start = this.startingDate.AddHours(12), End = this.startingDate.AddHours(18) });
            appointments.Add(new Appointment { Start = this.startingDate.AddHours(12), End = this.startingDate.AddHours(14) });
            appointments.Add(new Appointment { Start = this.startingDate.AddHours(14), End = this.startingDate.AddHours(15) });
            appointments.Add(new Appointment { Start = this.startingDate.AddDays(1).AddHours(12), End = this.startingDate.AddDays(1).AddHours(14) });
            appointments.Add(new Appointment { Start = this.startingDate.AddDays(2).AddHours(12), End = this.startingDate.AddDays(2).AddHours(13) });
            appointments.Add(new Appointment { Start = this.startingDate.AddDays(2).AddHours(13), End = this.startingDate.AddDays(2).AddHours(17) });
            appointments.Add(new Appointment { Start = this.startingDate.AddDays(3).AddHours(09), End = this.startingDate.AddDays(3).AddHours(10) }); 
            appointments.Add(new Appointment { Start = this.startingDate.AddDays(3).AddHours(10), End = this.startingDate.AddDays(3).AddHours(12) });
            appointments.Add(new Appointment { Start = this.startingDate.AddDays(3).AddHours(12), End = this.startingDate.AddDays(3).AddHours(13) });
            appointments.Add(new Appointment { Start = this.startingDate.AddDays(4).AddHours(9), End = this.startingDate.AddDays(4).AddHours(13) });
            appointments.Add(new Appointment { Start = this.startingDate.AddDays(4).AddHours(13), End = this.startingDate.AddDays(4).AddHours(14) });

            this.SetSubjects(appointments);

            return appointments;
        }

        private DateTime FindFirstMondayFromCurrentMonth()
        {
            DateTime currentDay = new DateTime(DateTime.Now.Year, DateTime.Now.Month, 1);

            while(currentDay.DayOfWeek != DayOfWeek.Monday)
            {
                currentDay = currentDay.AddDays(1);
            }

            return currentDay;
        }

        private void SetSubjects(ObservableCollection<Appointment> appointments)
        {
            for (int i = 0; i < appointments.Count; i++)
            {
                if (appointments[i].Duration() <= new TimeSpan(1,0,0))
                {
                    appointments[i].Subject = "Small Appointment";
                }
                else if (appointments[i].Duration() <= new TimeSpan(2,0,0))
                {
                    appointments[i].Subject = "Regular Appointment";
                }
                else if (appointments[i].Duration() > new TimeSpan(2, 0, 0))
                {
                    appointments[i].Subject = "Big Appointment";
                }
            }
        }
	}
}