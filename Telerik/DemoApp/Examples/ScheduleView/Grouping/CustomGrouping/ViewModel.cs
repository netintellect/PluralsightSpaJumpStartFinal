using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Documents;
using Telerik.Windows.Controls;
using Telerik.Windows.Controls.ScheduleView;

namespace Telerik.Windows.Examples.ScheduleView.Grouping.CustomGrouping
{
	public class ViewModel : ExampleViewModel<Appointment>
	{
		private DelegateCommand setCategoryCommand;
		private DelegateCommand setTimeMarkerCommand;

		private Appointment selectedAppointment;
		private bool showNewsChannel = true;
		private bool showEntertainmentChannel = true;
		private bool showSportsChannel = true;
		private GroupDescriptionCollection groupDescriptions;
		private Func<object, bool> groupFilter;

		public ViewModel()
		{
			this.SetCategoryCommand = new DelegateCommand(this.SetCategoryCommandExecuted, this.SetCategoryCommandCanExecute);
			this.SetTimeMarkerCommand = new DelegateCommand(this.SetTimeMarkerCommandExecuted, this.SetTimeMarkerCommandCanExecute);
		}

		public DelegateCommand SetCategoryCommand
		{
			get
			{
				return this.setCategoryCommand;
			}
			set
			{
				this.setCategoryCommand = value;
			}
		}

		public DelegateCommand SetTimeMarkerCommand
		{
			get
			{
				return this.setTimeMarkerCommand;
			}
			set
			{
				this.setTimeMarkerCommand = value;
			}
		}

		public Appointment SelectedAppointment
		{
			get
			{
				return this.selectedAppointment;
			}
			set
			{
				this.selectedAppointment = value;
			}
		}

		public bool ShowNewsChannel
		{
			get
			{
				return this.showNewsChannel;
			}
			set
			{
				if (this.showNewsChannel != value)
				{
					this.showNewsChannel = value;
					this.OnPropertyChanged(() => this.ShowNewsChannel);
					this.UpdateGroupFilter();
				}
			}
		}

		public bool ShowEntertainmentChannel
		{
			get
			{
				return this.showEntertainmentChannel;
			}
			set
			{
				if (this.showEntertainmentChannel != value)
				{
					this.showEntertainmentChannel = value;
					this.OnPropertyChanged(() => this.ShowEntertainmentChannel);
					this.UpdateGroupFilter();
				}
			}
		}

		public bool ShowSportsChannel
		{
			get
			{
				return this.showSportsChannel;
			}
			set
			{
				if (this.showSportsChannel != value)
				{
					this.showSportsChannel = value;
					this.OnPropertyChanged(() => this.ShowSportsChannel);
					this.UpdateGroupFilter();
				}
			}
		}

		public GroupDescriptionCollection GroupDescriptions
		{
			get
			{
				if (this.groupDescriptions == null)
				{
					this.groupDescriptions = new GroupDescriptionCollection() { new DateGroupDescription() };
					this.UpdateGroupDescriptions();
				}
				return this.groupDescriptions;
			}
		}

		public Func<object, bool> GroupFilter
		{
			get
			{
				return this.groupFilter;
			}
			private set
			{
				this.groupFilter = value;
				this.OnPropertyChanged(() => this.GroupFilter);
			}
		}

		public void SetCategoryCommandExecuted(object parameter)
		{
			if (this.SelectedAppointment == null)
			{
				RadWindow.Alert("Please, select an appointment first.");
			}
			else
			{
				Appointment appointmentToEdit = (from app in this.Appointments where app.Equals(this.SelectedAppointment) select app).FirstOrDefault();
				Category c = parameter as Category;
				appointmentToEdit.Category = c;
				this.Appointments.Remove(appointmentToEdit);
				this.Appointments.Add(appointmentToEdit);
			}
		}

		public void SetTimeMarkerCommandExecuted(object parameter)
		{
			if (this.SelectedAppointment == null)
			{
				RadWindow.Alert("Please, select an appointment first.");
			}
			else
			{
				Appointment appointmentToEdit = (from app in this.Appointments where app.Equals(this.SelectedAppointment) select app).FirstOrDefault();
				TimeMarker t = parameter as TimeMarker;
				appointmentToEdit.TimeMarker = t;
				this.Appointments.Remove(appointmentToEdit);
				this.Appointments.Add(appointmentToEdit);
			}
		}

		public bool CheckAppointmentSelection()
		{
#if WPF
        return this.SelectedAppointment != null;
#else
			return true;
#endif
		}

		public bool SetCategoryCommandCanExecute(object parameter)
		{
			return this.CheckAppointmentSelection();
		}

		public bool SetTimeMarkerCommandCanExecute(object parameter)
		{
			return this.CheckAppointmentSelection();
		}

		private void UpdateGroupFilter()
		{
			this.GroupFilter = new Func<object, bool>(this.GroupFilterFunc);
		}

		private bool GroupFilterFunc(object groupName)
		{
			IResource resource = groupName as IResource;

			return resource == null ? true : this.GetEnabledGroups().Contains(resource.ResourceName, StringComparer.OrdinalIgnoreCase);
		}

		private IEnumerable<string> GetEnabledGroups()
		{
			List<string> enabledGroups = new List<string>();

			if (this.ShowNewsChannel) enabledGroups.Add("LiveCastNews");
			if (this.ShowEntertainmentChannel) enabledGroups.Add("Voozy");
			if (this.ShowSportsChannel) enabledGroups.Add("Sportix");

			return enabledGroups;
		}

		private void UpdateGroupDescriptions()
		{
			ResourceGroupDescription groupDescription = new ResourceGroupDescription();
			groupDescription.ResourceType = "TV";
			this.GroupDescriptions.Add(groupDescription);
		}
	}
}
