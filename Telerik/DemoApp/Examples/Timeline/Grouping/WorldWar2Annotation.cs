using System;
using System.Collections.Generic;

namespace Telerik.Windows.Examples.Timeline.Grouping
{
    public class WorldWar2Annotation
    {
        private DateTime startDate;
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
