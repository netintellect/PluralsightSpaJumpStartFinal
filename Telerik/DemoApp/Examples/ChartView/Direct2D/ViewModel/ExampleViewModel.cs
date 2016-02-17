using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Telerik.Windows.Controls;
using Telerik.Windows.Controls.ChartView;

namespace Telerik.Windows.Examples.ChartView.Direct2D
{
    public class ExampleViewModel : ViewModelBase
    {
        public ExampleViewModel()
        {
            this.GetData();
            bool isD2DAvailable = Direct2DRenderOptions.IsHardwareDeviceAvailable();
            this._renderModes = new List<RenderMode>()
            {
                new RenderMode("Default", new XamlRenderOptions()),
                new RenderMode("Bitmap", new BitmapRenderOptions()),
                new RenderMode("Direct2D", new Direct2DRenderOptions()) { IsAvailable = isD2DAvailable }
            };

            this.DefaultRenderModeIndex = isD2DAvailable ? 2 : 1;
        }

        private IEnumerable<Stock> _ibmStocks;
        private IEnumerable<Stock> _msftStocks;
        private IEnumerable<Stock> _hpqStocks;
        private List<RenderMode> _renderModes;
        private int _defaultRenderModeIndex;

        public IEnumerable<RenderMode> RenderOptions
        {
            get
            {
                return this._renderModes;
            }
        }

        public IEnumerable<Stock> IBMStocks
        {
            get
            {
                return _ibmStocks;
            }
            set
            {
                _ibmStocks = value;
                this.OnPropertyChanged("IBMStocks");
            }
        }

        public IEnumerable<Stock> MSFTStocks
        {
            get
            {
                return _msftStocks;
            }
            set
            {
                _msftStocks = value;
                this.OnPropertyChanged("MSFTStocks");
            }
        }

        public IEnumerable<Stock> HPQStocks
        {
            get
            {
                return _hpqStocks;
            }
            set
            {
                _hpqStocks = value;
                this.OnPropertyChanged("HPQStocks");
            }
        }

        public IList<Stock> LastDayStocks
        {
            get
            {
                if (this._ibmStocks == null)
                {
                    return new Stock[3];
                }

                return new Stock[]
                {
                    this._ibmStocks.First(),
                    this._msftStocks.First(),
                    this._hpqStocks.First()
                };
            }
        }

        public int DefaultRenderModeIndex
        {
            get
            {
                return this._defaultRenderModeIndex;
            }
            set
            {
                this._defaultRenderModeIndex = value;
                this.OnPropertyChanged("DefaultRenderModeIndex");
            }
        }

        private void GetData()
        {
            FinancialDataProvider provider = new FinancialDataProvider();
            provider.OfflineDataProvider = new OfflineStockDataProvider(@"Direct2D\ibm.csv");
            Task<StockData> dataTask1 = provider.GetFinancialDataAsync("IBM", 15);

            provider = new FinancialDataProvider();
            provider.OfflineDataProvider = new OfflineStockDataProvider(@"Direct2D\msft.csv");
            Task<StockData> dataTask2 = provider.GetFinancialDataAsync("MSFT", 15);

            provider = new FinancialDataProvider();
            provider.OfflineDataProvider = new OfflineStockDataProvider(@"Direct2D\hpq.csv");
            Task<StockData> dataTask3 = provider.GetFinancialDataAsync("HPQ", 15);

            Task.Factory.ContinueWhenAll(new Task[] { dataTask1, dataTask2, dataTask3 }, antecedents =>
            {
                if (!dataTask1.IsFaulted)
                {
                    this.IBMStocks = dataTask1.Result.Stocks;
                }

                if (!dataTask2.IsFaulted)
                {
                    this.MSFTStocks = dataTask2.Result.Stocks;
                }

                if (!dataTask3.IsFaulted)
                {
                    this.HPQStocks = dataTask3.Result.Stocks;
                }

                this.OnPropertyChanged("LastDayStocks");
            }, CancellationToken.None, TaskContinuationOptions.None, TaskScheduler.FromCurrentSynchronizationContext());
        }
    }

    public class RenderMode
    {
        public RenderMode(string name, ChartRenderOptions options)
        {
            this.Name = name;
            this.RenderOptions = options;
            this.IsAvailable = true;
        }

        public string Name { get; set; }

        public bool IsAvailable { get; set; }

        public ChartRenderOptions RenderOptions { get; set; }
    }
}
