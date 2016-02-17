using System;
using System.Net;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Documents;
using System.Windows.Ink;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Animation;
using System.Windows.Shapes;
using Telerik.Windows.Controls;
using Telerik.Windows.Controls.Scheduling;

namespace Telerik.Windows.Examples.GanttView.Programming.SpecialSlots
{
	public class CustomRangeGenerator : ViewModelBase, IRangeGenerator
	{
		public System.Collections.Generic.IEnumerable<IDateRange> GetRanges(IDateRange visibleRange)
		{
			for (DateTime current = visibleRange.Start; current < visibleRange.End; current += TimeSpan.FromDays(1))
			{
				int addDays = (int)current.DayOfWeek;
				if (addDays < 7 && (int)current.DayOfWeek % 2 != 0)
				{
					yield return new DateRange(current, current.AddDays(Math.Min((visibleRange.End - current).Days, 1)));
					addDays = addDays + 1;
				}
			}
		}
	}
}
