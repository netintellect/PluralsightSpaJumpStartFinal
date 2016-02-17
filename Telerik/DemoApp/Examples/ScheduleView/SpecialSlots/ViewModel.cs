using System;
using System.Collections.ObjectModel;
using Telerik.Windows.Controls;
using Telerik.Windows.Controls.ScheduleView;

namespace Telerik.Windows.Examples.ScheduleView.SpecialSlots
{
	public class ViewModel : ExampleViewModel<Appointment>
	{
		private ObservableCollection<Slot> specialSlots;

		public ViewModel()
		{
			this.specialSlots = new ObservableCollection<Slot>();

			this.specialSlots.Add(this.CreateReadOnlySlot());

			DateTime start = new DateTime(2010, 1, 1, 18, 0, 0);
			DateTime end = new DateTime(2010, 1, 2, 8, 0, 0);

			this.specialSlots.Add(this.CreateNonWorkingSlot(start, end, RecurrenceDays.Monday | RecurrenceDays.Tuesday | RecurrenceDays.Wednesday | RecurrenceDays.Thursday));
			this.specialSlots.Add(this.CreateNonWorkingSlot(start, end.AddDays(2), RecurrenceDays.Friday));
		}

		public ObservableCollection<Slot> SpecialSlots
		{
			get
			{
				return this.specialSlots;
			}
		}

		private Slot CreateNonWorkingSlot(DateTime start, DateTime end, RecurrenceDays days)
		{
			Slot slot = new NonWorkingSlot(start, end);
			slot.RecurrencePattern = new RecurrencePattern(null, days, RecurrenceFrequency.Weekly, 1, null, null);

			return slot;
		}

		private Slot CreateReadOnlySlot()
		{
			Slot slot = new Slot() { Start = DateTime.MinValue, End = DateTime.MaxValue, IsReadOnly = true };
			slot.Resources.Add(new Resource("Team", "Calendar"));

			return slot;
		}
	}
}