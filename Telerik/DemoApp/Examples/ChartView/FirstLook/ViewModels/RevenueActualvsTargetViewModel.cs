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
    public class RevenueActualvsTargetViewModel : DataSourceViewModelBase
    {
        List<MonthRevenue> _monthRevenues;

        public List<MonthRevenue> MonthRevenues
        {
            get
            {
                return _monthRevenues;
            }
            set
            {
                if (this._monthRevenues != value)
                {
                    this._monthRevenues = value;
                    this.OnPropertyChanged("MonthRevenues");
                }
            }
        }

        public RevenueActualvsTargetViewModel()
        {
            this.GetData("RevenueActualvsTarget.csv");
        }

        protected override void GetDataCompleted(System.Collections.IEnumerable data)
        {
            this.MonthRevenues = data as List<MonthRevenue>;
        }

        protected override IEnumerable ParseData(TextReader dataReader)
        {
            string line;

            List<MonthRevenue> chartData = new List<MonthRevenue>();

            while ((line = dataReader.ReadLine()) != null)
            {
                if (string.IsNullOrEmpty(line))
                    continue;

                string[] data = line.Split(',');

                MonthRevenue dataItem = new MonthRevenue();
                dataItem.Actual = double.Parse(data[0], CultureInfo.InvariantCulture);
                dataItem.Target = double.Parse(data[1], CultureInfo.InvariantCulture);
                dataItem.Month = DateTime.Parse(data[2], CultureInfo.InvariantCulture).ToString("MMM");
                
                chartData.Add(dataItem);
            }

            return chartData;
        }
    }

    public class MonthRevenue
    {
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
       
        private string _month;
        public string Month
        {
            get
            {
                return this._month;
            }
            set
            {
                this._month = value;
            }
        }
    }
}
