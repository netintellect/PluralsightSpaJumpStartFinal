using System;

namespace Telerik.Windows.Examples.DataBar.AnnualExpenditures
{
    public class DateTimeDoublePair
    {
        public DateTimeDoublePair(DateTime date, double value)
        {
            this.Date = date;
            this.Value = value;
        }

        public DateTime Date { get; set; }
        public double Value { get; set; }
    }
}
