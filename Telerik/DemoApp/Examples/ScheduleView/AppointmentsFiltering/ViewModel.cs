using System;
using System.Collections.Generic;
using Telerik.Windows.Controls;
using Telerik.Windows.Controls.ScheduleView;

namespace Telerik.Windows.Examples.ScheduleView.AppointmentsFiltering
{
	public class ViewModel : ExampleViewModel<Appointment>
	{
		private IResource selectedProgramme;

		private List<ResourceType> resourceTypes;
		private IEnumerable<IResource> resourcesProgrammes;
		private IEnumerable<IResource> resourcesTVs;

		public ViewModel()
		{
			this.resourcesProgrammes = new List<IResource>
			{
				new Resource("Movies", "Programme"),
				new Resource("Sports", "Programme"),
				new Resource("Shows", "Programme"),
				new Resource("Kids", "Programme"),
			};

			this.resourcesTVs = new List<IResource>
			{
				new Resource("LiveCastNews", "TV"),
				new Resource("Voozy", "TV"),
				new Resource("Sportix", "TV"),
			};

			ResourceType resourceTypeProgramme = new ResourceType("Programme");
			resourceTypeProgramme.Resources.AddRange(this.resourcesProgrammes);
			ResourceType resourceTypeTV = new ResourceType("TV");
			resourceTypeTV.Resources.AddRange(this.resourcesTVs);

			this.resourceTypes = new List<ResourceType>();
			this.resourceTypes.Add(resourceTypeProgramme);
			this.resourceTypes.Add(resourceTypeTV);
		}

		public IEnumerable<ResourceType> ResourceTypes
		{
			get { return this.resourceTypes; }
		}

		public IEnumerable<IResource> ResourcesProgrammes
		{
			get { return this.resourcesProgrammes; }
		}

		public IResource SelectedProgramme
		{
			get
			{
				return this.selectedProgramme;
			}
			set
			{
				if (this.selectedProgramme != value)
				{
					this.selectedProgramme = value;
					this.OnPropertyChanged("SelectedProgramme");
					this.OnPropertyChanged("AppoitmentsFilter");
				}
			}
		}

		public Predicate<IAppointment> AppoitmentsFilter
		{
			get
			{
				return this.Filter;
			}
		}

		private bool Filter(IAppointment appointment)
		{
			Appointment a = appointment as Appointment;
			return a != null && this.FilterByProgramme(a);
		}

		private bool FilterByProgramme(Appointment appointment)
		{
			return this.selectedProgramme == null || appointment.Resources.Contains(this.selectedProgramme);
		}
	}
}