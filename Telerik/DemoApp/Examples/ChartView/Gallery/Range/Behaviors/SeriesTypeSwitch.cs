using System.Collections;
using System.Windows;
using Telerik.Windows.Controls;
using Telerik.Windows.Controls.ChartView;

namespace Telerik.Windows.Examples.ChartView.Gallery.Range.Behaviors
{
	public static class SeriesTypeSwitch
	{
		private static void OnSeriesTypeChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
		{
			SetSeries(d as RadCartesianChart);
		}

		private static void OnItemsSourceChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
		{
			SetSeries(d as RadCartesianChart);
		}

		private static void SetSeries(RadCartesianChart chart)
		{
			IEnumerable itemsSource = GetItemsSource(chart);
			string seriesType = GetSeriesType(chart);

			chart.Series.Clear();
			CartesianSeries series = null;
			switch (seriesType)
			{
				case "RangeBar":
					{
						series = new RangeBarSeries()
						{
							CategoryBinding = new PropertyNameDataPointBinding("Date"),
							LowBinding = new PropertyNameDataPointBinding("LowMeasurement"),
							HighBinding = new PropertyNameDataPointBinding("HighMeasurement")
						};
						break;
					}

				case "Range":
					{
						series = new Telerik.Windows.Controls.ChartView.RangeSeries()
						{
							CategoryBinding = new PropertyNameDataPointBinding("Date"),
							LowBinding = new PropertyNameDataPointBinding("LowMeasurement"),
							HighBinding = new PropertyNameDataPointBinding("HighMeasurement")
						};
						break;
					}

                case "RangeSpline":
                    {
                        series = new RangeSplineSeries()
                        {
                            CategoryBinding = new PropertyNameDataPointBinding("Date"),
                            LowBinding = new PropertyNameDataPointBinding("LowMeasurement"),
                            HighBinding = new PropertyNameDataPointBinding("HighMeasurement")
                        };
                        break;
                    }

				case "Bar":
					{
						series = new BarSeries()
						{
							CategoryBinding = new PropertyNameDataPointBinding("Date"),
							ValueBinding = new PropertyNameDataPointBinding("Measurement"),
						};
						break;
					}

				case "Area":
					{
						series = new AreaSeries()
						{
							CategoryBinding = new PropertyNameDataPointBinding("Date"),
							ValueBinding = new PropertyNameDataPointBinding("Measurement"),
						};
						break;
					}

                case "SplineArea":
                    {
                        series = new SplineAreaSeries()
                        {
                            CategoryBinding = new PropertyNameDataPointBinding("Date"),
                            ValueBinding = new PropertyNameDataPointBinding("Measurement"),
                        };
                        break;
                    }
			}

			if (series != null)
			{
				series.ItemsSource = itemsSource;
				chart.Series.Add(series);
			}
		}

		public static readonly DependencyProperty SeriesTypeProperty =
			DependencyProperty.RegisterAttached("SeriesType",
												typeof(string),
												typeof(SeriesTypeSwitch),
												new PropertyMetadata(OnSeriesTypeChanged));

		public static readonly DependencyProperty ItemsSourceProperty =
			DependencyProperty.RegisterAttached("ItemsSource",
												typeof(IEnumerable),
												typeof(SeriesTypeSwitch),
												new PropertyMetadata(OnItemsSourceChanged));

		public static string GetSeriesType(DependencyObject obj)
		{
			return (string)obj.GetValue(SeriesTypeProperty);
		}

		public static void SetSeriesType(DependencyObject obj, string value)
		{
			obj.SetValue(SeriesTypeProperty, value);
		}

		public static IEnumerable GetItemsSource(DependencyObject obj)
		{
			return (IEnumerable)obj.GetValue(ItemsSourceProperty);
		}

		public static void SetItemsSource(DependencyObject obj, IEnumerable value)
		{
			obj.SetValue(ItemsSourceProperty, value);
		}
	}
}
