using System;

namespace Telerik.Windows.Examples.Sparklines.Gallery
{
    public class ExchangeData
    {
        private DateTime _timeStamp;
        private double _value;

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
