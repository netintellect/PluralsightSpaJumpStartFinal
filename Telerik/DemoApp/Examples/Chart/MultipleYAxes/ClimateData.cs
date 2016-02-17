
namespace Telerik.Windows.Examples.Chart.MultipleYAxes
{
    public class ClimateData
    {
        private double _meanTotalRainfall;
        private double _windSpeed;
        private double _averageTemperature;
        private string _month;

        public ClimateData(double meanTotalRainfall, double windSpeed, double averageTemperature, string month)
        {
            this._meanTotalRainfall = meanTotalRainfall;
            this._windSpeed = windSpeed;
            this._averageTemperature = averageTemperature;
            this._month = month;
        }

        public double MeanTotalRainfall
        {
            get
            {
                return this._meanTotalRainfall;
            }
            set
            {
                this._meanTotalRainfall = value;
            }
        }

        public double WindSpeed
        {
            get
            {
                return this._windSpeed;
            }
            set
            {
                this._windSpeed = value;
            }
        }

        public double AverageTemperature
        {
            get
            {
                return this._averageTemperature;
            }
            private set
            {
                this._averageTemperature = value;
            }
        }

        public string Month
        {
            get
            {
                return this._month;
            }
            private set
            {
                this._month = value;
            }
        }
    }
}
