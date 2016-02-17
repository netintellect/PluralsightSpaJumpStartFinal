using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Telerik.Windows.Controls;

namespace Telerik.Windows.Examples.Chart.LogarithmicScale
{
    public class ExampleViewModel : ViewModelBase
    {
        private List<CountryStats> data;

        public List<CountryStats> Data
        {
            get
            {
                return this.data;
            }
            set
            {
                if (this.data != value)
                {
                    this.data = value;
                    this.OnPropertyChanged("Data");
                }
            }
        }

        public ExampleViewModel()
        {
            List<CountryStats> list = new List<CountryStats>();

            list.Add(new CountryStats("China", 1336950000));
            list.Add(new CountryStats("USA", 309068000));
            list.Add(new CountryStats("Japan", 127380000));
            list.Add(new CountryStats("Germany", 81757000));
            list.Add(new CountryStats("South Korea", 49773000));
            list.Add(new CountryStats("Bulgaria", 7577000));
            list.Add(new CountryStats("Macedonia", 2048000));
            list.Add(new CountryStats("Iceland", 317630));
            list.Add(new CountryStats("Cayman Islands", 56000));
            list.Add(new CountryStats("Vatican City", 800));

            this.Data = list;
        }
    }
}