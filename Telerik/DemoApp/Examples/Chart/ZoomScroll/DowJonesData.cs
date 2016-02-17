using System;

namespace Telerik.Windows.Examples.Chart.ZoomScroll
{
    public class DowJonesData
    {
        private double _adjustedClose;
        private double _close;
        private DateTime _date;
        private double _high;
        private double _low;
        private double _open;
        private long _volume;

        public double AdjustedClose
        {
            get
            {
                return this._adjustedClose;
            }
            set
            {
                if (this._adjustedClose != value)
                {
                    this._adjustedClose = value;
                }
            }
        }

        public double Close
        {
            get
            {
                return this._close;
            }
            set
            {
                if (this._close != value)
                {
                    this._close = value;
                }
            }
        }

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
                }
            }
        }

        public double High
        {
            get
            {
                return this._high;
            }
            set
            {
                if (this._high != value)
                {
                    this._high = value;
                }
            }
        }

        public double Low
        {
            get
            {
                return this._low;
            }
            set
            {
                if (this._low != value)
                {
                    this._low = value;
                }
            }
        }

        public double Open
        {
            get
            {
                return this._open;
            }
            set
            {
                if (this._open != value)
                {
                    this._open = value;
                }
            }
        }

        public long Volume
        {
            get
            {
                return this._volume;
            }
            set
            {
                if (this._volume != value)
                {
                    this._volume = value;
                }
            }
        }
    }
}
