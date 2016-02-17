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

namespace Telerik.Windows.Examples.Chart.LogarithmicScale
{
    public class CountryStats
    {
        private string _name;
        public string Name 
        { 
            get
            {
                return this._name;
            }
            set
            {
                this._name = value;    
            }
        }

        private int _population;
        public int Population 
        { 
            get
            {
                return this._population;
            }
            set
            {
                this._population = value;    
            }
        }

        public CountryStats(string countryName, int countryPopulation)
        { 
            this.Name = countryName;
            this.Population = countryPopulation;
        }
    }
}
