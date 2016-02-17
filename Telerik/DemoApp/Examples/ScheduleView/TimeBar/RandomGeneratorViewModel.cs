using System;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Windows.Media;
using Telerik.Windows.Controls;
using Telerik.Windows.Controls.ScheduleView;

namespace Telerik.Windows.Examples.ScheduleView.TimeBar
{
	public class RandomGeneratorViewModel : ViewModelBase
	{
		private ObservableCollection<ResourceType> resourceTypes;
		private int randomSeed;
		private DateTime startTime;
		private DateTime endTime;
		private DateTime currentTime;
		private ObservableCollection<Appointment> appointments;
		private ObservableCollection<Appointment> minimapAppointments;
		private CategoryCollection categories;
		private TimeMarkerCollection timeMarkers;
		private string lipsum;
		private string controls;
		private string actions;

		public RandomGeneratorViewModel()
		{
			this.resourceTypes = new ObservableCollection<ResourceType>();
		}

		public ObservableCollection<ResourceType> ResourceTypes
		{
			get
			{
				return this.resourceTypes;
			}
		}

		public int RandomSeed
		{
			get
			{
				return this.randomSeed;
			}
			set
			{
				this.randomSeed = value;
			}
		}

        private Appointment selectedAppointment;
        public Appointment SelectedAppointment
        {
            get { return this.selectedAppointment; }
            set 
            {
                if (this.selectedAppointment != value && value != null)
                {
                    this.selectedAppointment = value;

                    if (this.selectedAppointment.Category == null)
                    {
                        this.selectedAppointment.Category = this.Categories.First();
                    }
                    if (this.selectedAppointment.TimeMarker == null)
                    {
                        this.selectedAppointment.TimeMarker = this.TimeMarkers.First();
                    }
                    this.OnPropertyChanged(()=> this.SelectedAppointment);
                }
            }
        }

		[TypeConverter(typeof(DateTimeTypeConverter))]
		public DateTime StartTime
		{
			get
			{
				return this.startTime;
			}
			set
			{
				this.startTime = value;
			}
		}

		[TypeConverter(typeof(DateTimeTypeConverter))]
		public DateTime EndTime
		{
			get
			{
				return this.endTime;
			}
			set
			{
				this.endTime = value;
			}
		}

		[TypeConverter(typeof(DateTimeTypeConverter))]
		public DateTime CurrentTime
		{
			get
			{
				return this.currentTime;
			}
			set
			{
				this.currentTime = value;
			}
		}

		public ObservableCollection<Appointment> Appointments
		{
			get
			{
				if (this.appointments == null)
				{
					this.GenerateAppointments();
				}
				return this.appointments;
			}
			set
			{
				this.appointments = value;
				OnPropertyChanged(() => this.Appointments);
				OnPropertyChanged(() => this.MinimapAppointments);
			}
		}

		public ObservableCollection<Appointment> MinimapAppointments
		{
			get
			{
				if (this.minimapAppointments == null)
				{
					this.minimapAppointments = new ObservableCollection<Appointment>(this.Appointments);
				}
				return this.minimapAppointments;
			}
			set
			{
				this.minimapAppointments = value;
			}
		}

		public CategoryCollection Categories
		{
			get
			{
				if (this.categories == null)
				{
					this.categories = new CategoryCollection();
					this.categories.Add(new Category("Completed", new SolidColorBrush(new Color() { R = 0x30, G = 0x9B, B = 0x46, A = 0xFF })));
					this.categories.Add(new Category("In Progress", new SolidColorBrush(Color.FromArgb(255, 126, 81, 161))));
					this.categories.Add(new Category("Not Started", new SolidColorBrush(new Color() { R = 0x25, G = 0xA0, B = 0xDA, A = 0xFF })));
				}
				return this.categories;
			}
		}

		public TimeMarkerCollection TimeMarkers
		{
			get
			{
				if (this.timeMarkers == null)
				{
					this.timeMarkers = new TimeMarkerCollection();
					this.timeMarkers.Add(new TimeMarker("Normal", new SolidColorBrush(Colors.Gray)));
					this.timeMarkers.Add(new TimeMarker("High", new SolidColorBrush(Colors.Red)));
				}
				return this.timeMarkers;
			}
		}

		public string Lipsum
		{
			get
			{
				return this.lipsum;
			}
			set
			{
				this.lipsum = value;
			}
		}

		public string Controls
		{
			get
			{
				return this.controls;
			}
			set
			{
				this.controls = value;
			}
		}

		public string Actions
		{
			get
			{
				return this.actions;
			}
			set
			{
				this.actions = value;
			}
		}

		public void UpdateMinimap()
		{
			this.minimapAppointments = new ObservableCollection<Appointment>(this.Appointments);
			OnPropertyChanged(() => this.MinimapAppointments);
		}

		private void GenerateAppointments()
		{
			this.appointments = new ObservableCollection<Appointment>();

			Random random = new Random(this.RandomSeed);

			string[] lipsum = this.Lipsum.Split('.');
			string[] actions = this.Actions.Split(',');
			string[] controls = this.Controls.Split(',');

			// Since we do not have DB we will autogenerate pseudo tasks:
			foreach (ResourceType type in this.ResourceTypes)
			{
				foreach (Resource resource in type.Resources)
				{
					DateTime currentTasks = this.CurrentTime.AddDays(random.Next(6) - 3);
					DateTime start = this.StartTime;
					while (DateTime.Compare(start, this.EndTime) < 0)
					{
						switch (start.DayOfWeek)
						{
							case DayOfWeek.Saturday:
								start = start.AddDays(2);
								break;
							case DayOfWeek.Sunday:
								start = start.AddDays(1);
								break;
						}
						TimeSpan duration = TimeSpan.FromDays(random.Next(5));
						DateTime end = start.Add(duration);
						switch (end.DayOfWeek)
						{
							case DayOfWeek.Sunday:
								end = end.AddDays(-1);
								break;
							case DayOfWeek.Monday:
								end = end.AddDays(-2);
								break;
						}
						Appointment appointment = new Appointment
							{
								Start = start,
								End = end,
								Subject = actions[random.Next(actions.Length)].Trim() + ": " + controls[random.Next(controls.Length)].Trim(),
								Body = lipsum[random.Next(lipsum.Length)].Trim() + "."
							};
						appointment.Resources.Add(resource);

						if (DateTime.Compare(start, currentTasks) == 1)
						{
							appointment.Category = this.Categories[2];
						}
						else if (DateTime.Compare(currentTasks, start.Add(duration)) == 1)
						{
							appointment.Category = this.Categories[0];
						}
						else
						{
							appointment.Category = this.Categories[1];
						}

						int importance = random.Next(20);
						if (importance == 0)
						{
							appointment.Importance = Importance.High;
							appointment.TimeMarker = this.TimeMarkers[1];
						}
						else
						{
							appointment.TimeMarker = this.TimeMarkers[0];
						}

						this.appointments.Add(appointment);
						start = start.Add(duration);
					}
				}
			}
		}
	}
}
