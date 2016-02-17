using System;
using System.Collections.Generic;
using Telerik.Windows.Controls;

namespace Telerik.Windows.Examples.Chart.MeteoChart
{
    public class ExampleViewModel : ViewModelBase
    {
        private double _axisXMinValue;
        private double _axisXMaxValue;
        private double _axisXStep;
        private List<ForecastData> _data;

        public ExampleViewModel()
        {
            DateTime startTime = DateTime.Now.AddMinutes(-DateTime.Now.Minute);
            this.AxisXMinValue = startTime.ToOADate();
            this.AxisXMaxValue = startTime.AddHours(11).ToOADate();
            this.AxisXStep = 1 / 24d;

            this.Data = GetForecastData(startTime);
        }

        public List<ForecastData> Data
        {
            get
            {
                return this._data;
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

        public double AxisXMinValue
        {
            get
            {
                return this._axisXMinValue;
            }
            set
            {
                if (this._axisXMinValue != value)
                {
                    this._axisXMinValue = value;
                    this.OnPropertyChanged("AxisXMinValue");
                }
            }
        }

        public double AxisXMaxValue
        {
            get
            {
                return this._axisXMaxValue;
            }
            set
            {
                if (this._axisXMaxValue != value)
                {
                    this._axisXMaxValue = value;
                    this.OnPropertyChanged("AxisXMaxValue");
                }
            }
        }

        public double AxisXStep
        {
            get
            {
                return this._axisXStep;
            }
            set
            {
                if (this._axisXStep != value)
                {
                    this._axisXStep = value;
                    this.OnPropertyChanged("AxisXStep");
                }
            }
        }

        private List<ForecastData> GetForecastData(DateTime startTime)
        {
            Random rand = new Random(DateTime.Now.Millisecond);
            List<ForecastData> data = new List<ForecastData>();

            for (int i = 0; i < 12; i++)
            {
                ForecastData forecastData = new ForecastData();
                forecastData.Time = startTime.AddHours(i);
                forecastData.Temperature = rand.Next(-15, 35);

                if (forecastData.Temperature < 0)
                    forecastData.WeatherConditions = (WeatherConditions)rand.Next(1, 3);
                else
                    forecastData.WeatherConditions = (WeatherConditions)rand.Next(1, 4);

                if (forecastData.WeatherConditions == WeatherConditions.Rainy)
                    forecastData.Rainfall = Math.Round(rand.NextDouble() + 0.1, 1);

                data.Add(forecastData);
            }

            return data;
        }
    }
}
