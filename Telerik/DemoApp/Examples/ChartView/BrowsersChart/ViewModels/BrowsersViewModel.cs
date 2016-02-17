using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Windows.Documents;
using Telerik.Windows.Examples.ChartView.BrowsersChart.Models;

namespace Telerik.Windows.Examples.ChartView.BrowsersChart.ViewModels
{
    public class BrowsersViewModel : DataSourceViewModelBase
    {
        public const string InternetExplorerName = "Internet Explorer";
        public const string FirefoxName = "Firefox";
        public const string GoogleChromeName = "Google Chrome";
        public const string SafariName = "Safari";
        public const string OperaName = "Opera";

        private List<string> browserNames = new List<string>() { InternetExplorerName, FirefoxName, GoogleChromeName, SafariName, OperaName };
        public List<string> BrowserNames { get { return this.browserNames; } }

        private IEnumerable<BrowserData> data;
        public IEnumerable<BrowserData> Data
        {
            get { return this.data; }
            set 
            {
                if (this.data != value)
                {
                    this.data = value;
                    this.OnPropertyChanged("Data");
                }
            }
        }

        public BrowsersViewModel()
        {
            this.GetData("BrowsersStatistics.csv");
        }

        private List<BrowserData> SummarizeData(IEnumerable<BrowserStatistics> rawBrowsersData)
        {
            List<BrowserData> data = new List<BrowserData>();

            foreach (IGrouping<string, BrowserStatistics> browserNameGroup in rawBrowsersData.GroupBy(bs => bs.Name))
            {
                List<BrowserYearlySummary> browserSummaries = new List<BrowserYearlySummary>();

                foreach (IGrouping<int, BrowserStatistics> browserYearGroup in browserNameGroup.GroupBy(bs => bs.Year))
                {
                    BrowserYearlySummary summary = new BrowserYearlySummary();
                    summary.BrowserName = browserNameGroup.Key;
                    summary.Year = browserYearGroup.Key;
                    summary.PopularityPercent = browserYearGroup.Average(bs => bs.Popularity);
                    browserSummaries.Add(summary);
                }

                BrowserData browserData = new BrowserData() { Name = browserNameGroup.Key, Data = browserSummaries.OrderBy(bs => bs.Year) };
                data.Add(browserData);
            }

            return data;
        }

        protected override void GetDataCompleted(System.Collections.IEnumerable data)
        {
            var browsersStatistics = data as IEnumerable<BrowserStatistics>;
            this.Data = this.SummarizeData(browsersStatistics);
        }

        protected override System.Collections.IEnumerable ParseData(System.IO.TextReader dataReader)
        {
            string line;
            string[] lineData;
            List<BrowserStatistics> browsersData = new List<BrowserStatistics>();
            line = dataReader.ReadLine();
            lineData = line.Split(',');
            
            while ((line = dataReader.ReadLine()) != null)
            {
                if (string.IsNullOrEmpty(line))
                    continue;

                lineData = line.Split(',');

                int year = Int32.Parse(lineData[0]);
                string month = lineData[1];
                string popularityString;
                double popularityPercent;

                for (int i = 0; i < browserNames.Count; i++)
                {
                    BrowserStatistics statistics = new BrowserStatistics();
                    statistics.Name = this.browserNames[i];
                    statistics.Year = year;
                    statistics.Month = month;

                    popularityString = lineData[i + 2].Replace("%", string.Empty);
                    if (!double.TryParse(popularityString, NumberStyles.Float, CultureInfo.InvariantCulture, out popularityPercent))
                        popularityPercent = 0d;

                    statistics.Popularity = popularityPercent / 100d;
                    browsersData.Add(statistics);
                }
            }

            return browsersData;
        }
    }
}
