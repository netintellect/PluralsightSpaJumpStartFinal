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

namespace Telerik.Windows.Examples.Chart.LegendFeatures
{
    public class GDPData
    {
        private string _country;
        private decimal _gdp;
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
        public decimal GDP
        {
            get
            {
                return this._gdp;
            }
            set
            {
                this._gdp = value;
            }
        }

        public GDPData(string country, decimal gdp)
        {
            this._gdp = gdp;
            this._country = country;
        }
    }
}
