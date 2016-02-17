using System.Collections;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Linq;

namespace Telerik.Windows.Examples.ChartView.Gallery.ScatterPoint
{
    public class ExampleViewModel : DataSourceViewModelBase
    {
        public ExampleViewModel()
        {
            this.GetData("EarningsPublicvsPrivateByAge.csv");
        }

        private IEnumerable<HourlyEarnings> _privateData;
        private IEnumerable<HourlyEarnings> _publicData;

        public IEnumerable<HourlyEarnings> PrivateData
        {
            get
            {
                return this._privateData;
            }
            private set
            {
                if (this._privateData == value)
                    return;

                this._privateData = value;
                this.OnPropertyChanged("PrivateData");
            }
        }

        public IEnumerable<HourlyEarnings> PublicData
        {
            get
            {
                return this._publicData;
            }
            set
            {
                if (this._publicData == value)
                    return;

                this._publicData = value;
                this.OnPropertyChanged("PublicData");
            }
        }

        private string _SeriesType = "Scatter point";
        public string SeriesType
        {
            get
            {
                return this._SeriesType;
            }
            set
            {
                if (this._SeriesType != value)
                {
                    this._SeriesType = value;
                    this.OnPropertyChanged("SeriesType");
                }
            }
        }

        protected override void GetDataCompleted(IEnumerable data)
        {
            IEnumerable<HourlyEarnings> hourlyEarningsData = data as IEnumerable<HourlyEarnings>;
            this.PrivateData = from c in hourlyEarningsData where c.Sector == "private" select c;
            this.PublicData = from c in hourlyEarningsData where c.Sector == "public" select c;
        }

        protected override IEnumerable ParseData(TextReader dataReader)
        {
            List<HourlyEarnings> chartData = new List<HourlyEarnings>();
            string line;
            while ((line = dataReader.ReadLine()) != null)
            {
                if (string.IsNullOrEmpty(line))
                    continue;

                string[] data = line.Split(',');
                int age = int.Parse(data[0], CultureInfo.InvariantCulture);
                double wage = double.Parse(data[1], CultureInfo.InvariantCulture);
                string sector = data[2];
                HourlyEarnings hourlyEarningsData = new HourlyEarnings(sector, wage, age);
                chartData.Add(hourlyEarningsData);
            }
            return chartData;
        }        
    }
}
