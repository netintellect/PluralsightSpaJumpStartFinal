using System;
using System.Collections.Generic;
using System.Linq;

namespace Telerik.Windows.Examples.DataBar.FirstLook
{
    public class CompensationViewModel
    {
        public CompensationViewModel()
        {
            this.Statistics = new List<CountrySalaryStatistic>() 
            {
                new CountrySalaryStatistic("Norway", 57.53, 14.61, 17.7, 8.6, 4.3),
                new CountrySalaryStatistic("Switzerland", 53.2, 20.09, 15.45, 1.7, -2.3),
                new CountrySalaryStatistic("Belgium", 50.7, 20.3, 32.33, -3.6, 1.3),
                new CountrySalaryStatistic("Denmark", 45.48, 16.75, 6.75, -2.2, 2.7),
                new CountrySalaryStatistic("Sweden", 43.81, 10.41, 33.03, 7.7, 1.3),
                new CountrySalaryStatistic("Germany", 43.76, 19.26, 21.76, -4.6, 0.2),
                new CountrySalaryStatistic("Finland", 42.3, 19.05, 21.7, -3.7, 1.2),
                new CountrySalaryStatistic("Austria", 41.07, 21.52, 25.71, -6.6, -1.9),
                new CountrySalaryStatistic("Netherlands", 40.92, 21.36, 21.21, -3.7, 1.2),
                new CountrySalaryStatistic("Australia", 40.6, 9.48, 20.2, 18.5, 2.1),
                new CountrySalaryStatistic("France", 40.55, 16.15, 31.94, -3.1, 1.8),
                new CountrySalaryStatistic("Ireland", 36.3, 15.51, 12.04, -4.6, 0.3),
                new CountrySalaryStatistic("Canada", 35.67, 9.59, 22.51, 17.1, 5.7),
                new CountrySalaryStatistic("United States", 34.74, 8.49, 24.38, 1.9, 1.9),
                new CountrySalaryStatistic("Italy", 33.41, 14.61, 28.64, -2.2, 2.8),
                new CountrySalaryStatistic("Japan", 31.99, 24.91, 17.85, 5.4, -1.3),
                new CountrySalaryStatistic("United Kingdom", 29.44, 13.21, 14.91, -0.1, 1.2),
                new CountrySalaryStatistic("Spain", 26.6, 19.44, 25.9, -4.3, 0.6),                 
                new CountrySalaryStatistic("Greece", 22.19, 18.79, 22.58, -1.6, 3.4),
                new CountrySalaryStatistic("New Zealand", 20.57, 12.74, 3.21, 16.5, 2.7),
                new CountrySalaryStatistic("Israel", 20.12, 7.36, 16.7, 9.3, 3.9),
                new CountrySalaryStatistic("Singapore", 19.1, 17.49, 16.13, 8.9, 2), 
                new CountrySalaryStatistic("Argentina", 12.66, 13.98, 17.38, 24.8, 31),
                new CountrySalaryStatistic("Portugal", 11.72, 19.28, 19.62, -3.4, 1.6), 
                new CountrySalaryStatistic("Czech Republic", 11.5, 13.39, 27.3, 0.9, 1.1), 
                new CountrySalaryStatistic("Slovakia", 10.72, 16.32, 27.52, -4.6, 0.2),
                new CountrySalaryStatistic("Brazil", 10.08, 14.19, 32.14, 23.9, 9.2), 
                new CountrySalaryStatistic("Estonia", 9.47, 9.29, 26.4, -5.5, -0.9),                
                new CountrySalaryStatistic("Hungary", 8.4, 19.64, 23.81, -2.7, 0),
                new CountrySalaryStatistic("Poland", 8.01, 23.6, 15.73, 6.9, 3.3),
                new CountrySalaryStatistic("Philippines", 1.9, 16.32, 9.47, 4.8, 10.8),
            };
        }

        public IEnumerable<CountrySalaryStatistic> Statistics { get; private set; }

        public double MaxHourlyCompensationCosts
        {
            get
            {
                double maxHourlyCompensationCosts = this.Statistics.Max(stat => stat.HourlyCompensationCosts);
                double maxAxisValue = Math.Ceiling(maxHourlyCompensationCosts / 10) * 10;
                return maxAxisValue;
            }
        }

        public double MinCompensationPercent
        {
            get
            {
                double minPercentDollars = this.Statistics.Min(info => info.CompensationInDollarsComparedToLastYear);
                double minPercentNatCurrency = this.Statistics.Min(info => info.CompensationInNationalCurrencyComparedToLastYear);
                double minPercent = Math.Min(minPercentDollars, minPercentNatCurrency);
                double minAxisValue = Math.Floor(minPercent / 10) * 10;
                return minAxisValue;
            }
        }

        public double MaxCompensationPercent
        {
            get
            {
                double maxPercentDollars = this.Statistics.Max(info => info.CompensationInDollarsComparedToLastYear);
                double maxPercentNatCurrency = this.Statistics.Max(info => info.CompensationInNationalCurrencyComparedToLastYear);
                double maxPercent = Math.Max(maxPercentDollars, maxPercentNatCurrency);
                double maxAxisValue = ((int)(maxPercent / 20)) * 20;
                return maxAxisValue;
            }
        }
    }
}
