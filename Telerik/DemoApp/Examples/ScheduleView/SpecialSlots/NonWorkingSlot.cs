using System;
using Telerik.Windows.Controls;
using Telerik.Windows.Controls.ScheduleView;

namespace Telerik.Windows.Examples.ScheduleView.SpecialSlots
{
	public class NonWorkingSlot : Slot
	{
		public NonWorkingSlot(DateTime start, DateTime end)
			: base(start, end)
		{
			this.Resources.Add(new Resource("John", "Calendar"));
		}

		public override Slot Copy()
		{
			Slot slot = new NonWorkingSlot(this.Start, this.End);
			slot.CopyFrom(this);
			return slot;
		}

		public override void CopyFrom(Slot other)
		{
			var otherSlot = other as NonWorkingSlot;
			if (otherSlot != null)
			{
				base.CopyFrom(otherSlot);
			}
		}
	}
}