using System;
using System.Collections.Generic;
using System.Linq;
using Telerik.Windows.Controls.GanttView;

namespace Telerik.Windows.Examples.GanttView.Configuration.TimeRuler
{
	public class ViewModel : GanttViewModel
	{
		public ViewModel()
		{
			this.WeekDays = new [] { DayOfWeek.Monday, DayOfWeek.Tuesday, DayOfWeek.Wednesday, DayOfWeek.Thursday, DayOfWeek.Friday, DayOfWeek.Saturday, DayOfWeek.Sunday };
		}

		public IEnumerable<DayOfWeek> WeekDays { get; private set; }
	}
}
