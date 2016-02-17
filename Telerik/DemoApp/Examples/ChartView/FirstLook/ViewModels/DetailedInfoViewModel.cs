using System;
using System.Net;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Documents;
using System.Windows.Ink;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Animation;
using System.Windows.Shapes;
using System.Collections.Generic;
using System.IO;
using System.Collections;
using System.Globalization;

namespace Telerik.Windows.Examples.ChartView.FirstLook
{
    public class DetailedInfoViewModel : DataSourceViewModelBase
    {
        List<DetailedInfo> _datailedInfoList;

        public List<DetailedInfo> DetailedInfoList
        {
            get
            {
                return _datailedInfoList;
            }
            set
            {
                if (this._datailedInfoList != value)
                {
                    this._datailedInfoList = value;
                    this.OnPropertyChanged("DetailedInfoList");
                }
            }
        }

        public DetailedInfoViewModel()
        {
            this.GetData("SalesDashboardDetailedInfo.csv");
        }

        protected override void GetDataCompleted(System.Collections.IEnumerable data)
        {
            this.DetailedInfoList = data as List<DetailedInfo>;
        }

        protected override IEnumerable ParseData(TextReader dataReader)
        {
            string line;

            List<DetailedInfo> chartData = new List<DetailedInfo>();

            while ((line = dataReader.ReadLine()) != null)
            {
                if (string.IsNullOrEmpty(line))
                    continue;

                string[] data = line.Split(',');

                DetailedInfo dataItem = new DetailedInfo();
                dataItem.Country = data[0];
                dataItem.StoreName = data[1];
                for (int i = 2; i < 14; i++)
                {
                    dataItem.MonthlyData.Add(double.Parse(data[i], CultureInfo.InvariantCulture));
                }
                dataItem.Actual = double.Parse(data[14], CultureInfo.InvariantCulture);
                dataItem.Target = double.Parse(data[15], CultureInfo.InvariantCulture);
                
                
                chartData.Add(dataItem);
            }

            return chartData;
        }
    }

    public class DetailedInfo
    {
        private string _country;
        public string Country { 
            get
            {
                return this._country;
            }
            set
            {
                this._country = value;
            }
        }

        private string _storeName;
        public string StoreName
        {
            get
            {
                return this._storeName;
            }
            set
            {
                this._storeName = value;
            }
        }

        private List<double> _monthlyData;
        public List<double> MonthlyData
        {
            get
            {
                return this._monthlyData;
            }
            set
            {
                this._monthlyData = value;
            }
        }

        private double _actual;
        public double Actual
        {
            get
            {
                return this._actual;
            }
            set
            {
                this._actual = value;
            }
        }

        private double _target;
        public double Target
        {
            get
            {
                return this._target;
            }
            set
            {
                this._target = value;
            }
        }

        public DetailedInfo()
        {
            this.MonthlyData = new List<double>();
        }
    }
}
