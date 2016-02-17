using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Telerik.Windows.Examples.HeatMap.FirstLook.Models;
using Telerik.Windows.Data;
using System.Globalization;

namespace Telerik.Windows.Examples.HeatMap.FirstLook.ViewModels
{
    public class MainViewModel : DataSourceViewModelBase
    {
        public IEnumerable<CountryInfo> data;
        public IEnumerable<CountryInfo> Data 
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

        public MainViewModel()
        {
            this.GetData("HDIData.csv");
        }

        protected override void GetDataCompleted(System.Collections.IEnumerable data)
        {
            IEnumerable<CountryInfo> countryInfos = data as IEnumerable<CountryInfo>;
            this.Data = new List<CountryInfo>(countryInfos);
        }

        protected override System.Collections.IEnumerable ParseData(System.IO.TextReader dataReader)
        {
            string line;
            List<CountryInfo> countryInfos = new List<CountryInfo>();

            while ((line = dataReader.ReadLine()) != null)
            {
                if (string.IsNullOrEmpty(line))
                    continue;

                string[] data = line.Split(',');
                string countryName = data[0];
                int year = Int32.Parse(data[1]);
                double hdi = Double.Parse(data[2], CultureInfo.InvariantCulture);
                
                countryInfos.Add(new CountryInfo(countryName, year, hdi));
            }

            return countryInfos;
        }
    }
}
