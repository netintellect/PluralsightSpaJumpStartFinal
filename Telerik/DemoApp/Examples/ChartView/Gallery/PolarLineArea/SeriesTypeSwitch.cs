using System.Collections.Generic;
using System.Windows;
using Telerik.Windows.Controls;
using Telerik.Windows.Controls.ChartView;

namespace Telerik.Windows.Examples.ChartView
{
    public class SeriesTypeSwitch : DependencyObject
    {
        public static readonly DependencyProperty SeriesTypeProperty = DependencyProperty.RegisterAttached("SeriesType",
            typeof(string),
            typeof(SeriesTypeSwitch),
            new PropertyMetadata("", OnSeriesTypeChanged));

        public static string GetSeriesType(DependencyObject obj)
        {
            return (string)obj.GetValue(SeriesTypeProperty);
        }

        public static void SetSeriesType(DependencyObject obj, string value)
        {
            obj.SetValue(SeriesTypeProperty, value);
        }

        private static void OnSeriesTypeChanged(DependencyObject sender, DependencyPropertyChangedEventArgs e)
        {
            RadPolarChart chart = sender as RadPolarChart;
            if (chart == null)
                return;

            string newValue = (string)e.NewValue;

            if (newValue == "Area")
                CreatePolarAreaSeries(chart);
            else if (newValue == "Line")
                CreatePolarLineSeries(chart);
        }

        private static void CreatePolarAreaSeries(RadPolarChart chart)
        {
            MicrophoneViewModel viewModel = chart.DataContext as MicrophoneViewModel;

            chart.Series.Clear();
            for (int index = 0; index < 3; index++)
            {
				PolarAreaSeries series = new PolarAreaSeries() { StrokeThickness = 1 };
                series.AngleBinding = new PropertyNameDataPointBinding() { PropertyName = "Angle" };
                series.ValueBinding = new PropertyNameDataPointBinding() { PropertyName = "Value" };
                series.ItemsSource = viewModel.Data[index];
                series.Fill = viewModel.Fills[index];
                series.Stroke = viewModel.Strokes[index];
                if (index != 2)
                {
                    series.LegendSettings = new SeriesLegendSettings() { Title = viewModel.SeriesNames[index] };
                }
                chart.Series.Add(series);
            }
        }

        private static void CreatePolarLineSeries(RadPolarChart chart)
        {
            MicrophoneViewModel viewModel = chart.DataContext as MicrophoneViewModel;

            chart.Series.Clear();
            for (int index = 0; index < 3; index++)
            {
                PolarLineSeries series = new PolarLineSeries();
                series.AngleBinding = new PropertyNameDataPointBinding() { PropertyName = "Angle" };
                series.ValueBinding = new PropertyNameDataPointBinding() { PropertyName = "Value" };
                series.ItemsSource = viewModel.Data[index];
                series.Stroke = viewModel.Strokes[index];
                if (index != 2)
                {
                    series.LegendSettings = new SeriesLegendSettings() { Title = viewModel.SeriesNames[index] };
                }
                chart.Series.Add(series);
            }
        }
    }
}