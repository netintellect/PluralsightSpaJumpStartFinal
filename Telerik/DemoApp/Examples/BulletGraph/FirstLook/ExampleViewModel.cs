using System;
using System.Collections;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Linq;

namespace Telerik.Windows.Examples.BulletGraph.FirstLook
{
    public class ExampleViewModel : DataSourceViewModelBase
    {
        private IEnumerable<KeyMeasure> _data;
        private readonly DateTime startDateTime = new DateTime(2010, 11, 1);

        public ExampleViewModel()
        {
            this.GetData("dashboard2.csv");
        }

        public IEnumerable<KeyMeasure> Data
        {
            get
            {
                return _data;
            }
            set
            {
                if (this._data == value)
                    return;

                this._data = value;
                this.OnPropertyChanged("Data");
                this.OnPropertyChanged("MaxDiversionAxisValue");
                this.OnPropertyChanged("MinDiversionAxisValue");
            }
        }

        protected override void GetDataCompleted(IEnumerable data)
        {
            this.Data = data as IEnumerable<KeyMeasure>;
        }

        protected override IEnumerable ParseData(TextReader dataReader)
        {
            List<KeyMeasure> measures = new List<KeyMeasure>(18);
            string line;

            while ((line = dataReader.ReadLine()) != null)
            {
                string[] lineData = line.Split(',');

                KeyMeasure keyMeasure = new KeyMeasure();
                keyMeasure.RepresentativeName = lineData[0];

                for (int i = 0; i < 12; i++)
                {
                    Measure measure = new Measure();
                    measure.Date = startDateTime.AddMonths(i);
                    measure.Value = double.Parse(lineData[1 + i], CultureInfo.InvariantCulture);

                    keyMeasure.ActualProfitByMonth.Add(measure);
                }

                keyMeasure.TargetYTDProfit = double.Parse(lineData[13], CultureInfo.InvariantCulture);
                keyMeasure.TargetProfit = double.Parse(lineData[14], CultureInfo.InvariantCulture);

                measures.Add(keyMeasure);
            }

            return measures;
        }

        public double MaxDiversionAxisValue
        {
            get
            {
                if (this.Data == null)
                    return 100;

                double maxPercent = this.Data.Max(km => km.PercentDiversion);
                double minPercent = this.Data.Min(km => km.PercentDiversion);
                double extremum = Math.Max(Math.Abs(minPercent), Math.Abs(maxPercent));
                double maxAxisValue = Math.Ceiling(extremum * 100) / 100;

                return maxAxisValue;
            }
        }
        
        public double MinDiversionAxisValue
        {
            get
            {
                if (this.Data == null)
                    return 0;

                double maxPercent = this.Data.Max(km => km.PercentDiversion);
                double minPercent = this.Data.Min(km => km.PercentDiversion);
                double extremum = Math.Max(Math.Abs(minPercent), Math.Abs(maxPercent));
                double minAxisValue = - Math.Ceiling(extremum * 100) / 100;
                
                return minAxisValue;
            }
        }
    }
}
