using System;

namespace Telerik.Windows.Examples.Timeline.TimelineItemTemplate
{
    public class NobelPrize
    {
#if WPF
        const string path = "/Timeline;component/Images/Timeline/TimelineItemTemplate/{0}";
#else
        const string path = "../Images/Timeline/TimelineItemTemplate/{0}";
#endif

        private DateTime date;
        private string category;
        private string name;
        private string country;
        private double contribution;
        private string gender;
        private string details;
        private string imageName;

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

        public string Category
        {
            get
            {
                return this.category;
            }
            set
            {
                this.category = value;
            }
        }

        public string Name
        {
            get
            {
                return name;
            }
            set
            {
                name = value;
            }
        }

        public string Country
        {
            get
            {
                return country;
            }
            set
            {
                country = value;
            }
        }

        public double Contribution
        {
            get
            {
                return this.contribution;
            }
            set
            {
                this.contribution = value;
            }
        }

        public string Gender
        {
            get
            {
                return this.gender;
            }
            set
            {
                this.gender = value;
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

        public string ImageName
        {
            get
            {
                return this.imageName;
            }
            set
            {
                this.imageName = value;
            }
        }
        public string ImagePath
        {
            get
            {
                return string.Format(path, this.ImageName);
            }
        }
    }
}
