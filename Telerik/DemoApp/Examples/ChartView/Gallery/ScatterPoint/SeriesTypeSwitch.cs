﻿using System.Windows;
using System.Windows.Data;
using Telerik.Windows.Controls;
using Telerik.Windows.Controls.ChartView;
using System.Windows.Media;

namespace Telerik.Windows.Examples.ChartView.Gallery.ScatterPoint
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
            if (e.NewValue == null)
                return;

            RadCartesianChart chart = sender as RadCartesianChart;
            if (chart == null)
                return;

            string newValue = (string)e.NewValue;

            chart.Series.Clear();

            if (newValue == "Scatter point")
                CreateScatterPointSeries(chart);
            else if (newValue == "Scatter line")
                CreateScatterLineSeries(chart);
            else if (newValue == "Scatter spline")
                CreateScatterSplineSeries(chart);
            else if (newValue == "Scatter area")
                CreateScatterAreaSeries(chart);
            else if (newValue == "Scatter spline area")
                CreateScatterSplineAreaSeries(chart);
        }

        private static void CreateScatterAreaSeries(RadCartesianChart chart)
        {
            chart.Series.Clear();

            ScatterAreaSeries seriesPrivateData = new ScatterAreaSeries()
            {
                Fill = new SolidColorBrush(Color.FromArgb(0xBF, 0x1B, 0x9D, 0xDE)),
                Stroke = new SolidColorBrush(Color.FromArgb(0xFF, 0x1B, 0x9D, 0xDE)),
                StrokeThickness = 2,
                LegendSettings = new SeriesLegendSettings { Title = "Private Sector" },
            };
            ScatterAreaSeries seriesPublicData = new ScatterAreaSeries()
            {
                Fill = new SolidColorBrush(Color.FromArgb(0xBF, 0x8E, 0xC4, 0x41)),
                Stroke = new SolidColorBrush(Color.FromArgb(0xFF, 0x8E, 0xC4, 0x41)),
                StrokeThickness = 2,
                LegendSettings = new SeriesLegendSettings { Title = "Public Sector" },
            };

            SetBindings(seriesPrivateData);
            SetBindings(seriesPublicData);

            SetSourceBindingPrivateData(seriesPrivateData);
            SetSourceBindingPublicData(seriesPublicData);

            chart.Series.Add(seriesPublicData);
            chart.Series.Add(seriesPrivateData);

            (chart.HorizontalAxis as LinearAxis).Minimum = 16;
            (chart.HorizontalAxis as LinearAxis).Maximum = 64;
            (chart.HorizontalAxis as LinearAxis).MajorStep = 4;
        }

        private static void CreateScatterSplineAreaSeries(RadCartesianChart chart)
        {
            chart.Series.Clear();

            var privateDataColor = new SolidColorBrush(Color.FromArgb(0xBF, 0x1B, 0x9D, 0xDE));

            ScatterSplineAreaSeries seriesPrivateData = new ScatterSplineAreaSeries()
            {
                Fill = privateDataColor,
                Stroke = new SolidColorBrush(Color.FromArgb(0xFF, 0x1B, 0x9D, 0xDE)),
                StrokeThickness = 2,
                LegendSettings = new SeriesLegendSettings { Title = "Private Sector" },
            };
            ScatterSplineAreaSeries seriesPublicData = new ScatterSplineAreaSeries()
            {
                Fill = new SolidColorBrush(Color.FromArgb(0xBF, 0x8E, 0xC4, 0x41)),
                Stroke = new SolidColorBrush(Color.FromArgb(0xFF, 0x8E, 0xC4, 0x41)),
                StrokeThickness = 2,
                LegendSettings = new SeriesLegendSettings { Title = "Public Sector" },
            };

            SetBindings(seriesPrivateData);
            SetBindings(seriesPublicData);

            SetSourceBindingPrivateData(seriesPrivateData);
            SetSourceBindingPublicData(seriesPublicData);

            chart.Series.Add(seriesPublicData);
            chart.Series.Add(seriesPrivateData);

            (chart.HorizontalAxis as LinearAxis).Minimum = 16;
            (chart.HorizontalAxis as LinearAxis).Maximum = 64;
            (chart.HorizontalAxis as LinearAxis).MajorStep = 4;
        }

        private static void CreateScatterLineSeries(RadCartesianChart chart)
        {
            chart.Series.Clear();

            ScatterLineSeries seriesPrivateData = new ScatterLineSeries() 
            { 
                IsHitTestVisible = true,
                Stroke = new SolidColorBrush(Color.FromArgb(0xFF, 0x1B, 0x9D, 0xDE)),
                LegendSettings = new SeriesLegendSettings { Title = "Private Sector" },
            };
            ScatterLineSeries seriesPublicData = new ScatterLineSeries() 
            {
                IsHitTestVisible = true,
                LegendSettings = new SeriesLegendSettings { Title = "Public Sector" },
            };

            SetBindings(seriesPrivateData);
            SetBindings(seriesPublicData);

            SetSourceBindingPrivateData(seriesPrivateData);
            SetSourceBindingPublicData(seriesPublicData);

            seriesPrivateData.PointTemplate = chart.Resources["scatterLinePointTemplate2"] as DataTemplate;
            seriesPublicData.PointTemplate = chart.Resources["scatterLinePointTemplate1"] as DataTemplate;

            chart.Series.Add(seriesPublicData);
            chart.Series.Add(seriesPrivateData);

            (chart.HorizontalAxis as LinearAxis).Minimum = 10;
            (chart.HorizontalAxis as LinearAxis).Maximum = 70;
            (chart.HorizontalAxis as LinearAxis).MajorStep = 5;
        }

        private static void CreateScatterSplineSeries(RadCartesianChart chart)
        {
            chart.Series.Clear();

            ScatterSplineSeries seriesPrivateData = new ScatterSplineSeries() 
            { 
                IsHitTestVisible = true,
                Stroke = new SolidColorBrush(Color.FromArgb(0xFF, 0x1B, 0x9D, 0xDE)),
                LegendSettings = new SeriesLegendSettings { Title = "Private Sector" },
            };
            ScatterSplineSeries seriesPublicData = new ScatterSplineSeries() 
            {
                IsHitTestVisible = true,
                LegendSettings = new SeriesLegendSettings { Title = "Public Sector" },
            };

            SetBindings(seriesPrivateData);
            SetBindings(seriesPublicData);

            SetSourceBindingPrivateData(seriesPrivateData);
            SetSourceBindingPublicData(seriesPublicData);

            seriesPrivateData.PointTemplate = chart.Resources["scatterLinePointTemplate2"] as DataTemplate;
            seriesPublicData.PointTemplate = chart.Resources["scatterLinePointTemplate1"] as DataTemplate;

            chart.Series.Add(seriesPublicData);
            chart.Series.Add(seriesPrivateData);

            (chart.HorizontalAxis as LinearAxis).Minimum = 10;
            (chart.HorizontalAxis as LinearAxis).Maximum = 70;
            (chart.HorizontalAxis as LinearAxis).MajorStep = 5;
        }

        private static void CreateScatterPointSeries(RadCartesianChart chart)
        {
            chart.Series.Clear();

            ScatterPointSeries seriesPrivateData = new ScatterPointSeries() 
            {
                LegendSettings = new SeriesLegendSettings { Title = "Private Sector", MarkerGeometry = new RectangleGeometry { Rect = new Rect(1, 1, 10, 10) } }, 
            };
            ScatterPointSeries seriesPublicData = new ScatterPointSeries() 
            {
                LegendSettings = new SeriesLegendSettings { Title = "Public Sector" },
            };

            SetBindings(seriesPrivateData);
            SetBindings(seriesPublicData);

            SetSourceBindingPrivateData(seriesPrivateData);
            SetSourceBindingPublicData(seriesPublicData);

            seriesPrivateData.PointTemplate = chart.Resources["PointTemplate2"] as DataTemplate;
            seriesPublicData.PointTemplate = chart.Resources["PointTemplate1"] as DataTemplate;

            chart.Series.Add(seriesPublicData);
            chart.Series.Add(seriesPrivateData);

            (chart.HorizontalAxis as LinearAxis).Minimum = 10;
            (chart.HorizontalAxis as LinearAxis).Maximum = 70;
            (chart.HorizontalAxis as LinearAxis).MajorStep = 5;
        }

        private static void SetBindings(ScatterPointSeries series)
        {
            series.XValueBinding = CreateBinding("Age");
            series.YValueBinding = CreateBinding("Wage");
        }

        private static PropertyNameDataPointBinding CreateBinding(string propertyName)
        {
            PropertyNameDataPointBinding binding = new PropertyNameDataPointBinding();
            binding.PropertyName = propertyName;
            return binding;
        }

        private static void SetSourceBindingPrivateData(ChartSeries series)
        {
            Binding sourceBinding = new Binding("PrivateData");
            series.SetBinding(ChartSeries.ItemsSourceProperty, sourceBinding);
        }

        private static void SetSourceBindingPublicData(ChartSeries series)
        {
            Binding sourceBinding = new Binding("PublicData");
            series.SetBinding(ChartSeries.ItemsSourceProperty, sourceBinding);
        }
    }
}