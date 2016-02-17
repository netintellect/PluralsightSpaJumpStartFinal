using System;
using System.ComponentModel;

namespace Telerik.Windows.Examples.TimeBar.SpecialSlots
{
    public class Ticket : INotifyPropertyChanged
    {
        private DateTime date;
        private int price;
        private Airport from;
        private Airport to;

        public event PropertyChangedEventHandler PropertyChanged;

        public Ticket(DateTime date, int price, Airport from, Airport to)
        {
            this.Date = date;
            this.Price = price;
            this.From = from;
            this.To = to;
        }

        public DateTime Date
        {
            get
            {
                return this.date;
            }
            set
            {
                if (this.date != value)
                {
                    this.date = value;
                    this.OnPropertyChanged("Date");
                }
            }
        }

        public int Price
        {
            get
            {
                return this.price;
            }
            set
            {
                if (this.price != value)
                {
                    this.price = value;
                    this.OnPropertyChanged("Price");
                }
            }
        }

        public Airport From
        {
            get
            {
                return this.from;
            }
            set
            {
                if (this.from != value)
                {
                    this.from = value;
                    this.OnPropertyChanged("From");
                }
            }
        }

        public Airport To
        {
            get
            {
                return this.to;
            }
            set
            {
                if (this.to != value)
                {
                    this.to = value;
                    this.OnPropertyChanged("To");
                }
            }
        }

        private void OnPropertyChanged(string propertyName)
        {
            if (this.PropertyChanged != null)
                this.PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
