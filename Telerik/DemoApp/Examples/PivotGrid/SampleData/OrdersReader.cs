using System;
using System.Collections;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Windows;
using System.Windows.Markup;
using System.ComponentModel;
using System.Windows.Resources;

namespace Telerik.Windows.Examples.PivotGrid.SampleData
{
    public class OrdersReader : IEnumerable<Order>
    {
        private Uri _UriSource;

        public OrdersReader()
        {
            this.UriSource = new Uri("/PivotGrid;component/SampleData/Orders01.txt", UriKind.RelativeOrAbsolute);
        }

        public Uri UriSource
        {
            get
            {
                return this._UriSource;
            }
            set
            {
                if (this._UriSource != value)
                {
                    this._UriSource = value;
                }
            }
        }

        public IEnumerator<Order> GetEnumerator()
        {
            StreamResourceInfo sri = null;
            try
            {
                sri = Application.GetResourceStream(this.UriSource);
            }
            catch(Exception)
            {
            }

            if (sri != null && sri.Stream != null)
            {
                Stream stream = sri.Stream;
                StreamReader reader = new StreamReader(stream);

                while (!reader.EndOfStream)
                {
                    string[] items = reader.ReadLine().Split('\t');
                    yield return new Order()
                    {
                        Date = DateTime.Parse(items[0], CultureInfo.InvariantCulture),
                        Product = items[1],
                        Quantity = int.Parse(items[2], CultureInfo.InvariantCulture),
                        Net = double.Parse(items[3], CultureInfo.InvariantCulture),
                        Promotion = items[4],
                        Advertisement = items[5]
                    };
                }
            }

        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return this.GetEnumerator();
        }
    }
}
