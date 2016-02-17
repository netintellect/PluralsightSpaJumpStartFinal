using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Media;
using Telerik.Windows.Controls;
using Telerik.Windows.Controls.ChartView;

namespace Telerik.Windows.Examples.ChartView
{
	public class MicrophoneViewModel : ViewModelBase
	{
		private int count = 720;
		private string _seriesType = "Line";

		public string SeriesType
		{
			get
			{
				return this._seriesType;
			}
			set
			{
				if (this._seriesType != value)
				{
					this._seriesType = value;
					this.OnPropertyChanged("SeriesType");
				}
			}
		}

		public IList<IEnumerable<UserDataPoint>> Data { get; set; }

		public IList<Brush> Fills { get; set; }

		public IList<Brush> Strokes { get; set; }

		public Dictionary<int, string> SeriesNames { get; set; }

		public MicrophoneViewModel()
		{
			PaletteEntryCollection paletteEntries = ChartPalettes.Windows8.SeriesEntries.First(entry => entry.SeriesFamily == "PolarArea");
			List<Brush> fills = new List<Brush>();
			fills.Add(paletteEntries[0].Fill);
			fills.Add(paletteEntries[1].Fill);
			fills.Add(paletteEntries[1].Fill);
			this.Fills = fills;

			List<Brush> strokes = new List<Brush>();
			strokes.Add(ChartPalettes.Windows8.GlobalEntries[0].Fill);
			strokes.Add(ChartPalettes.Windows8.GlobalEntries[1].Fill);
			strokes.Add(ChartPalettes.Windows8.GlobalEntries[1].Fill);
			this.Strokes = strokes;

			this.SeriesNames = new Dictionary<int, string>()
			{
				{ 0, "Cardioid Microphone" },
				{ 1, "Shotgun Microphone" },
				{ 2, "Shotgun Microphone" },
			};

			this.InitializeData();
		}

		private void InitializeData()
		{
			this.Data = this.CreateData();
		}

		private IList<IEnumerable<UserDataPoint>> CreateData()
		{
			List<UserDataPoint> cardioidDataList = new List<UserDataPoint>();
			List<UserDataPoint> shotgunFrontDataList = new List<UserDataPoint>();
			List<UserDataPoint> shotgunSideDataList = new List<UserDataPoint>();

			double angleStep = 2 * Math.PI / count;

			for (int i = 0; i < count; i++)
			{
				double factor = (i > (0.25 * count) && i < (0.75 * count)) ? 0.7 : 1;
				double angle = i * angleStep;

				UserDataPoint cardioidDataPoint = new UserDataPoint();
				cardioidDataPoint.Angle = angle * (180 / Math.PI);
				cardioidDataPoint.Value = 0.5 + (0.5 * Math.Cos(angle));
				cardioidDataList.Add(cardioidDataPoint);

				UserDataPoint shotgunFrontDataPoint = new UserDataPoint();
				shotgunFrontDataPoint.Angle = angle * (180 / Math.PI);
				shotgunFrontDataPoint.Value = factor * Math.Pow(Math.Abs(Math.Cos(angle)), 8);
				shotgunFrontDataList.Add(shotgunFrontDataPoint);

				UserDataPoint shotgunSideDataPoint = new UserDataPoint();
				shotgunSideDataPoint.Angle = angle * (180 / Math.PI);
				shotgunSideDataPoint.Value = 0.48 * Math.Pow(Math.Abs(Math.Sin(angle)), 20);
				shotgunSideDataList.Add(shotgunSideDataPoint);
			}

			List<IEnumerable<UserDataPoint>> result = new List<IEnumerable<UserDataPoint>>();
			result.Add(cardioidDataList);
			result.Add(shotgunFrontDataList);
			result.Add(shotgunSideDataList);
			return result;
		}
	}
}