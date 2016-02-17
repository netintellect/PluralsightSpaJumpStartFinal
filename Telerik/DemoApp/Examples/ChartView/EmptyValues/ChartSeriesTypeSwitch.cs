using System.Windows;
using System.Windows.Data;
using System.Windows.Media;
using Telerik.Windows.Controls;
using Telerik.Windows.Controls.ChartView;

namespace Telerik.Windows.Examples.ChartView.EmptyValues
{
    public static class ChartSeriesTypeSwitch
    {
        public static readonly DependencyProperty SeriesTypeProperty = DependencyProperty.RegisterAttached("SeriesType",
            typeof(string), typeof(ChartSeriesTypeSwitch), new PropertyMetadata(OnSeriesTypeChanged));

        private static SolidColorBrush brush = new SolidColorBrush(Color.FromArgb(0xFF, 0x1B, 0x9D, 0xDE));

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
            RadCartesianChart chart = sender as RadCartesianChart;
            if (chart == null)
                return;

            string seriesType = e.NewValue as string;
            chart.Series.Clear();
            var series = GetSeries(chart, seriesType);
            chart.Series.Add(series);
        }

        private static CartesianSeries GetSeries(RadCartesianChart chart, string seriesType)
        {
            CategoricalSeries series = null;
            switch (seriesType)
            {
                case "Bar":
                    series = new BarSeries()
                    {
                        Background = brush,
                        DefaultVisualStyle = chart.Resources["BorderStyle"] as Style
                    };
                    break;
                case "Line":
                    series = new LineSeries()
                    {
                        Stroke = brush,
                        StrokeThickness = 3,
                        PointTemplate = chart.Resources["PointTemplate"] as DataTemplate
                    };
                    break;
                case "Spline":
                    series = new SplineSeries()
                    {
                        Stroke = brush,
                        StrokeThickness = 3,
                        PointTemplate = chart.Resources["PointTemplate"] as DataTemplate
                    };
                    break;
                case "Area":
                    series = new AreaSeries()
                    {
                        Fill = brush,
                        PointTemplate = chart.Resources["PointTemplate"] as DataTemplate
                    };
                    break;
                case "SplineArea":
                    series = new SplineAreaSeries()
                    {
                        Fill = brush,
                        PointTemplate = chart.Resources["PointTemplate"] as DataTemplate
                    };
                    break;
            }
            series.CategoryBinding = new PropertyNameDataPointBinding("Season");
            series.ValueBinding = new PropertyNameDataPointBinding("Points");
            series.SetBinding(CategoricalSeries.ItemsSourceProperty, new Binding("SelectedTeam.Stats"));
            series.SetBinding(CategoricalSeries.ShowLabelsProperty, new Binding("ShowLabels"));
            series.ClipToPlotArea = false;

            return series;
        }
    }
}
