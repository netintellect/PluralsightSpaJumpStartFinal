using System;
using System.Linq;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using Telerik.Windows.Controls;
using Telerik.Windows.Controls.ChartView;

namespace Telerik.Windows.Examples.ChartView.Financial
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
            ContentPresenter presenter = sender as ContentPresenter;
            if (presenter == null)
                return;

            MainView userControl = presenter.ChildrenOfType<MainView>().FirstOrDefault();
            if (userControl == null)
                return;

            RadCartesianChart chart = userControl.chart;
            if (chart == null)
                return;

            string newValue = (string)e.NewValue;

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
            exampleResources.Source = new Uri("/ChartView;component/Financial/Resources.xaml", UriKind.RelativeOrAbsolute) ;
            series.TrackBallInfoTemplate = exampleResources["trackBallInfoTemplate"] as DataTemplate;
        }


        private static void SetBindings(OhlcSeriesBase series)
        {
            series.CategoryBinding = new PropertyNameDataPointBinding();
            (series.CategoryBinding as PropertyNameDataPointBinding).PropertyName = "Date";
            series.OpenBinding = new PropertyNameDataPointBinding();
            (series.OpenBinding as PropertyNameDataPointBinding).PropertyName = "Open";
            series.HighBinding = new PropertyNameDataPointBinding();
            (series.HighBinding as PropertyNameDataPointBinding).PropertyName = "High";
            series.LowBinding = new PropertyNameDataPointBinding();
            (series.LowBinding as PropertyNameDataPointBinding).PropertyName = "Low";
            series.CloseBinding = new PropertyNameDataPointBinding();
            (series.CloseBinding as PropertyNameDataPointBinding).PropertyName = "Close";
        }

        private static void SetSourceBinding(ChartSeries series)
        {
            Binding sourceBinding = new Binding("Data");
            sourceBinding.Mode = BindingMode.TwoWay;
            series.SetBinding(ChartSeries.ItemsSourceProperty, sourceBinding);
        }
    }
}