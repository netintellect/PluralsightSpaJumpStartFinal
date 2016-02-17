using System;
using System.Collections.Generic;

namespace Telerik.Windows.Examples.Sparklines.Gallery
{
    public class ExchangeDataViewModel
    {
        private IEnumerable<ExchangeData> _data;
        private DateTime _endDate;
        private string _name;
        private DateTime _startDate;

        public IEnumerable<ExchangeData> Data
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
                }
            }
        }

        public DateTime EndDate
        {
            get
            {
                return this._endDate;
            }
            set
            {
                if (this._endDate != value)
                {
                    this._endDate = value;
                }
            }
        }

        public double High
        {
            get
            {
                double max = double.MinValue;

                foreach (ExchangeData dataPoint in this.Data)
                {
                    max = Math.Max(max, dataPoint.Value);
                }

                return max;
            }
        }

        public double Low
        {
            get
            {
                double min = double.MaxValue;

                foreach (ExchangeData dataPoint in this.Data)
                {
                    min = Math.Min(min, dataPoint.Value);
                }

                return min;
            }
        }

        public string Name
        {
            get
            {
                return this._name;
            }
            set
            {
                if (this._name != value)
                {
                    this._name = value;
                }
            }
        }

        public DateTime StartDate
        {
            get
            {
                return this._startDate;
            }
            set
            {
                if (this._startDate != value)
                {
                    this._startDate = value;
                }
            }
        }
    }
}
