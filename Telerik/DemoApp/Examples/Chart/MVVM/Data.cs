using System;
using System.ComponentModel;
using System.Windows.Media;

namespace Telerik.Windows.Examples.Chart.MVVM
{
    public class Data : INotifyPropertyChanged
    {
        private double _eu;
        private double _world;
        private int _year;

        public Data(int year, double eu, double world)
        {
            this._year = year;
            this._eu = eu;
            this._world = world;
        }

        public event PropertyChangedEventHandler PropertyChanged;

        public double EU
        {
            get
            {
                return this._eu;
            }
            set
            {
                if (this._eu == value)
                    return;

                this._eu = value;
                this.OnPropertyChanged("EU");
            }
        }

        public double World
        {
            get
            {
                return this._world;
            }
            set
            {
                if (this._world == value)
                    return;

                this._world = value;
                this.OnPropertyChanged("World");
            }
        }

        public int Year
        {
            get
            {
                return _year;
            }
            private set
            {
                if (this._year == value)
                    return;

                this._year = value;
                this.OnPropertyChanged("Year");
            }
        }

        protected virtual void OnPropertyChanged(string propertyName)
        {
            if (this.PropertyChanged != null)
                this.PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
