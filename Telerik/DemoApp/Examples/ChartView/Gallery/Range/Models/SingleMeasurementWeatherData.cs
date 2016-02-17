using System;

namespace Telerik.Windows.Examples.ChartView.Gallery.Range.Models
{
	public class SingleMeasurementWeatherData
	{
		public DateTime Date { get; set; }
		public double Measurement { get; set; }

		public SingleMeasurementWeatherData(DateTime date, double measurement)
		{
			this.Date = date;
			this.Measurement = measurement;
		}
	}
}
