using System;

namespace Telerik.Windows.Examples.Timeline.CustomRowIndex
{
    public class KingEvent
    {
        public King Ruler { get; set; }

        public DateTime Begin { get; set; }

        public DateTime End { get; set; }

        public TimeSpan Duration
        {
            get
            {
                return this.End - this.Begin;
            }
        }

        public string EventDescription { get; set; }
    }
}
