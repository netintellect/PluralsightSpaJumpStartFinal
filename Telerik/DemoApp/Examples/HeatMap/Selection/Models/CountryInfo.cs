using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Telerik.Windows.Examples.HeatMap.Selection.Models
{
    public class CountryInfo
    {
        public CountryInfo(string countryName, int year, double unemploymentRate, double corruptionIndex, double inflation, double gdp)
        {
            this.CountryName = countryName;
            this.Year = year;
            this.UnemploymentRate = unemploymentRate;
            this.CorruptionIndex = corruptionIndex;
            this.Inflation = inflation;
            this.GDP = gdp;
        }

        public string CountryName { get; set; }
        public int Year { get; set; }
        public double UnemploymentRate { get; set; }
        public double CorruptionIndex { get; set; }
        public double Inflation { get; set; }
        public double GDP { get; set; }
    }
}
