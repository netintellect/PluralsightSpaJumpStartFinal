using System;
using Telerik.Windows.Controls;

namespace Telerik.Windows.Examples.GanttView
{
	public class CurrentYearVisibleRange : IDateRange
	{
		public DateTime End
		{
			get
			{
				return this.Start.AddYears(1);
			}
			set
			{
			}
		}

		public DateTime Start
		{
			get
			{
                return new DateTime(DateTime.Today.Year, Math.Max(1, DateTime.Today.Month - 1), 1);
			}
			set
			{
			}
		}
	}
}