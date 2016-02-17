using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Globalization;
using System.Linq;
using System.Windows;
using Telerik.Windows.Controls;
using Telerik.Windows.Controls.ScheduleView;
using Telerik.Windows.Examples.ScheduleView.Common;

namespace Telerik.Windows.Examples.ScheduleView
{
	public class ExampleViewModel<T> : ViewModelBase where T : IAppointment
	{
		private Uri appointmentsSource;
		private ObservableCollection<T> appointments;

		public Uri AppointmentsSource
		{
			get { return this.appointmentsSource; }
			set { this.appointmentsSource = value; }
		}

		public ObservableCollection<T> Appointments
		{
			get
			{
				if (this.appointments == null)
				{
					this.appointments = new ObservableCollection<T>(LoadAppointmentsSource(this.AppointmentsSource));
				}
				return this.appointments;
			}
		}

		protected static IEnumerable<T> LoadAppointmentsSource(Uri appointmentsSource)
		{
			if (appointmentsSource != null)
			{
#if WPF
				IEnumerable<T> appointments = Application.LoadComponent(appointmentsSource) as IEnumerable<T>;
#else
				string text = new System.IO.StreamReader(Application.GetResourceStream(appointmentsSource).Stream).ReadToEnd();
				ObservableCollection<T> appointments = System.Windows.Markup.XamlReader.Load(text) as ObservableCollection<T>;
#endif
				DateTime firstDate = appointments.Min(new Func<T, DateTime>(GetStart));

				DayOfWeek firstDay = CultureInfo.CurrentCulture.DateTimeFormat.FirstDayOfWeek;
                var dayOfWeekNumber = (int)DateTime.Today.DayOfWeek == 0 ? 7 : (int)DateTime.Today.DayOfWeek;
                DateTime firstDayOfCurrentWeek = DateTime.Today.Subtract(TimeSpan.FromDays(dayOfWeekNumber - (int)firstDay));

				TimeSpan offset = firstDayOfCurrentWeek - firstDate;

				foreach (IAppointment appointment in appointments)
				{
					appointment.Start += offset;
					appointment.End += offset;
				}

				return appointments;
			}
			return Enumerable.Empty<T>();
		}

		private static DateTime GetStart(T a)
		{
			return a.Start.Date;
		}
	}
}