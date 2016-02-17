using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Telerik.Windows.Controls.Map;
using Telerik.Windows.Examples.ChartView.Selection.Models;
using System.Windows.Media;

namespace Telerik.Windows.Examples.ChartView.Selection.Utilities
{
    public static class CountryUtilities
    {
        public const string UnitedKingdomCountryName = "United Kingdom";
        public const string GermanyCountryName = "Germany";
        public const string FranceCountryName = "France";
        public const string SpainCountryName = "Spain";
        public const string ItalyCountryName = "Italy";
        public const string ExtendedPropertyCountryName = "CNTRY_NAME";

        public static Color DefaultCountryColor { get; set; }
        public static Color SelectedCountryColor { get; set; }
        public static Color CountryBorderColor { get; set; }
        private readonly static Dictionary<string, double> nameAndYearToGDP;
        public static Dictionary<string, Color> CountryToColorDictionary;

        public static SolidColorBrush GetBrush(string countryName)
        {
            return new SolidColorBrush(GetColor(countryName));
        }

        public static Color GetColor(string countryName)
        {
            if (CountryUtilities.CountryToColorDictionary.ContainsKey(countryName))
                return CountryUtilities.CountryToColorDictionary[countryName];
            else
                return CountryUtilities.DefaultCountryColor;
        }

        public static string ExtractNameFromMapShapeExtendedData(MapShape mapShape)
        {
            return (string)mapShape.ExtendedData.GetValue(ExtendedPropertyCountryName);
        }

        public static double GetPopulation(string countryName, int year)
        {
            if (year != 2012)
                return 0;

            switch (countryName)
            {
                case SpainCountryName: return 46777373;
                case GermanyCountryName: return 81799600;
                case ItalyCountryName: return 59715625;
                case FranceCountryName: return 63601002;
                case UnitedKingdomCountryName: return 62262000;

                default:
                    return 0;
            }
        }

        public static double GetGDP(string countryName, int year)
        {
            string nameAndYear = string.Format("{0}_{1}", countryName, year);
            if (nameAndYearToGDP.ContainsKey(nameAndYear))
                return nameAndYearToGDP[nameAndYear];
            else
                return 0;
        }

        public static CountryData CreateCountryData(string countryName, int year)
        {
            CountryData countryData = new CountryData
            {
                Name = countryName,
                Year = year,
                GDP = GetGDP(countryName, year),
                Population = GetPopulation(countryName, year),
            };

            return countryData;
        }

        static CountryUtilities()
        {
            nameAndYearToGDP = new Dictionary<string, double>() 
            {
                { "France_2007", 1886792.10 },
                { "Germany_2007", 2428500.00 },
                { "Italy_2007", 1554198.90 },
                { "Spain_2007", 1053161.00 },
                { "United Kingdom_2007", 2054237.70 },
                
                { "France_2008", 1933195.00 },
                { "Germany_2008", 2473800.00 },
                { "Italy_2008", 1575143.90 },
                { "Spain_2008", 1087749.00 },
                { "United Kingdom_2008", 1800710.80 },
                
                { "France_2009", 1889231.00 },
                { "Germany_2009", 2374500.00 },
                { "Italy_2009", 1526790.40 },
                { "Spain_2009", 1047831.00 },
                { "United Kingdom_2009", 1564467.90 },

                { "France_2010", 1932801.50 },
                { "Germany_2010", 2476800.00 },
                { "Italy_2010", 1556028.60 },
                { "Spain_2010", 1051342.00 },
                { "United Kingdom_2010", 1706301.90 },

                { "France_2011", 1987699.40 },
                { "Germany_2011", 2570000.00 },
                { "Italy_2011", 1586209.00 },
                { "Spain_2011", 1074940.50 },
                { "United Kingdom_2011", 1747315.60 },

                { "France_2012", 2027969.80 },
                { "Germany_2012", 2626427.90 },
                { "Italy_2012", 1617154.70 },
                { "Spain_2012", 1094290.00 },
                { "United Kingdom_2012", 1862190.70 },

                { "Austria_2012", 310133.30 },
                { "Belgium_2012", 381779.90 },
                { "Czech Republic_2012", 155688.80 },
                { "Denmark_2012", 249122.90 },
                { "Estonia_2012", 17006.00 },
                { "Finland_2012", 198251.50 },
                { "Hungary_2012", 95398.70 },
                { "Ireland_2012", 158864.90 },
                { "Latvia_2012", 20701.60 },
                { "Lithuania_2012", 32342.50 },
                { "Luxembourg_2012", 42893.00 },
                { "Malta_2012", 6690.00 },
                { "Netherlands_2012", 622714.00 },
                { "Poland_2012", 355346.30 },
                { "Portugal_2012", 168286.40 },
                { "Romania_2012", 136278.10 },
                { "Slovakia_2012", 71614.00 },
                { "Slovenia_2012", 38018.40 },
                { "Sweden_2012", 396188.40 },
                { "Switzerland_2012", 502272.1 },
            };
        }
    }
}
