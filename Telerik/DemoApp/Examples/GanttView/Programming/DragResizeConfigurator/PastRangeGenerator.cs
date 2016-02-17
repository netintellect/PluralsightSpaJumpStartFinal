using System;
using System.Collections.Generic;
using Telerik.Windows.Controls;
using Telerik.Windows.Controls.Scheduling;

namespace Telerik.Windows.Examples.GanttView.Programming.DragResizeConfigurator
{
	public class PastRangeGenerator : IRangeGenerator
	{
		public IEnumerable<IDateRange> GetRanges(IDateRange visibleRange)
		{
			var now = DateTime.Now;
			if (now > visibleRange.Start)
			{
				yield return new DateRange(visibleRange.Start, now < visibleRange.End ? now : visibleRange.End);
			}
		}
	}
}