using System;

namespace Telerik.Windows.Examples.ChartView.Palettes
{
    public class Data
    {
        private DateTime _timeStamp;
        private double _value;
        private string _category;

        public Data(DateTime timeStamp, double value)
        {
            this._timeStamp = timeStamp;
            this._value = value;
        }

        public Data(string category, double value)
        {
            this._category = category;
            this._value = value;
        }

        public DateTime TimeStamp
        {
            get
            {
                return this._timeStamp;
            }
            set
            {
                if (this._timeStamp != value)
                {
                    this._timeStamp = value;
                }
            }
        }

        public string Category
        {
            get
            {
                return this._category;
            }
            set
            {
                if (this._category != value)
                {
                    this._category = value;
                }
            }
        }

        public double Value
        {
            get
            {
                return this._value;
            }
            set
            {
                if (this._value != value)
                {
                    this._value = value;
                }
            }
        }
    }
}
