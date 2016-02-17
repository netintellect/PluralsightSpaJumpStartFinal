using System;
using Telerik.Windows.Controls;

namespace Telerik.Windows.Examples.GanttView
{
	public class CurrentMonthVisibleRange : IDateRange
	{
		public DateTime End
		{
			get
			{
				return this.Start.AddMonths(1);
			}
			set
			{
			}
		}

		public DateTime Start
		{
			get
			{
				return new DateTime(DateTime.Now.Year, DateTime.Now.Month, 1);
			}
			set
			{
			}
		}
	}
}