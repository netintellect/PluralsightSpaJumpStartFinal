using System;
using System.Windows;
using System.Windows.Data;
using Telerik.Windows.Controls;
using Telerik.Windows.Controls.ChartView;

namespace Telerik.Windows.Examples.ChartView.Gallery.CandlestickOhlc
{
    public class FinancialSeriesTypeSwitch : DependencyObject
    {
        public static readonly DependencyProperty SeriesTypeProperty = DependencyProperty.RegisterAttached("SeriesType",
                                                                                                           typeof(string),
                                                                                                           typeof(FinancialSeriesTypeSwitch),
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

            if (newValue == "Candlestick")
                CreateCandleStickSeries(chart);
            else if (newValue == "OHLC")
                CreateOhlcSeries(chart);
        }


        private static void CreateOhlcSeries(RadCartesianChart chart)
        {
            chart.Series.Clear();
            OhlcSeries series = new OhlcSeries();
            SetBindings(series);
            SetSourceBinding(series);
            SetTrackBallInfoTemplate(series);
            chart.Series.Add(series);
        }

        private static void CreateCandleStickSeries(RadCartesianChart chart)
        {
            chart.Series.Clear();
            CandlestickSeries series = new CandlestickSeries();
            SetBindings(series);
            SetSourceBinding(series);
            SetTrackBallInfoTemplate(series);
            chart.Series.Add(series);
        }

        private static void SetTrackBallInfoTemplate(OhlcSeriesBase series)
        {
            ResourceDictionary exampleResources = new ResourceDictionary();
            exampleResources.Source = new Uri("/ChartView;component/Gallery/CandlestickOhlc/Resources.xaml", UriKind.RelativeOrAbsolute);
            series.TrackBallInfoTemplate = exampleResources["trackBallInfoTemplate"] as DataTemplate;
        }


        private static void SetBindings(OhlcSeriesBase series)
        {
            series.CategoryBinding = CreateBinding("Date");
            series.OpenBinding = CreateBinding("Open");
            series.HighBinding = CreateBinding("High");
            series.LowBinding = CreateBinding("Low");
            series.CloseBinding = CreateBinding("Close");
        }

        private static PropertyNameDataPointBinding CreateBinding(string propertyName)
        {
            PropertyNameDataPointBinding binding = new PropertyNameDataPointBinding();
            binding.PropertyName = propertyName;
            return binding;
        }

        private static void SetSourceBinding(ChartSeries series)
        {
            Binding sourceBinding = new Binding("Data");
            //sourceBinding.Mode = BindingMode.TwoWay;
            series.SetBinding(ChartSeries.ItemsSourceProperty, sourceBinding);
        }
    }
}