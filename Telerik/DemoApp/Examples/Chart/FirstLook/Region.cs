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

namespace Telerik.Windows.Examples.Chart.FirstLook
{
    public class Region : OrderView
    {
        private IEnumerable<OrderView> _countries;

        public IEnumerable<OrderView> Countries
        {
            get
            {
                return this._countries;
            }
        }

        public Region(string name, IEnumerable<OrderData> data)
            : base(name, data)
        {
            this._countries = this.MapCountries(data);
        }

        public IEnumerable<OrderData> GetCountryData(IEnumerable<OrderData> data, string country)
        {
            List<OrderData> orders = new List<OrderData>();

            foreach (OrderData order in data)
            {
                if (order.Country == country)
                    orders.Add(order);
            }

            return orders;
        }

        IEnumerable<string> GetCountries(IEnumerable<OrderData> data)
        {
            List<string> countries = new List<string>();

            foreach (OrderData order in data)
            {
                if (!countries.Contains(order.Country))
                    countries.Add(order.Country);
            }

            return countries;
        }

        private List<OrderView> MapCountries(IEnumerable<OrderData> data)
        {
            List<OrderView> countries = new List<OrderView>();

            foreach (string country in GetCountries(data))
            {
                countries.Add(new Country(country, this.GetCountryData(data, country)));
            }
            return countries;
        }

    }
}
