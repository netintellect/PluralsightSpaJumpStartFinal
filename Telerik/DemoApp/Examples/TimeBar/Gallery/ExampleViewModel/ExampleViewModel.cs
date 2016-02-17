using System;
using System.Collections.Generic;
using System.ComponentModel;
using Telerik.Windows.Controls;

namespace Telerik.Windows.Examples.TimeBar.Gallery
{
    public class ExampleViewModel : ViewModelBase
    {
        Random r = new Random();
        private IEnumerable<MyData> linearData, columnData;

        private DateTime _startDate;
        [TypeConverter(typeof(DateTimeTypeConverter))]
        public DateTime StartDate
        {
            get
            {
                return this._startDate;
            }
            set
            {
                this._startDate = value;
            }
        }

        private DateTime _endDate;
        [TypeConverter(typeof(DateTimeTypeConverter))]
        public DateTime EndDate
        {
            get
            {
                return this._endDate;
            }
            set
            {
                this._endDate = value;
            }
        }

        public IEnumerable<MyData> ColumnData
        {
            get
            {
                if (this.columnData == null)
                {
                    List<MyData> data = new List<MyData>();

                    for (DateTime currentDate = this.StartDate; currentDate < this.EndDate;
                    currentDate = currentDate.AddDays(1))
                    {
                        data.Add(new MyData(currentDate, r.Next(0, 60)));
                    }

                    this.columnData = data;
                }

                return this.columnData;
            }
        }

        public IEnumerable<MyData> LinearData
        {
            get
            {
                if (this.linearData == null)
                {
                    List<MyData> data = new List<MyData>();

                    for (DateTime currentDate = this.StartDate; currentDate <= this.EndDate;
                    currentDate = currentDate.AddDays(1))
                    {
                        data.Add(new MyData(currentDate, r.Next(0, 60)));
                    }

                    this.linearData = data;
                }

                return this.linearData;
            }
        }

        public ExampleViewModel()
        {
        }
    }

    public class MyData
    {
        private DateTime _date;
        public DateTime Date
        {
            get
            {
                return this._date;
            }
            set
            {
                this._date = value;
            }
        }

        private double _value;
        public double Value
        {
            get
            {
                return this._value;
            }
            set
            {
                this._value = value;
            }
        }

        public MyData()
        {
        }

        public MyData(DateTime date, double value)
        {
            this.Date = date;
            this.Value = value;
        }
    }
}
