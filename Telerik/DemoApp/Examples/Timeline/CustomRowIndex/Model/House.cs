using System;

namespace Telerik.Windows.Examples.Timeline.CustomRowIndex
{
    public class House
    {
        public DateTime Begin { get; set; }

        public string Name { get; set; }

        public DateTime End { get; set; }

        public TimeSpan Duration
        {
            get
            {
                return this.End - this.Begin;
            }
        }

        public House Data
        {
            get
            {
                return this;
            }
        }
    }
}
