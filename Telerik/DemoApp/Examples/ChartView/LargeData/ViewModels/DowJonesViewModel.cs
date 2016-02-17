using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Telerik.Windows.Examples.ChartView.LargeData.Models;
using System.Globalization;

namespace Telerik.Windows.Examples.ChartView.LargeData.ViewModels
{
    public class DowJonesViewModel : DataSourceViewModelBase
    {
        private List<DowJonesData> data;
        private double averageLow;
        private double averageOpen;
        private double averageClose;
        private double averageHigh;

        private bool isLowVisible = true;
        private bool isOpenVisible = true;
        private bool isCloseVisible = true;
        private bool isHighVisible = true;

        public List<DowJonesData> Data
        {
            get { return this.data; }
            set
            {
                if (this.data != value)
                {
                    this.data = value;
                    this.OnPropertyChanged(() => this.Data);
                }
            }
        }

        public double AverageLow
        {
            get { return this.averageLow; }
            set
            {
                if (this.averageLow != value)
                {
                    this.averageLow = value;
                    this.OnPropertyChanged(() => this.AverageLow);
                }
            }
        }

        public double AverageOpen
        {
            get { return this.averageOpen; }
            set
            {
                if (this.averageOpen != value)
                {
                    this.averageOpen = value;
                    this.OnPropertyChanged(() => this.AverageOpen);
                }
            }
        }

        public double AverageClose
        {
            get { return this.averageClose; }
            set
            {
                if (this.averageClose != value)
                {
                    this.averageClose = value;
                    this.OnPropertyChanged(() => this.AverageClose);
                }
            }
        }

        public double AverageHigh
        {
            get { return this.averageHigh; }
            set
            {
                if (this.averageHigh != value)
                {
                    this.averageHigh = value;
                    this.OnPropertyChanged(() => this.AverageHigh);
                }
            }
        }

        public bool IsLowVisible
        {
            get { return this.isLowVisible; }
            set
            {
                if (this.isLowVisible != value)
                {
                    this.isLowVisible = value;
                    this.OnPropertyChanged(() => this.IsLowVisible);
                }
            }
        }

        public bool IsOpenVisible
        {
            get { return this.isOpenVisible; }
            set
            {
                if (this.isOpenVisible != value)
                {
                    this.isOpenVisible = value;
                    this.OnPropertyChanged(() => this.IsOpenVisible);
                }
            }
        }

        public bool IsCloseVisible
        {
            get { return this.isCloseVisible; }
            set
            {
                if (this.isCloseVisible != value)
                {
                    this.isCloseVisible = value;
                    this.OnPropertyChanged(() => this.IsCloseVisible);
                }
            }
        }

        public bool IsHighVisible
        {
            get { return this.isHighVisible; }
            set
            {
                if (this.isHighVisible != value)
                {
                    this.isHighVisible = value;
                    this.OnPropertyChanged(() => this.IsHighVisible);
                }
            }
        }

        public DowJonesViewModel()
        {
            this.GetData("DowJonesData.csv");
        }

        private void UpdateAverageValues()
        {
            double totalLow = 0d;
            double totalOpen = 0d;
            double totalClose = 0d;
            double totalHigh = 0d;

            foreach (var djData in this.Data)
            {
                totalLow += djData.Low;
                totalOpen += djData.Open;
                totalClose += djData.Close;
                totalHigh += djData.High;
            }

            int count = this.Data.Count == 0 ? 1 : this.Data.Count;

            this.AverageLow = totalLow / count;
            this.AverageOpen = totalOpen / count;
            this.AverageClose = totalClose / count;
            this.AverageHigh = totalHigh / count;
        }

        protected override void GetDataCompleted(System.Collections.IEnumerable data)
        {
            this.Data = data as List<DowJonesData>;
            this.UpdateAverageValues();
        }

        protected override System.Collections.IEnumerable ParseData(System.IO.TextReader dataReader)
        {            
            string line;
            List<DowJonesData> chartData = new List<DowJonesData>();

            while ((line = dataReader.ReadLine()) != null)
            {
                if (string.IsNullOrEmpty(line))
                    continue;

                string[] data = line.Split(',');

                DowJonesData dataItem = new DowJonesData(); 
                dataItem.Date = DateTime.Parse(data[0], CultureInfo.InvariantCulture);
                dataItem.Open = double.Parse(data[1], CultureInfo.InvariantCulture);
                dataItem.High = double.Parse(data[2], CultureInfo.InvariantCulture);
                dataItem.Low = double.Parse(data[3], CultureInfo.InvariantCulture);
                dataItem.Close = double.Parse(data[4], CultureInfo.InvariantCulture);

                chartData.Add(dataItem);
            }

            return chartData;

        }
    }
}
