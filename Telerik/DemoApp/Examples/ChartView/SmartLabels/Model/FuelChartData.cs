using System;

namespace Telerik.Windows.Examples.ChartView.SmartLabels
{
    public class FuelChartData
    {
        private DateTime date;
        private double consumption;
        private double cost;

        public FuelChartData(DateTime date, double cost)
        {
            this.date = date;
            this.cost = cost;
        }

        public FuelChartData(DateTime date, double cost, double consumption)
            :this(date, cost)
        {
            this.consumption = consumption;
        }

        public DateTime Date
        {
            get
            {
                return this.date;
            }
        }

        public double Consumption
        {
            get
            {
                return this.consumption;
            }
        }

        public double Cost
        {
            get
            {
                return this.cost;
            }
        }
    }
}
