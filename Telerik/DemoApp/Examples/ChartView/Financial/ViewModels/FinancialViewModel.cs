using System.Collections;
using System.Collections.Generic;
using System.IO;

namespace Telerik.Windows.Examples.ChartView.Financial
{
    public abstract class FinancialViewModel : DataSourceViewModelBase
    {
        List<FinancialInfo> _data;
        public List<FinancialInfo> Data
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

        public abstract string DataFileName { get; }

        protected override string SilverlightPath
        {
            get
            {
                return "DataSources/Financial/{0}";
            }
        }

        protected override string WpfPath
        {
            get
            {
                return "/ChartView;component/DataSources/Financial/{0}";
            }
        }

        public FinancialViewModel()
        {
            this.GetData(this.DataFileName);
        }

        protected override void GetDataCompleted(IEnumerable data)
        {
            this.Data = data as List<FinancialInfo>;
        }

        protected override IEnumerable ParseData(TextReader dataReader)
        {
            return FinancialInfo.ParseData(dataReader);
        }
    }
}
