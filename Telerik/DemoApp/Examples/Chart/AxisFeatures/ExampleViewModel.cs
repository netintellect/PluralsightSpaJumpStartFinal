using System.Collections.Generic;
using Telerik.Windows.Controls;
using System;

namespace Telerik.Windows.Examples.Chart.AxisFeatures
{
    public class ExampleViewModel : ViewModelBase
    {
        private Random _rand = new Random();
        private List<UserDataPoint> _data;

        public ExampleViewModel()
        {
            List<UserDataPoint> source = new List<UserDataPoint>();
            for (int i = 1; i < 31; i++)
            {
                source.Add(new UserDataPoint(i, _rand.Next(481, 1182)));
            }

            this.Data = source;
        }

        public List<UserDataPoint> Data
        {
            get
            {
                return this._data;
            }
            set
            {
                if (this._data != value)
                {
                    this._data = value;
                    this.OnPropertyChanged("Data");
                }
            }
        }
    }
}
