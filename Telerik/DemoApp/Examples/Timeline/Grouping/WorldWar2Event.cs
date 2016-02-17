using System;
using System.Collections.Generic;

namespace Telerik.Windows.Examples.Timeline.Grouping
{
    public class WorldWar2Event
    {
        private DateTime startDate;
        private DateTime endDate;
        private string country;
        private List<string> allies;
        private List<string> axis;
        private string details;

        public DateTime StartDate
        {
            get
            {
                return this.startDate;
            }
            set
            {
                this.startDate = value;
            }
        }

        public DateTime EndDate
        {
            get
            {
                return this.endDate;
            }
            set
            {
                this.endDate = value;
            }
        }

        public TimeSpan Duration
        {
            get
            {
                return this.EndDate - this.StartDate;
            }
        }

        public string Country
        {
            get
            {
                return this.country;
            }
            set
            {
                this.country = value;
            }
        }

        public List<string> Allies
        {
            get
            {
                return this.allies;
            }
            set
            {
                this.allies = value;
            }
        }

        public List<string> Axis
        {
            get
            {
                return this.axis;
            }
            set
            {
                this.axis = value;
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
