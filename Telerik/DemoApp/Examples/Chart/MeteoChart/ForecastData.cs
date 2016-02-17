using System;

namespace Telerik.Windows.Examples.Chart.MeteoChart
{
	public class ForecastData
	{
		private DateTime _time;
		private double _temperature;
		private double _rainfall;
		private WeatherConditions _weatherConditions;

		public DateTime Time
		{
			get
			{
				return _time;
			}
			set
			{
				_time = value;
			}
		}

		public double Temperature
		{
			get
			{
				return _temperature;
			}
			set
			{
				_temperature = value;
			}
		}

		public double Rainfall
		{
			get
			{
				return _rainfall;
			}
			set
			{
				_rainfall = value;
			}
		}

		public WeatherConditions WeatherConditions
		{
			get
			{
				return _weatherConditions;
			}
			set
			{
				_weatherConditions = value;
			}
		}

		public string WeatherImageSource
		{
			get
			{
                return string.Format("../Images/Chart/MeteoChart/{0}.png", this.WeatherConditions);
			}
		}
	}
}
