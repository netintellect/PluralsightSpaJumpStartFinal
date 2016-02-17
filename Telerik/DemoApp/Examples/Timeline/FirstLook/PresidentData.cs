using System;

namespace Telerik.Windows.Examples.Timeline.FirstLook
{
    public class PresidentData
    {
#if WPF
        const string path = "/Timeline;component/Images/Timeline/FirstLook/{0}";
#else
        const string path = "../../Images/Timeline/FirstLook/{0}";
#endif

        private string name;
        private DateTime birthDate;
        private DateTime deathDate;
        private DateTime presidentFrom;
        private DateTime presidentUntil;
        private string party;
        private string imageName;

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

        public DateTime BirthDate
        {
            get
            {
                return this.birthDate;
            }
            set
            {
                this.birthDate = value;
            }
        }

        public DateTime DeathDate
        {
            get
            {
                return this.deathDate;
            }
            set
            {
                this.deathDate = value;
            }
        }

        public TimeSpan LifeTime
        {
            get
            {
                return this.DeathDate - this.BirthDate;
            }
        }

        public DateTime PresidentFrom
        {
            get
            {
                return this.presidentFrom;
            }
            set
            {
                this.presidentFrom = value;
            }
        }

        public DateTime PresidentUntil
        {
            get
            {
                return this.presidentUntil;
            }
            set
            {
                this.presidentUntil = value;
            }
        }

        public string Party
        {
            get
            {
                return this.party;
            }
            set
            {
                this.party = value;
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
