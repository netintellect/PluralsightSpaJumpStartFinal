using System;

namespace Telerik.Windows.Examples.Timeline.Theming
{
    public class ExampleData
    {
        private DateTime date;
        private TimeSpan duration;
        private string details;

        public DateTime Date
        {
            get
            {
                return this.date;
            }
            set
            {
                this.date = value;
            }
        }

        public TimeSpan Duration
        {
            get
            {
                return this.duration;
            }
            set
            {
                this.duration = value;
            }
        }

        public string Details
        {
            get
            {
                return this.details;
            }
            set
            {
                this.details = value;
            }
        }
    }
}
