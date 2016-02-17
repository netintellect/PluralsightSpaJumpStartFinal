using System;
using System.Collections;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Linq;

namespace Telerik.Windows.Examples.ChartView.Exporting
{
    public class OlympicMedalStatisticsViewModel : DataSourceViewModelBase
    {
        public OlympicMedalStatisticsViewModel()
        {
            this.GetData("London201OlympicMedalRankings.csv");
        }

        private IEnumerable<OlympicStatistics> _data;
        private IEnumerable<OlympicStatisticsReport> _allData;

        public IEnumerable<OlympicStatisticsReport> AllData
        {
            get
            {
                return this._allData;
            }
            set
            {
                if (this._allData == value)
                {
                    return;
                }

                this._allData = value;
                this.OnPropertyChanged("AllData");
            }
        }

        public IEnumerable<OlympicStatistics> Data
        {
            get
            {
                return this._data;
            }
            set
            {
                if (this._data == value)
                {
                    return;
                }

                this._data = value;
                this.OnPropertyChanged("Data");
            }
        }

        protected override IEnumerable ParseData(TextReader dataReader)
        {
            string line;
            List<OlympicStatisticsReport> chartData = new List<OlympicStatisticsReport>();

            while ((line = dataReader.ReadLine()) != null)
            {
                if (string.IsNullOrEmpty(line))
                    continue;

                string[] data = line.Split(',');

                OlympicStatisticsReport stats = new OlympicStatisticsReport();
                stats.CountryName = data[0];
                stats.NOC = data[1];
                stats.Gold = int.Parse(data[2], CultureInfo.InvariantCulture);
                stats.Silver = int.Parse(data[3], CultureInfo.InvariantCulture);
                stats.Bronze = int.Parse(data[4], CultureInfo.InvariantCulture);
                stats.Total = int.Parse(data[5], CultureInfo.InvariantCulture);
                chartData.Add(stats);
            }

            return chartData;
        }

        protected override void GetDataCompleted(IEnumerable data)
        {
            this.AllData = data as IEnumerable<OlympicStatisticsReport>;

            var goldMedals = from c in this.AllData
                             select new OlympicStatistics()
                             {
                                 CountryName = c.CountryName,
                                 MedalType = "Gold",
                                 MedalCount = c.Gold
                             };
            var silverMedals = from c in this.AllData
                               select new OlympicStatistics()
                               {
                                   CountryName = c.CountryName,
                                   MedalType = "Silver",
                                   MedalCount = c.Silver
                               };
            var bronzeMedals = from c in this.AllData
                               select new OlympicStatistics()
                               {
                                   CountryName = c.CountryName,
                                   MedalType = "Bronze",
                                   MedalCount = c.Bronze
                               };

            this.Data = goldMedals.Concat(silverMedals).Concat(bronzeMedals);
        }
    }
}
