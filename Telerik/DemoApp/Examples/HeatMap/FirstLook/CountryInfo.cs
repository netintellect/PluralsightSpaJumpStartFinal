using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Telerik.Windows.Examples.HeatMap.FirstLook.Models
{
    public class CountryInfo
    {
        public string CountryName { get; set; }
        public int Year { get; set; }
        public double HDI { get; set; }

        public CountryInfo(string countryName, int year, double hdi)
        {
            this.CountryName = countryName;
            this.Year = year;
            this.HDI = hdi;
        }
    }
}
