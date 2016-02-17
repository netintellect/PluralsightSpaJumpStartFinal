using System;
using System.Collections;
using System.Collections.Generic;
using System.Globalization;
using System.IO;

namespace Telerik.Windows.Examples.ChartView.Financial
{
    public class FinancialInfo
    {
        private DateTime _date;
        private double _open;
        private double _high;
        private double _low;
        private double _close;
        private double _volume;

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

        public double Open
        {
            get
            {
                return this._open;
            }
            set
            {
                this._open = value;
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
                this._high = value;
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
                this._low = value;
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
                this._close = value;
            }
        }

        public double Volume
        {
            get
            {
                return this._volume;
            }
            set
            {
                this._volume = value;
            }
        }

        internal static IEnumerable ParseData(TextReader dataReader)
        {
            string line;
            List<FinancialInfo> chartData = new List<FinancialInfo>();

            while ((line = dataReader.ReadLine()) != null)
            {
                if (string.IsNullOrEmpty(line))
                    continue;

                string[] data = line.Split(',');

                FinancialInfo dataItem = new FinancialInfo();
                dataItem.Date = DateTime.Parse(data[0], CultureInfo.InvariantCulture);
                dataItem.Open = double.Parse(data[1], CultureInfo.InvariantCulture);
                dataItem.High = double.Parse(data[2], CultureInfo.InvariantCulture);
                dataItem.Low = double.Parse(data[3], CultureInfo.InvariantCulture);
                dataItem.Close = double.Parse(data[4], CultureInfo.InvariantCulture);
                dataItem.Volume = double.Parse(data[5], CultureInfo.InvariantCulture);

                chartData.Add(dataItem);
            }

            return chartData;
        }
    }
}
