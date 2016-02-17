using System;
using System.Collections.Generic;

namespace Telerik.Windows.Examples.Timeline.Selection
{
    public class LifeEvent
    {
        private DateTime startDate;
        private DateTime endDate;
        private string groupName;
        private List<string> categories;
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

        public string GroupName
        {
            get
            {
                return this.groupName;
            }
            set
            {
                this.groupName = value;
            }
        }

        public List<string> Categories
        {
            get
            {
                return this.categories;
            }
            set
            {
                this.categories = value;
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
