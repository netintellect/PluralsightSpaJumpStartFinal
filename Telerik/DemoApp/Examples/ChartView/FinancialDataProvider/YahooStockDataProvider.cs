using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Net;
using System.Threading.Tasks;

namespace Telerik.Windows.Examples.ChartView
{
    internal class YahooStockDataProvider : StockDataProvider
    {
        public override Task<StockData> GetDataAsync(string symbol, int numYearsOfHistory)
        {
            DateTime today = DateTime.Today;

            string url = string.Format("http://ichart.finance.yahoo.com/table.csv?s={0}&d={1}&e={2}&f={3}&g=d&a={1}&b={2}&c={4}&ignore=.csv",
                symbol,
                today.Month - 1,
                today.Day - 1,
                today.Year,
                today.Year - numYearsOfHistory);

            HttpWebRequest WebRequestObject = (HttpWebRequest)HttpWebRequest.Create(url);
            RequestState state = new RequestState(WebRequestObject, "http://finance.yahoo.com/");
            IAsyncResult iar = WebRequestObject.BeginGetResponse(new AsyncCallback(this.WebResponseCallback), state);
            state.TaskSource = new TaskCompletionSource<StockData>(iar.AsyncState);
            return state.TaskSource.Task;
        }

        private void WebResponseCallback(IAsyncResult iar)
        {
            RequestState state = (RequestState)iar.AsyncState;
            try
            {
                WebResponse response = state.Request.EndGetResponse(iar);

                List<Stock> prices = this.GetData(response);

                if (prices.Count == 0)
                {
                    throw new Exception("site returned no data");
                }

                state.TaskSource.SetResult(new StockData(state.DataSource, prices));
            }
            catch (Exception ex)
            {
                state.TaskSource.SetException(ex);
            }
        }

        private List<Stock> GetData(WebResponse response)
        {
            //
            // finance.yahoo.com, data format:
            //
            //   Date (YYYY-MM-DD),Open,High,Low,Close,Volume,Adj Close
            //

            List<Stock> stocks = new List<Stock>();

            using (Stream WebStream = response.GetResponseStream())
            {
                using (StreamReader reader = new StreamReader(WebStream))
                {
                    reader.ReadLine(); // skip title row

                    while (!reader.EndOfStream)
                    {
                        string record = reader.ReadLine();
                        string[] tokens = record.Split(',');

                        Stock data = new Stock();
                        data.Date = DateTime.Parse(tokens[0], CultureInfo.InvariantCulture);
                        data.Open = decimal.Parse(tokens[1], CultureInfo.InvariantCulture);
                        data.High = decimal.Parse(tokens[2], CultureInfo.InvariantCulture);
                        data.Low = decimal.Parse(tokens[3], CultureInfo.InvariantCulture);
                        data.Close = decimal.Parse(tokens[4], CultureInfo.InvariantCulture);
                        data.Volume = decimal.Parse(tokens[5], CultureInfo.InvariantCulture);
                        stocks.Add(data);
                    }
                }
            }

            return stocks;
        }
    }
}
