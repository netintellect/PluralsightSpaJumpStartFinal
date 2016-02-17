using System;
using System.Collections.Generic;

namespace Telerik.Windows.Examples.ChartView
{
    public class StockData
    {
        public string DataSourceName { get; private set; }

        public IEnumerable<Stock> Stocks { get; private set; }

        public StockData(string dataSourceName, IEnumerable<Stock> stocks)
        {
            this.DataSourceName = dataSourceName;
            this.Stocks = stocks;
        }
    }

    public class Stock
    {
        public DateTime Date { get; set; }

        public decimal Open { get; set; }

        public decimal High { get; set; }

        public decimal Low { get; set; }

        public decimal Close { get; set; }

        public decimal Volume { get; set; }
    }
}
