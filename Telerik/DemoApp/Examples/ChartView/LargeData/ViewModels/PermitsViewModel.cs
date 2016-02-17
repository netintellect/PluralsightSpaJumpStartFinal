using System;
using System.Collections;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using Telerik.Windows.Controls;
using Telerik.Windows.Controls.Rating;
using Telerik.Windows.Examples.ChartView.LargeData.Models;

namespace Telerik.Windows.Examples.ChartView.LargeData.ViewModels
{
    public class PermitsViewModel : ViewModelBase
    {
        private Dictionary<int, List<PermitData>> data;
        private double averageCost;
        private double averageFee;
        private double maxCost;
        private double maxFee;
        private double x;
        private double y;
                
        public Dictionary<int, List<PermitData>> Data
        {
            get
            {
                return this.data;
            }
            set
            {
                if (this.data != value)
                {
                    this.data = value;
                    this.OnPropertyChanged(() => this.Data);
                }
            }
        }

        public double AverageCost
        {
            get { return this.averageCost; }
            set
            {
                if (this.averageCost != value)
                {
                    this.averageCost = value;
                    this.OnPropertyChanged(() => this.AverageCost);
                }
            }
        }

        public double AverageFee
        {
            get { return this.averageFee; }
            set
            {
                if (this.averageFee != value)
                {
                    this.averageFee = value;
                    this.OnPropertyChanged(() => this.AverageFee);
                }
            }
        }

        public double MaxFee
        {
            get { return this.maxFee; }
            set
            {
                if (this.maxFee != value)
                {
                    this.maxFee = value;
                    this.OnPropertyChanged(() => this.MaxFee);
                }
            }
        }

        public double X
        {
            get { return this.x; }
            set
            {
                if (this.x != value)
                {
                    this.x = value;
                    this.OnPropertyChanged(() => this.X);
                }
            }
        }

        public double Y
        {
            get { return this.y; }
            set
            {
                if (this.y != value)
                {
                    this.y = value;
                    this.OnPropertyChanged(() => this.Y);
                }
            }
        }

        public double MaxCost
        {
            get { return this.maxCost; }
            set
            {
                if (this.maxCost != value)
                {
                    this.maxCost = value;
                    this.OnPropertyChanged(() => this.MaxCost);
                }
            }
        }

        public int Count { get; set; }


        public PermitsViewModel()
        {
            this.GenerateData();
        }

        private void GenerateData()
        {
            Random r = new Random();
            this.Data = new Dictionary<int, List<PermitData>>();
            for (int i = 2007; i < 2013; i++)
            {
                List<PermitData> dataList = new List<PermitData>();
                for (int j = 150; j < 10150; j++)
                {
                    PermitData dataItem = new PermitData() { EstimatedCost = j * 100 + r.Next(-j*20, j*50)};

                    double fakeValue = Math.Pow(Math.Max(300000, dataItem.EstimatedCost), 1.25);
                    if (fakeValue <= 30000)
                        dataItem.PermitFee = r.Next(400, 5000) + fakeValue / r.Next(4000, 18000);
                    else if (j % 2 == 0)
                        dataItem.PermitFee = r.Next(400, 5000) + fakeValue / r.Next(7500, 13000);
                    else if (j % 3 == 0)
                        dataItem.PermitFee = r.Next(400, 5000) + fakeValue / r.Next(7000, 18000);
                    else if (j % 5 == 0)
                        dataItem.PermitFee = r.Next(400, 5000) + fakeValue / r.Next(6500, 22000);
                    else
                        dataItem.PermitFee = r.Next(400, 5000) + fakeValue / r.Next(8000, 12000);
                    dataList.Add(dataItem);
                }
                
                this.Data.Add(i, dataList);
            }
            this.UpdateAggregateValues();
        }

        private void UpdateAggregateValues()
        {
            double totalCost = 0d;
            double totalFee = 0d;
            double maxCost = 0d;
            double maxFee = 0d;

            foreach (var keyValuePair in this.Data)
            {
                foreach (var item in keyValuePair.Value)
                {
                    totalCost += item.EstimatedCost;
                    totalFee += item.PermitFee;
                    this.Count++;

                    maxCost = Math.Max(maxCost, item.EstimatedCost);
                    maxFee = Math.Max(maxFee, item.PermitFee);
                }
            }

            if (this.Count == 0)
                this.Count = 1;

            this.MaxCost = maxCost;
            this.maxFee = maxFee;
            this.AverageCost = totalCost / this.Count;
            this.AverageFee = totalFee / this.Count;
        }
    }
}
