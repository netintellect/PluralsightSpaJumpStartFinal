using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Threading;
using System.Threading.Tasks;

namespace Telerik.Windows.Examples.ChartView
{
    internal class OfflineStockDataProvider
    {
        public OfflineStockDataProvider(string filename)
        {
            this.filename = filename;
#if WPF
            this.dataURI = new Uri(string.Format(this.WpfPath, this.filename), UriKind.RelativeOrAbsolute);
#else
            this.dataURI = new Uri(Telerik.Windows.Examples.ChartView.URIHelper.CurrentApplicationURL, string.Format(this.SilverlightPath, this.filename));
#endif
        }

        protected string filename;
        protected Uri dataURI;

        protected virtual string SilverlightPath
        {
            get
            {
                return "DataSources/{0}";
            }
        }

        protected virtual string WpfPath
        {
            get
            {
                return "/ChartView;component/DataSources/{0}";
            }
        }

        public StockData GetData()
        {
            return this.GetDataFromFile();
        }

        public Task<StockData> GetDataAsync()
        {
            return Task.Factory.StartNew(() => this.GetDataFromFile(), CancellationToken.None, TaskCreationOptions.AttachedToParent, TaskScheduler.Default);
        }

#if WPF
        protected StockData GetDataFromFile()
        {
            System.Windows.Resources.StreamResourceInfo streamInfo = System.Windows.Application.GetResourceStream(this.dataURI);
            List<Stock> stockData = null;
            using (StreamReader fileReader = new StreamReader(streamInfo.Stream))
            {
                stockData = this.ParseData(fileReader);
            }
            return new StockData(this.filename, stockData);
        }
#else
        protected StockData GetDataFromFile()
        {
            List<Stock> stockData = null;

            var tcs = new TaskCompletionSource<string>();
            System.Net.WebClient dataRetriever = new System.Net.WebClient();
            dataRetriever.DownloadStringCompleted += (s, e) =>
            {
                if (e.Error != null)
                {
                    tcs.TrySetException(e.Error);
                }
                else if (e.Cancelled)
                {
                    tcs.TrySetCanceled();
                }
                else
                {
                    tcs.TrySetResult(e.Result);
                }
            };
            dataRetriever.DownloadStringAsync(this.dataURI);
            
            using (StringReader dataReader = new StringReader(tcs.Task.Result))
            {
                stockData = this.ParseData(dataReader);
            }

            return new StockData(this.filename, stockData);
        }
#endif

        protected virtual List<Stock> ParseData(TextReader dataReader)
        {
            string line;
            List<Stock> chartData = new List<Stock>();

            while ((line = dataReader.ReadLine()) != null)
            {
                if (string.IsNullOrEmpty(line))
                    continue;

                string[] tokens = line.Split(',');

                Stock data = new Stock();
                data.Date = DateTime.Parse(tokens[0], CultureInfo.InvariantCulture);
                data.Open = decimal.Parse(tokens[1], CultureInfo.InvariantCulture);
                data.High = decimal.Parse(tokens[2], CultureInfo.InvariantCulture);
                data.Low = decimal.Parse(tokens[3], CultureInfo.InvariantCulture);
                data.Close = decimal.Parse(tokens[4], CultureInfo.InvariantCulture);
                data.Volume = decimal.Parse(tokens[5], CultureInfo.InvariantCulture);

                chartData.Add(data);
            }

            return chartData;
        }
    }
}
