using System;

namespace Telerik.Windows.Examples.ChartView.Gallery.Range.Models
{
	public class LowHighMeasurementWeatherData
	{
		public DateTime Date { get; set; }
		public double LowMeasurement { get; set; }
		public double HighMeasurement { get; set; }

		public LowHighMeasurementWeatherData(DateTime date,  double lowMeasurement, double highMeasurement)
		{
			this.Date = date;
			this.LowMeasurement = lowMeasurement;
			this.HighMeasurement = highMeasurement;
		}
	}
}
