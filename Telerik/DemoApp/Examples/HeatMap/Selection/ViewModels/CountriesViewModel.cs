using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Globalization;
using Telerik.Windows.Examples.HeatMap.Selection.Models;
using System.Collections.ObjectModel;
using System.Windows.Media;

namespace Telerik.Windows.Examples.HeatMap.Selection.ViewModels
{
    public class CountriesViewModel : DataSourceViewModelBase
    {
        private IEnumerable<CountryInfo> data;
        private CountryInfo selectedCountry;
        private IEnumerable<CountryInfo> selectedCountryData;
        private ObservableCollection<CountryInfo> selectedCountries;
        private Color unemploymentRateColor;
        private bool isInitialLoad = true;

        public CountriesViewModel()
        {
            this.SelectedCountries = new ObservableCollection<CountryInfo>();
            this.selectedCountries.CollectionChanged += this.SelectedCountries_CollectionChanged;
            this.GetData("CountryInflationCorruptionData.csv");
        }

        public IEnumerable<CountryInfo> Data
        {
            get { return this.data; }
            private set
            {
                if (this.data != value)
                {
                    this.data = value;
                    this.OnPropertyChanged(() => this.Data);
                    this.UpdateSelectedCountryData();
                }
            }
        }

        public CountryInfo SelectedCountry
        {
            get { return this.selectedCountry; }
            private set
            {
                if (this.selectedCountry != value)
                {
                    this.selectedCountry = value;
                    this.OnPropertyChanged(() => this.SelectedCountry);
                }
            }
        }

        public IEnumerable<CountryInfo> SelectedCountryData
        {
            get { return this.selectedCountryData; }
            private set
            {
                if (this.selectedCountryData != value)
                {
                    this.selectedCountryData = value;
                    this.OnPropertyChanged(() => this.SelectedCountryData);
                }
            }
        }

        public ObservableCollection<CountryInfo> SelectedCountries
        {
            get { return this.selectedCountries; }
            private set
            {
                if (this.selectedCountries != value)
                {
                    this.selectedCountries = value;
                    this.OnPropertyChanged(() => this.SelectedCountries);
                }
            }
        }

        public Color UnemploymentRateColor
        {
            get { return this.unemploymentRateColor; }
            set
            {
                if (this.unemploymentRateColor != value)
                {
                    this.unemploymentRateColor = value;
                    this.OnPropertyChanged(() => this.UnemploymentRateColor);
                }
            }
        }

        private void UpdateSelectedCountryData()
        {
            if (this.isInitialLoad && this.SelectedCountries.Count == 0)
            {
                this.isInitialLoad = false;
                this.SelectedCountries.Add(this.Data.FirstOrDefault(c => c.CountryName == "France"));
            }

            if (this.Data != null && this.SelectedCountries.Count > 0)
            {
                this.SelectedCountry = this.SelectedCountries[0];
                this.SelectedCountryData = this.Data.Where(c => c.CountryName == this.SelectedCountries[0].CountryName);
            }
        }

        private void SelectedCountries_CollectionChanged(object sender, System.Collections.Specialized.NotifyCollectionChangedEventArgs e)
        {
            this.UpdateSelectedCountryData();
        }

        protected override void GetDataCompleted(System.Collections.IEnumerable data)
        {
            this.Data = data as IEnumerable<CountryInfo>;
        }

        protected override System.Collections.IEnumerable ParseData(System.IO.TextReader dataReader)
        {
            string line;
            List<CountryInfo> countryInfos = new List<CountryInfo>();
            dataReader.ReadLine();

            while ((line = dataReader.ReadLine()) != null)
            {
                if (string.IsNullOrEmpty(line))
                    continue;

                string[] data = line.Split(',');
                string countryName = data[0];
                int year = Int32.Parse(data[1]);
                double uRate = Double.Parse(data[2], CultureInfo.InvariantCulture);
                double cIndex = string.IsNullOrEmpty(data[3]) ? double.NaN : Double.Parse(data[3], CultureInfo.InvariantCulture);
                double inflation = Double.Parse(data[4], CultureInfo.InvariantCulture);
                double gdp = Double.Parse(data[5], CultureInfo.InvariantCulture);

                countryInfos.Add(new CountryInfo(countryName, year, uRate, cIndex, inflation, gdp));
            }

            return countryInfos;
        }
    }
}
