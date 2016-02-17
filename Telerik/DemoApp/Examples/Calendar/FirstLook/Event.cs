using System;
using System.ComponentModel;

namespace Telerik.Windows.Examples.Calendar.FirstLook
{
    public class Event : INotifyPropertyChanged
    {
        public Event()
        {
            _date = DateTime.Now;
        }

        public int Day
        {
            get
            {
                return this.Date.Day;
            }
            set
            {
                DateTime today = DateTime.Now;
                this.Date = new DateTime(today.Year, today.Month, value);
            }
        }

        private DateTime _date;
        public DateTime Date
        {
            get
            {
                return this._date;
            }
            set
            {
                if (this._date != value)
                {
                    this._date = value;
                    this.FormatedDate = value.ToString("dddd, MMMM dd");
                    this.OnPropertyChanged("Date");
                    this.OnPropertyChanged("Day");
                }
            }
        }

        private string _formatedDate;
        public string FormatedDate
        {
            get
            {
                return this._formatedDate;
            }
            protected set
            {
                if (this._formatedDate != value)
                {
                    this._formatedDate = value;
                    this.OnPropertyChanged("FormatedDate");
                }
            }
        }

        private string _title;
        public string Title
        {
            get
            {
                return this._title;
            }
            set
            {
                if (this._title != value)
                {
                    this._title = value;
                    this.OnPropertyChanged("Title");
                }
            }
        }

        private string _company;
        public string Company
        {
            get
            {
                return this._company;
            }
            set
            {
                if (this._company != value)
                {
                    this._company = value;
                    this.OnPropertyChanged("Company");
                }
            }
        }

        private string _description;
        public string Description
        {
            get
            {
                return this._description;
            }
            set
            {
                if (this._description != value)
                {
                    this._description = value;
                    this.OnPropertyChanged("Description");
                }
            }
        }      

        protected void OnPropertyChanged(string propertyName)
        {
            if (this.PropertyChanged != null)
            {
                PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
            }
        }
        public event PropertyChangedEventHandler PropertyChanged;
    }
}
