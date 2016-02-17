using System;
using Telerik.Windows.Controls.TimeBar;

namespace Telerik.Windows.Examples.TimeBar.SpecialSlots
{
    public class WeekendsGenerator : ITimeRangeGenerator
    {
        public System.Collections.Generic.IEnumerable<IPeriodSpan> GetRanges(Controls.SelectionRange<DateTime> visibleRange)
        {
            TimeSpan slotSpan = TimeSpan.FromDays(2);
            var differenceFirstVisible = DayOfWeek.Saturday - visibleRange.Start.DayOfWeek;
            DateTime day = new DateTime(visibleRange.Start.Year, visibleRange.Start.Month, visibleRange.Start.Day);

            for (DateTime current = day.AddDays(differenceFirstVisible); current < visibleRange.End; current += TimeSpan.FromDays(7))
            {
                yield return new PeriodSpan(current, slotSpan);
            }
        }
    }
}
