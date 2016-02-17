using System;
using Telerik.Windows.Controls.ScheduleView;

namespace Telerik.Windows.Examples.ScheduleView.Grouping.Filtering
{
	public class ViewModel : ExampleViewModel<Appointment>
	{
		private Func<object, bool> groupFilter;

		public ViewModel()
		{
			this.groupFilter = new Func<object, bool>(this.GroupFilterFunc);
		}

		public Func<object, bool> GroupFilter
		{
			get 
			{ 
				return this.groupFilter; 
			}
			private set
			{
				if (this.groupFilter != value)
				{
					this.groupFilter = value;
					this.OnPropertyChanged(() => this.GroupFilter);
				}
			}
		}

		private bool GroupFilterFunc(object groupName)
		{
			if (groupName is DateTime)
			{
				return ((DateTime)groupName).DayOfWeek == DayOfWeek.Saturday
					|| ((DateTime)groupName).DayOfWeek == DayOfWeek.Sunday;
			}
			return true;
		}
	}
}