using System;
using System.Net;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Documents;
using System.Windows.Ink;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Animation;
using System.Windows.Shapes;
using Telerik.Windows.Controls;
using System.Collections.Generic;
using System.Linq;

namespace Telerik.Windows.Examples.TimeBar.FirstLook
{
    public class WebsiteStatisticsViewModel : ViewModelBase
    {
        public WebsiteStatisticsViewModel()
        {
            this.ServerInfos = new List<ServerInfo>();
            this.TrafficInfos = new List<TrafficInfo>();
            this.HourlyDistributions = new List<HourlyDistribution>();

            DateTime startDate = new DateTime(2011, 1, 1);
            DateTime endDate = new DateTime(2012, 6, 1);
            int daysCount = (int)(endDate - startDate).TotalDays;

            for (int i = 0; i < daysCount; i++)
            {
                DateTime currentDate = startDate.AddDays(i);
                this.ServerInfos.Add(this.GenerateRandomServerInfo(currentDate));
                this.TrafficInfos.Add(this.GenerateRandomTrafficInfo(currentDate));
                this.HourlyDistributions.Add(this.GenerateRandomHourlyDistributionInfo(currentDate));
            }

            this.PeriodStart = startDate;
            this.PeriodEnd = this.ServerInfos[this.ServerInfos.Count - 1].Date.AddDays(1);
            this.VisiblePeriodStart = this.ServerInfos[daysCount * 9 / 20].Date;
            this.VisiblePeriodEnd = this.ServerInfos[daysCount * 11 / 20].Date;
            this.SelectedStartDate = this.ServerInfos[daysCount / 2 - 4].Date;
            this.SelectedEndDate = this.ServerInfos[daysCount / 2 + 3].Date;
            this.MinSelectionRange = TimeSpan.FromDays(1);
        }

		private HourlyDistribution GenerateRandomHourlyDistributionInfo(DateTime currentDate)
		{
            HourInfo hi;
            List<HourInfo> hiList = new List<HourInfo>();
            DateTime date = new DateTime(DateTime.Now.Year, DateTime.Now.Month, DateTime.Now.Day);

            hi = new HourInfo(date.AddHours(0), 2 + random.NextDouble());
            hiList.Add(hi);
            for (int i = 1; i < 23; i++)
            {
                if (i <= 5)
                {
                    hi = new HourInfo(date.AddHours(i), 1 + random.NextDouble());
                    hiList.Add(hi);
                }
                else if (i == 6 || i == 7)
                {
                    hi = new HourInfo(date.AddHours(i), random.Next(2, 3) + random.NextDouble());
                    hiList.Add(hi);
                }
                else if (i == 8)
                {
                    hi = new HourInfo(date.AddHours(i), random.Next(4, 5) + random.NextDouble());
                    hiList.Add(hi);
                }
                else if (i == 9)
                {
                    hi = new HourInfo(date.AddHours(i), random.Next(5, 6) + random.NextDouble());
                    hiList.Add(hi);
                }
                else if ((i >= 10 && i <= 11) || i == 20)
                {
                    hi = new HourInfo(date.AddHours(i), random.Next(6, 7) + random.NextDouble());
                    hiList.Add(hi);
                }
                else if ((i >= 12 && i <= 13) || (i >= 21))
                {
                    hi = new HourInfo(date.AddHours(i), random.Next(4, 5) + random.NextDouble());
                    hiList.Add(hi);
                }
                else if (i >= 14 && i <= 19)
                {
                    hi = new HourInfo(date.AddHours(i), 6 + random.NextDouble());
                    hiList.Add(hi);
                }
            }

            double sumOfHourInfos = hiList.Sum(l => l.Distribution);
            hi = new HourInfo(date.AddHours(23), Math.Abs(100 - sumOfHourInfos));
            hiList.Add(hi);

            return new HourlyDistribution(currentDate, hiList);
        }

        private TrafficInfo GenerateRandomTrafficInfo(DateTime currentDate)
        {
            double referringSites = random.Next(23, 31) + random.Next(0, 2) + random.NextDouble();
            double directTraffic = random.Next(38, 44) + random.Next(0, 2) + random.NextDouble();
            double searchEngines = random.Next(18, 23) + random.Next(0, 2) + random.NextDouble();
            return new TrafficInfo(currentDate, directTraffic, referringSites, searchEngines, 100 - (directTraffic + referringSites + searchEngines));
        }

        static Random random = new Random();

        private ServerInfo GenerateRandomServerInfo(DateTime date)
        {
            int visitors = random.Next(1202, 1811);
            return new ServerInfo(date, visitors, random.Next(1202, visitors), random.Next(1956, 2468), random.Next(visitors, visitors * 3) * 4);
        }

        public List<ServerInfo> ServerInfos { get; private set; }
        public List<TrafficInfo> TrafficInfos { get; private set; }
        public List<HourlyDistribution> HourlyDistributions { get; private set; }

        private DateTime selectedStartDate;
        public DateTime SelectedStartDate
        {
            get { return this.selectedStartDate; }

            set
            {
                if (this.selectedStartDate != value)
                {
                    this.selectedStartDate = value;
                    this.OnPropertyChanged("SelectedStartDate");
                    this.OnPropertyChanged("UniqueVisitorsForSelectedPeriod");
                    this.OnPropertyChanged("NewVisitorsForSelectedPeriod");
                    this.OnPropertyChanged("SessionsForSelectedPeriod");
                    this.OnPropertyChanged("PageViewsForSelectedPeriod");
                    this.OnPropertyChanged("PageViewsPerVisitorForSelectedPeriod");
                    this.OnPropertyChanged("PageViewsPerHourForSelectedPeriod");
                    this.OnPropertyChanged("HourlyDistributionsForSelectedPeriod");
                    this.OnPropertyChanged("TrafficInfosForSelectedPeriod");
                }
            }
        }

        private DateTime selectedEndDate;
        public DateTime SelectedEndDate
        {
            get { return this.selectedEndDate; }

            set
            {
                if (this.selectedEndDate != value)
                {
                    this.selectedEndDate = value;
                    this.OnPropertyChanged("SelectedEndDate");
                    this.OnPropertyChanged("UniqueVisitorsForSelectedPeriod");
                    this.OnPropertyChanged("NewVisitorsForSelectedPeriod");
                    this.OnPropertyChanged("SessionsForSelectedPeriod");
                    this.OnPropertyChanged("PageViewsForSelectedPeriod");
                    this.OnPropertyChanged("PageViewsPerVisitorForSelectedPeriod");
                    this.OnPropertyChanged("PageViewsPerHourForSelectedPeriod");
                    this.OnPropertyChanged("HourlyDistributionsForSelectedPeriod");
					this.OnPropertyChanged("TrafficInfosForSelectedPeriod"); 
                }
            }
        }

        private DateTime periodStart;
        public DateTime PeriodStart
        {
            get { return this.periodStart; }

            set
            {
                if (this.periodStart != value)
                {
                    this.periodStart = value;
                    this.OnPropertyChanged("PeriodStart");
                }
            }
        }

        private DateTime periodEnd;
        public DateTime PeriodEnd
        {
            get { return this.periodEnd; }

            set
            {
                if (this.periodEnd != value)
                {
                    this.periodEnd = value;
                    this.OnPropertyChanged("PeriodEnd");
                }
            }
        }

        private DateTime visiblePeriodEnd;
        public DateTime VisiblePeriodEnd
        {
            get { return this.visiblePeriodEnd; }

            set
            {
                if (this.visiblePeriodEnd != value)
                {
                    this.visiblePeriodEnd = value;
                    this.OnPropertyChanged("VisiblePeriodEnd");
                }
            }
        }

        private DateTime visiblePeriodStart;
        public DateTime VisiblePeriodStart
        {
            get { return this.visiblePeriodStart; }

            set
            {
                if (this.visiblePeriodStart != value)
                {
                    this.visiblePeriodStart = value;
                    this.OnPropertyChanged("VisiblePeriodStart");
                }
            }
        }

        private TimeSpan minSelectionRange;
        public TimeSpan MinSelectionRange
        {
            get { return this.minSelectionRange; }

            set
            {
                if (this.minSelectionRange != value)
                {
                    this.minSelectionRange = value;
                    this.OnPropertyChanged("MinSelectionRange");
                }
            }
        }

        public int UniqueVisitorsForSelectedPeriod
        {
            get
            {
                int uniqueVisitors = 0;
                foreach (var sInfo in this.ServerInfos)
                {
                    if (this.SelectedStartDate <= sInfo.Date && sInfo.Date < this.SelectedEndDate)
                    {
                        uniqueVisitors += sInfo.UniqueVisitors;
                    }
                }

                return uniqueVisitors;
            }
        }

        public int NewVisitorsForSelectedPeriod
        {
            get
            {
                int newVisitors = 0;
                foreach (var sInfo in this.ServerInfos)
                {
                    if (this.SelectedStartDate <= sInfo.Date && sInfo.Date < this.SelectedEndDate)
                    {
                        newVisitors += sInfo.NewVisitors;
                    }
                }

                return newVisitors;
            }
        }

        public int SessionsForSelectedPeriod
        {
            get
            {
                int sessions = 0;
                foreach (var sInfo in this.ServerInfos)
                {
                    if (this.SelectedStartDate <= sInfo.Date && sInfo.Date < this.SelectedEndDate)
                    {
                        sessions += sInfo.Sessions;
                    }
                }

                return sessions;
            }
        }

        public int PageViewsForSelectedPeriod
        {
            get
            {
                int pageViews = 0;
                foreach (var sInfo in this.ServerInfos)
                {
                    if (this.SelectedStartDate <= sInfo.Date && sInfo.Date < this.SelectedEndDate)
                    {
                        pageViews += sInfo.PageViews;
                    }
                }

                return pageViews;
            }
        }

        public double PageViewsPerVisitorForSelectedPeriod
        {
            get
            {
                int pageViews = 0;
                int uniqueVisitors = 0;
                foreach (var sInfo in this.ServerInfos)
                {
                    if (this.SelectedStartDate <= sInfo.Date && sInfo.Date < this.SelectedEndDate)
                    {
                        pageViews += sInfo.PageViews;
                        uniqueVisitors += sInfo.UniqueVisitors;
                    }
                }

                return (double)pageViews / uniqueVisitors;
            }
        }

        public double PageViewsPerHourForSelectedPeriod
        {
            get
            {
                int pageViews = 0;
                int infosCount = 0;
                foreach (var sInfo in this.ServerInfos)
                {
                    if (this.SelectedStartDate <= sInfo.Date && sInfo.Date < this.SelectedEndDate)
                    {
                        pageViews += sInfo.PageViews;
                        infosCount++;
                    }
                }

                return (double)pageViews / (infosCount * 24);
            }
        }

		public List<TrafficInfoItem> TrafficInfosForSelectedPeriod
        {
            get
            {
                double directTraffic = 0;
                double refferingSites = 0;
                double searchEngines = 0;
                double others = 0;

                foreach (var tInfo in this.TrafficInfos)
                {
                    if (this.SelectedStartDate <= tInfo.Date && tInfo.Date < this.SelectedEndDate)
                    {
                        directTraffic += tInfo.DirectTraffic;
                        refferingSites += tInfo.RefferingSites;
                        searchEngines += tInfo.SearchEngines;
                        others += tInfo.Others;
                    }
                }

				return new List<TrafficInfoItem> 
						{
							new TrafficInfoItem(){ Intensity = directTraffic, Type ="Direct Traffic"},
							new TrafficInfoItem(){ Intensity = refferingSites, Type ="Referring Sites"},
							new TrafficInfoItem(){ Intensity = searchEngines, Type ="Search Engines"},
							new TrafficInfoItem(){ Intensity = others, Type ="Others"},
						};
            }
        }

        public List<HourInfo> HourlyDistributionsForSelectedPeriod
        {
            get
            {
                List<HourInfo> result = new List<HourInfo>();
                List<HourInfo> hiForSelectedPeriod = new List<HourInfo>();

                foreach (var hdInfo in this.HourlyDistributions)
                {
                    if (this.SelectedStartDate <= hdInfo.Date && hdInfo.Date < this.SelectedEndDate)
                    {
                        hiForSelectedPeriod.AddRange(hdInfo.HourInfos);
                    }
                }

                var distributions = from p in hiForSelectedPeriod
                                    group p by p.Hour into g
                                    select new { Category = g.Key, TotalUnitsInStock = g.Sum(p => p.Distribution) };

                foreach (var g in distributions)
                {
                    result.Add(new HourInfo(g.Category, g.TotalUnitsInStock));
                }

                return result;
            }
        }
    }
}
