using System.Collections;
using System.Collections.Generic;
using System.IO;

namespace Telerik.Windows.Examples.ChartView.Gallery.CandlestickOhlc
{
    public class CandlestickViewModel : DataSourceViewModelBase
    {
        List<CandleDataInfo> _data;
        public List<CandleDataInfo> Data
        {
            get
            {
                return _data;
            }
            set
            {
                if (this._data != value)
                {
                    this._data = value;
                    this.OnPropertyChanged("Data");
                }
            }
        }

        private string _SeriesType = "OHLC";
        public string SeriesType
        {
            get
            {
                return this._SeriesType;
            }
            set
            {
                if (this._SeriesType != value)
                {
                    this._SeriesType = value;
                    this.OnPropertyChanged("SeriesType");
                }
            }
        }

        private string _MainIndicator = "MA (5)";
        public string MainIndicator
        {
            get
            {
                return this._MainIndicator;
            }
            set
            {
                if (this._MainIndicator != value)
                {
                    this._MainIndicator = value;
                    this.OnPropertyChanged("MainIndicator");
                }
            }
        }

        private string _SecondaryIndicator = "Average True Range (5)";
        public string SecondaryIndicator
        {
            get
            {
                return this._SecondaryIndicator;
            }
            set
            {
                if (this._SecondaryIndicator != value)
                {
                    this._SecondaryIndicator = value;
                    this.OnPropertyChanged("SecondaryIndicator");
                }
            }
        }

        public string DataFileName
        {
            get
            {
                return "CandleData.csv";
            }
        }

        protected override string SilverlightPath
        {
            get
            {
                return "DataSources/Candle/{0}";
            }
        }

        protected override string WpfPath
        {
            get
            {
                return "/ChartView;component/DataSources/CandlestickOhlc/{0}";
            }
        }

        public CandlestickViewModel()
        {
            this.GetData(this.DataFileName);
        }

        protected override void GetDataCompleted(IEnumerable data)
        {
            this.Data = data as List<CandleDataInfo>;
        }

        protected override IEnumerable ParseData(TextReader dataReader)
        {
            return CandleDataInfo.ParseData(dataReader);
        }
    }
}
