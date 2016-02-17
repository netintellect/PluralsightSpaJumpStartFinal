using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Media;
using System.Collections.ObjectModel;
using Telerik.Windows.Examples.ChartView.Selection.Models;
using Telerik.Windows.Examples.ChartView.Selection.Utilities;

namespace Telerik.Windows.Examples.ChartView.Selection.ViewModels
{
    public class ExampleViewModel
    {
#if SILVERLIGHT
        private const string ShapeRelativeUriFormat = "DataSources/Geospatial/europe.{0}";
#else
        private const string ShapeRelativeUriFormat = "/ChartView;component/DataSources/europe.{0}";
#endif
        private const string ShapeExtension = "shp";
        private const string DbfExtension = "dbf";

        public List<List<CountryData>> GDPData { get; set; }
        public List<CountryData> PopulationData { get; set; }

        public ExampleViewModel()
        {
            int[] years = { 2007, 2008, 2009, 2010, 2011, 2012, };

            this.GDPData = new List<List<CountryData>>() 
            {
                CreateCountryData(CountryUtilities.GermanyCountryName, years),
                CreateCountryData(CountryUtilities.FranceCountryName, years),
                CreateCountryData(CountryUtilities.UnitedKingdomCountryName, years),
                CreateCountryData(CountryUtilities.ItalyCountryName, years),
                CreateCountryData(CountryUtilities.SpainCountryName, years),
            };

            this.PopulationData = new List<CountryData>() 
            {
                CountryUtilities.CreateCountryData(CountryUtilities.SpainCountryName, 2012),                
                CountryUtilities.CreateCountryData(CountryUtilities.ItalyCountryName, 2012),
                CountryUtilities.CreateCountryData(CountryUtilities.UnitedKingdomCountryName, 2012),
                CountryUtilities.CreateCountryData(CountryUtilities.FranceCountryName, 2012),
                CountryUtilities.CreateCountryData(CountryUtilities.GermanyCountryName, 2012),
            };
        }

        private List<CountryData> CreateCountryData(string countryName, IEnumerable<int> years)
        {
            var data = new List<CountryData>();

            foreach (var year in years)
            {
                var countryData = CountryUtilities.CreateCountryData(countryName, year);
                data.Add(countryData);
            }

            return data;
        }

        public Uri ShapeSourceUri
        {
            get
            {
                return new Uri(string.Format(ShapeRelativeUriFormat, ShapeExtension), UriKind.Relative);
            }
        }

        public Uri ShapeDataSourceUri
        {
            get
            {
                return new Uri(string.Format(ShapeRelativeUriFormat, DbfExtension), UriKind.Relative);
            }
        }
    }
}
