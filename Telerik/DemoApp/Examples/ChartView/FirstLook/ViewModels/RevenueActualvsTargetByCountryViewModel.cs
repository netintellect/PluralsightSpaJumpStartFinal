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
using System.Collections.Generic;
using System.IO;
using System.Collections;
using System.Globalization;

namespace Telerik.Windows.Examples.ChartView.FirstLook
{
    public class RevenueActualvsTargetByCountryViewModel : DataSourceViewModelBase
    {
        List<CountryRevenue> _countryRevenues;

        public List<CountryRevenue> CountryRevenues
        {
            get
            {
                return _countryRevenues;
            }
            set
            {
                if (this._countryRevenues != value)
                {
                    this._countryRevenues = value;
                    this.OnPropertyChanged("CountryRevenues");
                }
            }
        }

        public RevenueActualvsTargetByCountryViewModel()
        {
            this.GetData("RevenueActualvsTargetByCountry.csv");
        }

        protected override void GetDataCompleted(System.Collections.IEnumerable data)
        {
            this.CountryRevenues = data as List<CountryRevenue>;
        }

        protected override IEnumerable ParseData(TextReader dataReader)
        {
            string line;

            List<CountryRevenue> chartData = new List<CountryRevenue>();

            while ((line = dataReader.ReadLine()) != null)
            {
                if (string.IsNullOrEmpty(line))
                    continue;

                string[] data = line.Split(',');

                CountryRevenue dataItem = new CountryRevenue();
                dataItem.Country = data[0];
                dataItem.Actual = double.Parse(data[1], CultureInfo.InvariantCulture);
                dataItem.Target = double.Parse(data[2], CultureInfo.InvariantCulture);
                
                
                chartData.Add(dataItem);
            }

            return chartData;
        }
    }

    public class CountryRevenue
    {
        private string _country;
        public string Country
        {
            get
            {
                return this._country;
            }
            set
            {
                this._country = value;
            }
        }

        private double _actual;
        public double Actual
        {
            get
            {
                return this._actual;
            }
            set
            {
                this._actual = value;
            }
        }

        private double _target;
        public double Target
        {
            get
            {
                return this._target;
            }
            set
            {
                this._target = value;
            }
        }
    }
}
