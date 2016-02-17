using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using Telerik.Windows.Controls;
using Telerik.Windows.Controls.ScheduleView;

namespace Telerik.Windows.Examples.BusyIndicator.FirstLook
{
	public class ViewModel : ViewModelBase
	{
		private bool isBusy;
		private string busyContent;
		private ObservableCollection<Appointment> appointments;
		private Random random = new Random();

		public ViewModel()
		{
		}

		public ObservableCollection<Appointment> Appointments
		{
			get { return this.appointments; }
			set
			{
				if (this.appointments != value)
				{
					this.appointments = value;
					this.OnPropertyChanged(() => this.Appointments);
				}
			}
		}

		public bool IsBusy
		{
			get { return this.isBusy; }
			set
			{
				if (this.isBusy != value)
				{
					this.isBusy = value;
					this.OnPropertyChanged(() => this.IsBusy);

					if (this.isBusy)
					{
						var backgroundWorker = new BackgroundWorker();
						backgroundWorker.DoWork += this.OnBackgroundWorkerDoWork;
						backgroundWorker.RunWorkerCompleted += OnBackgroundWorkerRunWorkerCompleted;
						backgroundWorker.RunWorkerAsync();
					}
				}
			}
		}

		public string BusyContent
		{
			get { return this.busyContent; }
			set
			{
				if (this.busyContent != value)
				{
					this.busyContent = value;
					this.OnPropertyChanged(() => this.BusyContent);
				}
			}
		}

		private void OnBackgroundWorkerRunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
		{
			var backgroundWorker = sender as BackgroundWorker;
			backgroundWorker.DoWork -= this.OnBackgroundWorkerDoWork;
			backgroundWorker.RunWorkerCompleted -= OnBackgroundWorkerRunWorkerCompleted;

			InvokeOnUIThread(() =>
			{
				this.IsBusy = false;
				this.Appointments = new ObservableCollection<Appointment>((IEnumerable<Appointment>)e.Result);
			});
		}

		private void OnBackgroundWorkerDoWork(object sender, DoWorkEventArgs e)
		{
			e.Result = this.GenerateRandomAppointments().ToList();
		}

		private IEnumerable<Appointment> GenerateRandomAppointments()
		{
			var counter = 0;
			var startDate = DateTime.Now.Date;

			for (int i = 0; i < 10; i++)
			{
				int length = 0;
				for (int currentTime = 0; currentTime < 24 * 60; currentTime += length)
				{
					length = this.random.Next(30, 180);

					if (length % 5 == 0)
					{
						continue;
					}

					if ((24 * 60 - currentTime + length) < 60 || (24 * 60 - currentTime - length) < 0)
					{
						break;
					}

					counter++;

					InvokeOnUIThread(() =>
					{
						this.BusyContent = string.Concat("Loaded ", counter, " appointments");
					});

					yield return new Appointment
					{
						Subject = string.Format("App {0}.{1}", i + 1, length),
						Start = startDate.AddMinutes(currentTime),
						End = startDate.AddMinutes(currentTime + length)
					};

					System.Threading.Thread.Sleep(20);
				}

				startDate = startDate.AddDays(1);
			}
		}
	}
}