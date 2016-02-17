using System;

namespace Telerik.Windows.Examples.Timeline.CustomRowIndex
{
    public class King
    {
        public string Name { get; set; }

        public DateTime Birth { get; set; }

        public DateTime Death { get; set; }

        public DateTime Begin { get; set; }

        public DateTime End { get; set; }

        public TimeSpan Duration
        {
            get
            {
                return this.End - this.Begin;
            }
        }

        public string Children { get; set; }

        public string Parents { get; set; }

        public string Married { get; set; }

        public string House { get; set; }

        public string Bio { get; set; }

        public string Successor { get; set; }
    }
}
