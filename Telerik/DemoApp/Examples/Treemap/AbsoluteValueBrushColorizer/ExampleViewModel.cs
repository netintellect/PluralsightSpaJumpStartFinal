using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Collections;
using System.IO;
using System.Globalization;

namespace Telerik.Windows.Examples.Treemap.AbsoluteValueBrushColorizer
{
    public class ExampleViewModel : DataSourceViewModelBase
    {
        private List<StockInfo> data;

        public List<StockInfo> Data
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
            this.GetData("Stocks.csv");
        }

        protected override void GetDataCompleted(IEnumerable data)
        {
            this.Data = data as List<StockInfo>;
        }

        protected override IEnumerable ParseData(TextReader dataReader)
        {
            string line;
            List<StockInfo> treemapData = new List<StockInfo>();

            while ((line = dataReader.ReadLine()) != null)
            {
                if (string.IsNullOrEmpty(line))
                    continue;

                string[] data = line.Split(',');

                StockInfo dataItem = new StockInfo();

                dataItem.StockSymbol = data[0];
                dataItem.ChangeRate = double.Parse(data[1], CultureInfo.InvariantCulture);
                dataItem.MarketValue = double.Parse(data[2], CultureInfo.InvariantCulture);

                treemapData.Add(dataItem);
            }

            return treemapData;
        }
    }
}
