using System.Collections.ObjectModel;
using System.Linq;
using System.Windows.Input;
using Telerik.Windows.Controls;
using Telerik.Windows.Controls.ScheduleView;

namespace Telerik.Windows.Examples.ScheduleView.LoadOnDemand
{
	public class ViewModel : ViewModelBase
	{
		private ICommand visibleRangeChanged;
		private ObservableCollection<Appointment> appointments;

		public ViewModel()
		{
			this.Appointments = new ObservableCollection<Appointment>();
			this.VisibleRangeChanged = new DelegateCommand(this.OnVisibleRangeExecuted, this.OnVisibleRangeCanExecute);
		}

		public ObservableCollection<Appointment> Appointments
		{
			get
			{
				return this.appointments;
			}
			private set
			{
				this.appointments = value;
				this.OnPropertyChanged("Appointments");
			}
		}

		public ICommand VisibleRangeChanged
		{
			get
			{
				return this.visibleRangeChanged;
			}
			set
			{
				this.visibleRangeChanged = value;
			}
		}

		private void OnVisibleRangeExecuted(object param)
		{
			// The param is bound to the VisibleRange property in XAML
			this.GenerateAppointments(param as IDateSpan);
		}

		private bool OnVisibleRangeCanExecute(object param)
		{
			return param != null;
		}

		private void GenerateAppointments(IDateSpan dateSpan)
		{
			ObservableCollection<Appointment> newSource = new ObservableCollection<Appointment>();

			newSource.AddRange(
				from i in Enumerable.Range(0, (dateSpan.End - dateSpan.Start).Days * 24)
				select new Appointment()
				{
					Subject = "Appointment" + i + " " + dateSpan.Start.AddHours(i).ToShortDateString(),
					Start = dateSpan.Start.AddHours(i),
					End = dateSpan.Start.AddHours(i + 1),
				});

			this.Appointments = newSource;
		}
	}
}