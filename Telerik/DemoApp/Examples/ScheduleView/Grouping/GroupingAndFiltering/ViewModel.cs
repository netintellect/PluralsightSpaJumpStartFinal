using System;
using System.Collections;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Windows.Input;
using Telerik.Windows.Controls;
using Telerik.Windows.Controls.ScheduleView;

namespace Telerik.Windows.Examples.ScheduleView.Grouping.GroupingAndFiltering
{
	public class ViewModel : ExampleViewModel<Appointment>
	{
		private bool enableGrouping = true;
		private GroupDescriptionCollection groupDescriptions;
		private Func<object, bool> groupFilter;
		private ObservableCollection<Speaker> speakers;
		private List<Speaker> selectedSpeakers;

		public ViewModel()
		{
			this.SelectionCommand = new DelegateCommand(this.OnSelectionExecute);
			this.selectedSpeakers = new List<Speaker>();
		}

		public ObservableCollection<Speaker> Speakers
		{
			get
			{
				if (this.speakers == null)
				{
					this.speakers = new ObservableCollection<Speaker>();
					this.speakers.Add(new Speaker("Sven Ottlieb", "CHIEF TECHNICAL EVANGELIST"));
					this.speakers.Add(new Speaker("Martine Rance", "PRINCIPAL PROGRAM MANAGER"));
					this.speakers.Add(new Speaker("Howard Snyder", "SENIOR COMMUNITY PROGRAM MANAGER"));
					this.speakers.Add(new Speaker("Daniel Tonini", "CHIEF TECHNICAL EVANGELIST"));
					this.speakers.Add(new Speaker("John Steel", "CSO"));
				}

				return this.speakers;
			}
		}

		public bool EnableGrouping
		{
			get
			{
				return this.enableGrouping;
			}
			set
			{
				if (this.enableGrouping != value)
				{
					this.enableGrouping = value;
					this.OnPropertyChanged(() => this.EnableGrouping);

					this.UpdateGroupDescriptions();
				}
			}
		}

		public ICommand SelectionCommand
		{
			get;
			private set;
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
			return this.selectedSpeakers.Select(s => s.Name).ToList();
		}

		private void UpdateGroupDescriptions()
		{
			if (this.EnableGrouping)
			{
				ResourceGroupDescription groupDescription = new ResourceGroupDescription();
				groupDescription.ResourceType = "Category";
				this.GroupDescriptions.Add(groupDescription);
			}
			else
			{
				this.GroupDescriptions.RemoveAll((GroupDescription g) => g is ResourceGroupDescription);
			}
		}

		private void OnSelectionExecute(object param)
		{
			var speakers = ((IEnumerable)param).OfType<Speaker>().ToList();
			if (speakers != null)
			{
				this.selectedSpeakers.Clear();
				this.selectedSpeakers.AddRange(speakers);
				this.UpdateGroupFilter();
			}
		}
	}
}
