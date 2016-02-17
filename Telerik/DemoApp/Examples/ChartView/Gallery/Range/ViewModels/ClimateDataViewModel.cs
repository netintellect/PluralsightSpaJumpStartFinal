using System;
using System.Collections.Generic;
using Telerik.Windows.Controls;
using Telerik.Windows.Examples.ChartView.Gallery.Range.Models;

namespace Telerik.Windows.Examples.ChartView.Gallery.Range
{
	public class ClimateDataViewModel : ViewModelBase
	{
		private static IEnumerable<SingleMeasurementWeatherData> GetWindData()
		{
			return new List<SingleMeasurementWeatherData>()
			{
				new SingleMeasurementWeatherData(new DateTime(2011, 1, 1), 10),
				new SingleMeasurementWeatherData(new DateTime(2011, 2, 1), 12),
				new SingleMeasurementWeatherData(new DateTime(2011, 3, 1), 12),
				new SingleMeasurementWeatherData(new DateTime(2011, 4, 1), 12),
				new SingleMeasurementWeatherData(new DateTime(2011, 5, 1), 9),
				new SingleMeasurementWeatherData(new DateTime(2011, 6, 1), 7),
				new SingleMeasurementWeatherData(new DateTime(2011, 7, 1), 7),
				new SingleMeasurementWeatherData(new DateTime(2011, 8, 1), 7),
				new SingleMeasurementWeatherData(new DateTime(2011, 9, 1), 7),
				new SingleMeasurementWeatherData(new DateTime(2011, 10, 1), 9),
				new SingleMeasurementWeatherData(new DateTime(2011, 11, 1), 9),
				new SingleMeasurementWeatherData(new DateTime(2011, 12, 1), 9),
				new SingleMeasurementWeatherData(new DateTime(2012, 1, 1), 13),
				new SingleMeasurementWeatherData(new DateTime(2012, 2, 1), 11),
				new SingleMeasurementWeatherData(new DateTime(2012, 3, 1), 9),
				new SingleMeasurementWeatherData(new DateTime(2012, 4, 1), 9),
				new SingleMeasurementWeatherData(new DateTime(2012, 5, 1), 6),
				new SingleMeasurementWeatherData(new DateTime(2012, 6, 1), 7),
				new SingleMeasurementWeatherData(new DateTime(2012, 7, 1), 7),
				new SingleMeasurementWeatherData(new DateTime(2012, 8, 1), 5),
				new SingleMeasurementWeatherData(new DateTime(2012, 9, 1), 6),
				new SingleMeasurementWeatherData(new DateTime(2012, 10, 1), 8),
			};
		}

		private static IEnumerable<SingleMeasurementWeatherData> GetGustWindData()
		{
			return new List<SingleMeasurementWeatherData>()
			{
				new SingleMeasurementWeatherData(new DateTime(2011, 1, 1), 30),
				new SingleMeasurementWeatherData(new DateTime(2011, 2, 1), 34),
				new SingleMeasurementWeatherData(new DateTime(2011, 3, 1), 31),
				new SingleMeasurementWeatherData(new DateTime(2011, 4, 1), 32),
				new SingleMeasurementWeatherData(new DateTime(2011, 5, 1), 30),
				new SingleMeasurementWeatherData(new DateTime(2011, 6, 1), 29),
				new SingleMeasurementWeatherData(new DateTime(2011, 7, 1), 29),
				new SingleMeasurementWeatherData(new DateTime(2011, 8, 1), 31),
				new SingleMeasurementWeatherData(new DateTime(2011, 9, 1), 30),
				new SingleMeasurementWeatherData(new DateTime(2011, 10, 1), 32),
				new SingleMeasurementWeatherData(new DateTime(2011, 11, 1), 30),
				new SingleMeasurementWeatherData(new DateTime(2011, 12, 1), 32),
				new SingleMeasurementWeatherData(new DateTime(2012, 1, 1), 31),
				new SingleMeasurementWeatherData(new DateTime(2012, 2, 1), 31),
				new SingleMeasurementWeatherData(new DateTime(2012, 3, 1), 31),
				new SingleMeasurementWeatherData(new DateTime(2012, 4, 1), 32),
				new SingleMeasurementWeatherData(new DateTime(2012, 5, 1), 30),
				new SingleMeasurementWeatherData(new DateTime(2012, 6, 1), 31),
				new SingleMeasurementWeatherData(new DateTime(2012, 7, 1), 33),
				new SingleMeasurementWeatherData(new DateTime(2012, 8, 1), 29),
				new SingleMeasurementWeatherData(new DateTime(2012, 9, 1), 33),
				new SingleMeasurementWeatherData(new DateTime(2012, 10, 1), 33),
			};
		}

		private static IEnumerable<LowHighMeasurementWeatherData> GetTemperatureData()
		{
			return new List<LowHighMeasurementWeatherData>()
			{
				new LowHighMeasurementWeatherData(new DateTime(2011, 1, 1), -14, 12),
				new LowHighMeasurementWeatherData(new DateTime(2011, 2, 1), -9, 19),
				new LowHighMeasurementWeatherData(new DateTime(2011, 3, 1), -7, 25),
				new LowHighMeasurementWeatherData(new DateTime(2011, 4, 1), 2, 28),
				new LowHighMeasurementWeatherData(new DateTime(2011, 5, 1), 8, 32),
				new LowHighMeasurementWeatherData(new DateTime(2011, 6, 1), 13, 35),
				new LowHighMeasurementWeatherData(new DateTime(2011, 7, 1), 17, 40),
				new LowHighMeasurementWeatherData(new DateTime(2011, 8, 1), 15, 34),
				new LowHighMeasurementWeatherData(new DateTime(2011, 9, 1), 11, 30),
				new LowHighMeasurementWeatherData(new DateTime(2011, 10, 1), 1, 29),
				new LowHighMeasurementWeatherData(new DateTime(2011, 11, 1), 2, 21),
				new LowHighMeasurementWeatherData(new DateTime(2011, 12, 1), -1, 17),
				new LowHighMeasurementWeatherData(new DateTime(2012, 1, 1), -11, 17),
				new LowHighMeasurementWeatherData(new DateTime(2012, 2, 1), -7, 17),
				new LowHighMeasurementWeatherData(new DateTime(2012, 3, 1), -4, 25),
				new LowHighMeasurementWeatherData(new DateTime(2012, 4, 1), 3, 31),
				new LowHighMeasurementWeatherData(new DateTime(2012, 5, 1), 9, 32),
				new LowHighMeasurementWeatherData(new DateTime(2012, 6, 1), 11, 34),
				new LowHighMeasurementWeatherData(new DateTime(2012, 7, 1), 16, 38),
				new LowHighMeasurementWeatherData(new DateTime(2012, 8, 1), 16, 33),
				new LowHighMeasurementWeatherData(new DateTime(2012, 9, 1), 12, 33),
				new LowHighMeasurementWeatherData(new DateTime(2012, 10, 1), 3, 26),
			};
		}

		private static IEnumerable<LowHighMeasurementWeatherData> GetDewPointData()
		{
			return new List<LowHighMeasurementWeatherData>()
			{
				new LowHighMeasurementWeatherData(new DateTime(2011, 1, 1), -22, 9),
				new LowHighMeasurementWeatherData(new DateTime(2011, 2, 1), -21, 12),
				new LowHighMeasurementWeatherData(new DateTime(2011, 3, 1), -20, 11),
				new LowHighMeasurementWeatherData(new DateTime(2011, 4, 1), -8, 18),
				new LowHighMeasurementWeatherData(new DateTime(2011, 5, 1), -6, 21),
				new LowHighMeasurementWeatherData(new DateTime(2011, 6, 1), 1, 23),
				new LowHighMeasurementWeatherData(new DateTime(2011, 7, 1), 9, 25),
				new LowHighMeasurementWeatherData(new DateTime(2011, 8, 1), 9, 24),
				new LowHighMeasurementWeatherData(new DateTime(2011, 9, 1), 3, 23),
				new LowHighMeasurementWeatherData(new DateTime(2011, 10, 1), -5, 19),
				new LowHighMeasurementWeatherData(new DateTime(2011, 11, 1), -7, 16),
				new LowHighMeasurementWeatherData(new DateTime(2011, 12, 1), -17, 16),
				new LowHighMeasurementWeatherData(new DateTime(2012, 1, 1), -21, 14),
				new LowHighMeasurementWeatherData(new DateTime(2012, 2, 1), -19, 6),
				new LowHighMeasurementWeatherData(new DateTime(2012, 3, 1), -19, 15),
				new LowHighMeasurementWeatherData(new DateTime(2012, 4, 1), -11, 14),
				new LowHighMeasurementWeatherData(new DateTime(2012, 5, 1), -3, 23),
				new LowHighMeasurementWeatherData(new DateTime(2012, 6, 1), 7, 22),
				new LowHighMeasurementWeatherData(new DateTime(2012, 7, 1), 8, 24),
				new LowHighMeasurementWeatherData(new DateTime(2012, 8, 1), 6, 25),
				new LowHighMeasurementWeatherData(new DateTime(2012, 9, 1), 2, 24),
				new LowHighMeasurementWeatherData(new DateTime(2012, 10, 1), -7, 20),
			};
		}

		private static IEnumerable<SingleMeasurementWeatherData> GetPrecipitationData()
		{
			return new List<SingleMeasurementWeatherData>()
			{
				new SingleMeasurementWeatherData(new DateTime(2011, 1, 1), 4.7),
				new SingleMeasurementWeatherData(new DateTime(2011, 2, 1), 3.3),
				new SingleMeasurementWeatherData(new DateTime(2011, 3, 1), 5.4),
				new SingleMeasurementWeatherData(new DateTime(2011, 4, 1), 5),
				new SingleMeasurementWeatherData(new DateTime(2011, 5, 1), 4.3),
				new SingleMeasurementWeatherData(new DateTime(2011, 6, 1), 2.9),
				new SingleMeasurementWeatherData(new DateTime(2011, 7, 1), 2.6),
				new SingleMeasurementWeatherData(new DateTime(2011, 8, 1), 16),
				new SingleMeasurementWeatherData(new DateTime(2011, 9, 1), 8.5),
				new SingleMeasurementWeatherData(new DateTime(2011, 10, 1), 5.5),
				new SingleMeasurementWeatherData(new DateTime(2011, 11, 1), 2.7),
				new SingleMeasurementWeatherData(new DateTime(2011, 12, 1), 3.4),
				new SingleMeasurementWeatherData(new DateTime(2012, 1, 1), 2.8),
				new SingleMeasurementWeatherData(new DateTime(2012, 2, 1), 1.3),
				new SingleMeasurementWeatherData(new DateTime(2012, 3, 1), 0.8),
				new SingleMeasurementWeatherData(new DateTime(2012, 4, 1), 3.6),
				new SingleMeasurementWeatherData(new DateTime(2012, 5, 1), 4.7),
				new SingleMeasurementWeatherData(new DateTime(2012, 6, 1), 2.8),
				new SingleMeasurementWeatherData(new DateTime(2012, 7, 1), 3.6),
				new SingleMeasurementWeatherData(new DateTime(2012, 8, 1), 2.6),
				new SingleMeasurementWeatherData(new DateTime(2012, 9, 1), 4.3),
				new SingleMeasurementWeatherData(new DateTime(2012, 10, 1), 2.6),
			};
		}

		public IEnumerable<SingleMeasurementWeatherData> GustWindSpeedData { get; set; }
		public IEnumerable<SingleMeasurementWeatherData> WindSpeedData { get; set; }
		public IEnumerable<LowHighMeasurementWeatherData> TempRangesData { get; set; }
		public IEnumerable<SingleMeasurementWeatherData> PrecipitationData { get; set; }
		public IEnumerable<LowHighMeasurementWeatherData> DewPointsData { get; set; }

		private string seriesType = "RangeBar";
		public string SeriesType
		{
			get
			{
				return this.seriesType;
			}

			set
			{
				this.seriesType = value;
				base.OnPropertyChanged("SeriesType");
			}
		}

		private DateTime year2012Start = new DateTime(2012, 1, 1);
		public DateTime Year2012Start
		{
			get
			{
				return this.year2012Start;
			}
		}

		private DateTime year2011Start = new DateTime(2011, 1, 1);
		public DateTime Year2011Start
		{
			get
			{
				return this.year2011Start;
			}
		}

		public ClimateDataViewModel()
		{
			this.WindSpeedData = GetWindData();
			this.GustWindSpeedData = GetGustWindData();
			this.TempRangesData = GetTemperatureData();
			this.PrecipitationData = GetPrecipitationData();
			this.DewPointsData = GetDewPointData();
		}
	}
}
