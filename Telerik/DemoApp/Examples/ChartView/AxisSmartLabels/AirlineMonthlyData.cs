using System;

namespace Telerik.Windows.Examples.ChartView.AxisSmartLabels
{
    public class AirlineMonthlyData
    {
        private DateTime date;
        private int passengersCount;
        private double consumptionInMlnGallons;
        private double costPerGallon;

        public AirlineMonthlyData(DateTime date, int passengersCount, double consumptionInMlnGallons, double costPerGallon)
        {
            this.date = date;
            this.passengersCount = passengersCount;
            this.consumptionInMlnGallons = consumptionInMlnGallons;
            this.costPerGallon = costPerGallon;
        }

        public DateTime Date { get { return this.date; } }
        public int PassengersCount { get { return this.passengersCount; } }
        public double ConsumptionInMlnGallons { get { return this.consumptionInMlnGallons; } }
        public double CostPerGallon { get { return this.costPerGallon; } }
    }
}
