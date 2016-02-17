using System;
using System.Net;
using System.Threading.Tasks;

namespace Telerik.Windows.Examples.ChartView
{
    internal abstract class StockDataProvider
    {
        public abstract Task<StockData> GetDataAsync(string symbol, int numYearsOfHistory);

        protected class RequestState
        {
            public RequestState(HttpWebRequest request, string dataSourceName)
            {
                this.Request = request;
                this.DataSource = dataSourceName;

                this.TaskSource = new TaskCompletionSource<StockData>();
            }

            public HttpWebRequest Request;
            public string DataSource;
            public TaskCompletionSource<StockData> TaskSource;
        }
    }
}
