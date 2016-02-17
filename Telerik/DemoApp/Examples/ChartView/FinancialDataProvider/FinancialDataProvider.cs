using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Threading;
using System.Threading.Tasks;

namespace Telerik.Windows.Examples.ChartView
{
    internal class FinancialDataProvider
    {
        public FinancialDataProvider()
        {
            this.onlineDataProviders = new List<StockDataProvider>();
            this.onlineDataProviders.Add(new YahooStockDataProvider());
        }

        private readonly List<StockDataProvider> onlineDataProviders;

        public static bool IsConnectedToInternet
        {
            get
            {
#if WPF
                int Description;
                return InternetGetConnectedState(out Description, 0);
#else
                return true;
#endif
            }
        }

        public List<StockDataProvider> OnlineDataProviders
        {
            get
            {
                return this.onlineDataProviders;
            }
        }

        public OfflineStockDataProvider OfflineDataProvider
        {
            get;
            set;
        }

        public Task<StockData> GetFinancialDataAsync(string symbol, int numYearsOfHistory)
        {
            return Task.Factory.StartNew(() => this.GetFinancialData(symbol, numYearsOfHistory), CancellationToken.None, TaskCreationOptions.None, TaskScheduler.Default);
        }

        public virtual StockData GetFinancialDataFromInternet(string symbol, int numYearsOfHistory)
        {
            var tasks = this.onlineDataProviders.Select(provider => provider.GetDataAsync(symbol, numYearsOfHistory)).ToList();
            StockData result = null;

            while (tasks.Any())
            {
                int timeout = 15 * 1000;  // 15 secs:
                int winner = Task.WaitAny(tasks.ToArray(), timeout);  // no task-based exception thrown here:

                if (winner < 0)  // timeout!
                    break;

                // was task successful?  Check exception here:
                if (tasks[winner].Exception == null)  // success!
                {
                    result = tasks[winner].Result;
                    tasks.RemoveAt(winner);
                    break;
                }

                // else this task failed, wait for next to finish:
                tasks.RemoveAt(winner);
            }

            return result;
        }

#if WPF
        [DllImport("wininet.dll")]
        private extern static bool InternetGetConnectedState(out int Description, int ReservedValue);
#endif

        private StockData GetFinancialData(string symbol, int numYearsOfHistory)
        {
            if (IsConnectedToInternet)
            {
                StockData data = this.GetFinancialDataFromInternet(symbol, numYearsOfHistory);
                if (data != null)
                {
                    return data;
                }
            }

            if (this.OfflineDataProvider != null)
            {
                return this.OfflineDataProvider.GetData();
            }

            return null;
        }
    }
}
