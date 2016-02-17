using System;
using System.Linq;
using Telerik.Windows.Controls;

namespace Telerik.Windows.Examples.Buttons.FirstLook.Common
{
    public class Passenger : ViewModelBase
    {
        private string name = null;
        public string Name
        {
            get { return this.name; }
            set
            {
                if (this.name != value)
                {
                    this.name = value;
                    this.OnPropertyChanged("Name");
                }
            }
        }

        private DateTime? birthday = null;
        public DateTime? Birthday
        {
            get { return this.birthday; }
            set
            {
                if (this.birthday != value)
                {
                    this.birthday = value;
                    this.OnPropertyChanged("Birthday");
                }
            }
        }

        private string phone = null;
        public string MobilePhone
        {
            get { return this.phone; }
            set
            {
                if (this.phone != value)
                {
                    this.phone = value;
                    this.OnPropertyChanged("MobilePhone");
                }
            }
        }

        private string language = null;
        public string Language
        {
            get { return this.language; }
            set
            {
                if (this.language != value)
                {
                    this.language = value;
                    this.OnPropertyChanged("Language");
                }
            }
        }

        private string meal = null;
        public string Meal
        {
            get { return this.meal; }
            set
            {
                if (this.meal != value)
                {
                    this.meal = value;
                    this.OnPropertyChanged("Meal");
                }
            }
        }

        private PassengerType? passengerType;
        public PassengerType? PassengerType
        {
            get { return this.passengerType; }
            set
            {
                if (this.passengerType != value)
                {
                    this.passengerType = value;
                    this.OnPropertyChanged("PassengerType");
                }
            }
        }

        public int PassengerIndex { get; set; }

        public Passenger(PassengerType passengerType, int index)
        {
            this.PassengerType = passengerType;
            this.PassengerIndex = index;
        }
    }
}
