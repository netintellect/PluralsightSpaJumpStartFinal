using System;
using System.Collections;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Linq;

namespace Telerik.Windows.Examples.ChartView.Gallery.Point
{
    public class ExampleViewModel : DataSourceViewModelBase
    {
        public ExampleViewModel()
        {
            this.GetData("Earthquakes.csv");
        }

        private List<PointSeriesData> _pointData;

        public List<PointSeriesData> PointData
        {
            get { return this._pointData; }
            set
            {
                if (this._pointData != value)
                {
                    this._pointData = value;
                    this.OnPropertyChanged(() => this.PointData);
                }
            }
        }

        //marked zone 1
        private DateTime markedZone1HorizontalValue = new DateTime(2009, 1, 5);
        public DateTime MarkedZone1HorizontalValue
        {
            get
            {
                return this.markedZone1HorizontalValue;
            }
        }

        private DateTime markedZone1HorizontalFrom = new DateTime(2009, 1, 5);
        public DateTime MarkedZone1HorizontalFrom
        {
            get
            {
                return this.markedZone1HorizontalFrom;
            }
        }

        private DateTime markedZone1HorizontalTo = new DateTime(2009, 3, 20);
        public DateTime MarkedZone1HorizontalTo
        {
            get
            {
                return this.markedZone1HorizontalTo;
            }
        }

        //marked zone 2
        private DateTime markedZone2HorizontalValue = new DateTime(2009, 3, 24);
        public DateTime MarkedZone2HorizontalValue
        {
            get
            {
                return this.markedZone2HorizontalValue;
            }
        }

        private DateTime markedZone2HorizontalFrom = new DateTime(2009, 3, 24);
        public DateTime MarkedZone2HorizontalFrom
        {
            get
            {
                return this.markedZone2HorizontalFrom;
            }
        }

        private DateTime markedZone2HorizontalTo = new DateTime(2009, 4, 6);
        public DateTime MarkedZone2HorizontalTo
        {
            get
            {
                return this.markedZone2HorizontalTo;
            }
        }

        //marked zone 3
        private DateTime markedZone3HorizontalValue = new DateTime(2009, 4, 1);
        public DateTime MarkedZone3HorizontalValue
        {
            get
            {
                return this.markedZone3HorizontalValue;
            }
        }

        private DateTime markedZone3HorizontalFrom = new DateTime(2009, 4, 1);
        public DateTime MarkedZone3HorizontalFrom
        {
            get
            {
                return this.markedZone3HorizontalFrom;
            }
        }

        private DateTime markedZone3HorizontalTo = new DateTime(2009, 4, 12);
        public DateTime MarkedZone3HorizontalTo
        {
            get
            {
                return this.markedZone3HorizontalTo;
            }
        }

        protected override IEnumerable ParseData(TextReader dataReader)
        {
            string line;

            List<PointSeriesData> chartData = new List<PointSeriesData>();

            while ((line = dataReader.ReadLine()) != null)
            {
                if (string.IsNullOrEmpty(line))
                    continue;

                string[] data = line.Split(',');

                PointSeriesData dataItem = new PointSeriesData();
                dataItem.Date = DateTime.Parse(data[0], CultureInfo.InvariantCulture);
                dataItem.Magnitude = double.Parse(data[1], CultureInfo.InvariantCulture);

                chartData.Add(dataItem);
            }

            return chartData;
        }

        protected override void GetDataCompleted(IEnumerable data)
        {
            this.PointData = data as List<PointSeriesData>;
        }
    }
}
