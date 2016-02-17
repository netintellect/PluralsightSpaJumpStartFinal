using System;
using System.Windows;
using System.Windows.Data;
using System.Windows.Media;
using Telerik.Windows.Controls;
using Telerik.Windows.Controls.ChartView;

namespace Telerik.Windows.Examples.ChartView.Gallery.CandlestickOhlc
{
    public class FinancialIndicatorSwitch : DependencyObject
    {
        static ResourceDictionary exampleResources;

        public static readonly DependencyProperty MainIndicatorProperty = DependencyProperty.RegisterAttached("MainIndicator",
                                                                                                           typeof(string),
                                                                                                           typeof(FinancialIndicatorSwitch),
                                                                                                           new PropertyMetadata(null, OnIndicatorChanged));

        public static readonly DependencyProperty SecondaryIndicatorProperty = DependencyProperty.RegisterAttached("SecondaryIndicator",
                                                                                                           typeof(string),
                                                                                                           typeof(FinancialIndicatorSwitch),
                                                                                                           new PropertyMetadata(null, OnIndicatorChanged));

        static FinancialIndicatorSwitch()
        {
            exampleResources = new ResourceDictionary();
            exampleResources.Source = new Uri("/ChartView;component/Gallery/CandlestickOhlc/Resources.xaml", UriKind.RelativeOrAbsolute);
        }

        public static string GetMainIndicator(DependencyObject obj)
        {
            return (string)obj.GetValue(MainIndicatorProperty);
        }

        public static void SetMainIndicator(DependencyObject obj, string value)
        {
            obj.SetValue(MainIndicatorProperty, value);
        }

        public static string GetSecondaryIndicator(DependencyObject obj)
        {
            return (string)obj.GetValue(SecondaryIndicatorProperty);
        }

        public static void SetSecondaryIndicator(DependencyObject obj, string value)
        {
            obj.SetValue(SecondaryIndicatorProperty, value);
        }

        private static void OnIndicatorChanged(DependencyObject sender, DependencyPropertyChangedEventArgs e)
        {
            if (e.NewValue == null)
                return;

            RadCartesianChart chart = sender as RadCartesianChart;
            if (chart == null)
                return;

            chart.Indicators.Clear();

            if (e.NewValue.ToString().StartsWith("MA ("))
                chart.Indicators.Add(CreateMovingAverageIndicator());
            else if (e.NewValue.ToString().StartsWith("Exponential MA"))
                chart.Indicators.Add(CreateExponentialMovingAverageIndicator());
            else if (e.NewValue.ToString().StartsWith("Modified MA"))
                chart.Indicators.Add(CreateModifiedMovingAverageIndicator());
            else if (e.NewValue.ToString().StartsWith("Modified Exponential MA"))
                chart.Indicators.Add(CreateModifiedExponentialMovingAverageIndicator());
            else if (e.NewValue.ToString().StartsWith("Weighted MA"))
                chart.Indicators.Add(CreateWeightedMovingAverageIndicator());
            else if (e.NewValue.ToString().StartsWith("Adaptive MA"))
                chart.Indicators.Add(CreateAdaptiveMovingAverageKaufmanIndicator());
            else if (e.NewValue.ToString().StartsWith("Bollinger Bands"))
                chart.Indicators.Add(CreateBollingerBandsIndicator());
            else if (e.NewValue.ToString().StartsWith("Average True Range"))
                CreateAverageTrueRangeIndicator(chart);
            else if (e.NewValue.ToString().StartsWith("Commodity Channel Index"))
                CreateCommodityChannelIndexIndicator(chart);
            else if (e.NewValue.ToString().StartsWith("MACD "))
                CreateMacdIndicator(chart);
            else if (e.NewValue.ToString().StartsWith("MACDH"))
                CreateMacdhIndicator(chart);
            else if (e.NewValue.ToString().StartsWith("Momentum"))
                CreateMomentumIndicator(chart);
            else if (e.NewValue.ToString().StartsWith("Oscillator"))
                CreateOscillatorIndicator(chart);
            else if (e.NewValue.ToString().StartsWith("RAVI"))
                CreateRaviIndicator(chart);
            else if (e.NewValue.ToString().StartsWith("Rate Of Change"))
                CreateRateOfChangeIndicator(chart);
            else if (e.NewValue.ToString().StartsWith("Relative Momentum Index"))
                CreateRelativeMomentumIndexIndicator(chart);
            else if (e.NewValue.ToString().StartsWith("Relative Strength Index"))
                CreateRelativeStrengthIndexIndicator(chart);
            else if (e.NewValue.ToString().StartsWith("Stochastic Fast"))
                CreateStochasticFastIndicator(chart);
            else if (e.NewValue.ToString().StartsWith("Stochastic Slow"))
                CreateStochasticSlowIndicator(chart);
            else if (e.NewValue.ToString().StartsWith("True Range"))
                CreateTrueRangeIndicator(chart);
            else if (e.NewValue.ToString().StartsWith("TRIX"))
                CreateTrixIndicator(chart);
            else if (e.NewValue.ToString().StartsWith("Ultimate"))
                CreateUltimateOscillatorIndicator(chart);
        }

        static MovingAverageIndicator CreateMovingAverageIndicator()
        {
            MovingAverageIndicator indicator = new MovingAverageIndicator();
            indicator.Period = 5;
            indicator.CategoryBinding = CreateBinding("Date");
            indicator.ValueBinding = CreateBinding("Close");
            SetSourceBinding(indicator);
            indicator.Stroke = exampleResources["indicatorStroke"] as Brush;
            indicator.StrokeThickness = (double)exampleResources["indicatorStrokeThickness"];
            indicator.TrackBallInfoTemplate = exampleResources["maTrackballInfoTemplate"] as DataTemplate;
            return indicator;
        }

        static ExponentialMovingAverageIndicator CreateExponentialMovingAverageIndicator()
        {
            ExponentialMovingAverageIndicator indicator = new ExponentialMovingAverageIndicator();
            indicator.Period = 5;
            indicator.CategoryBinding = CreateBinding("Date");
            indicator.ValueBinding = CreateBinding("Close");
            SetSourceBinding(indicator);
            indicator.Stroke = exampleResources["indicatorStroke"] as Brush;
            indicator.StrokeThickness = (double)exampleResources["indicatorStrokeThickness"];
            indicator.TrackBallInfoTemplate = exampleResources["emaTrackballInfoTemplate"] as DataTemplate;
            return indicator;
        }

        static ModifiedMovingAverageIndicator CreateModifiedMovingAverageIndicator()
        {
            ModifiedMovingAverageIndicator indicator = new ModifiedMovingAverageIndicator();
            indicator.Period = 5;
            indicator.CategoryBinding = CreateBinding("Date");
            indicator.ValueBinding = CreateBinding("Close");
            SetSourceBinding(indicator);
            indicator.Stroke = exampleResources["indicatorStroke"] as Brush;
            indicator.StrokeThickness = (double)exampleResources["indicatorStrokeThickness"];
            indicator.TrackBallInfoTemplate = exampleResources["mmaTrackballInfoTemplate"] as DataTemplate;
            return indicator;
        }

        static ModifiedExponentialMovingAverageIndicator CreateModifiedExponentialMovingAverageIndicator()
        {
            ModifiedExponentialMovingAverageIndicator indicator = new ModifiedExponentialMovingAverageIndicator();
            indicator.Period = 5;
            indicator.CategoryBinding = CreateBinding("Date");
            indicator.ValueBinding = CreateBinding("Close");
            SetSourceBinding(indicator);
            indicator.Stroke = exampleResources["indicatorStroke"] as Brush;
            indicator.StrokeThickness = (double)exampleResources["indicatorStrokeThickness"];
            indicator.TrackBallInfoTemplate = exampleResources["memaTrackballInfoTemplate"] as DataTemplate;
            return indicator;
        }

        static WeightedMovingAverageIndicator CreateWeightedMovingAverageIndicator()
        {
            WeightedMovingAverageIndicator indicator = new WeightedMovingAverageIndicator();
            indicator.Period = 5;
            indicator.CategoryBinding = CreateBinding("Date");
            indicator.ValueBinding = CreateBinding("Close");
            SetSourceBinding(indicator);
            indicator.Stroke = exampleResources["indicatorStroke"] as Brush;
            indicator.StrokeThickness = (double)exampleResources["indicatorStrokeThickness"];
            indicator.TrackBallInfoTemplate = exampleResources["wmaTrackballInfoTemplate"] as DataTemplate;
            return indicator;
        }

        static AdaptiveMovingAverageKaufmanIndicator CreateAdaptiveMovingAverageKaufmanIndicator()
        {
            AdaptiveMovingAverageKaufmanIndicator indicator = new AdaptiveMovingAverageKaufmanIndicator();
            indicator.Period = 5;
            indicator.SlowPeriod = 10;
            indicator.FastPeriod = 4;
            indicator.CategoryBinding = CreateBinding("Date");
            indicator.ValueBinding = CreateBinding("Close");
            SetSourceBinding(indicator);
            indicator.Stroke = exampleResources["indicatorStroke"] as Brush;
            indicator.StrokeThickness = (double)exampleResources["indicatorStrokeThickness"];
            indicator.TrackBallInfoTemplate = exampleResources["kamaTrackballInfoTemplate"] as DataTemplate;
            return indicator;
        }

        private static BollingerBandsIndicator CreateBollingerBandsIndicator()
        {
            BollingerBandsIndicator indicator = new BollingerBandsIndicator();
            indicator.Period = 5;
            indicator.StandardDeviations = 2;
            indicator.CategoryBinding = CreateBinding("Date");
            indicator.ValueBinding = CreateBinding("Close");
            SetSourceBinding(indicator);
            indicator.Stroke = exampleResources["indicatorStroke"] as Brush;
            indicator.LowerBandStroke = exampleResources["secondaryChartIndicatorStroke"] as Brush;
            indicator.StrokeThickness = (double)exampleResources["indicatorStrokeThickness"];
            indicator.TrackBallInfoTemplate = exampleResources["bollTrackballInfoTemplate"] as DataTemplate;
            return indicator;
        }

        static void CreateAverageTrueRangeIndicator(RadCartesianChart chart)
        {
            AverageTrueRangeIndicator indicator = new AverageTrueRangeIndicator();
            indicator.Period = 5;
            indicator.CategoryBinding = CreateBinding("Date");
            indicator.HighBinding = CreateBinding("High");
            indicator.LowBinding = CreateBinding("Low");
            indicator.CloseBinding = CreateBinding("Close");
            SetSourceBinding(indicator);
            indicator.Stroke = exampleResources["secondaryChartIndicatorStroke"] as Brush;
            indicator.StrokeThickness = (double)exampleResources["indicatorStrokeThickness"];
            chart.Indicators.Add(indicator);

            ConfigureAxis(chart, 0, 5, 1);
        }

        static void CreateCommodityChannelIndexIndicator(RadCartesianChart chart)
        {
            CommodityChannelIndexIndicator indicator = new CommodityChannelIndexIndicator();
            indicator.Period = 5;
            indicator.CategoryBinding = CreateBinding("Date");
            indicator.HighBinding = CreateBinding("High");
            indicator.LowBinding = CreateBinding("Low");
            indicator.CloseBinding = CreateBinding("Close");
            SetSourceBinding(indicator);
            indicator.Stroke = exampleResources["secondaryChartIndicatorStroke"] as Brush;
            indicator.StrokeThickness = (double)exampleResources["indicatorStrokeThickness"];
            chart.Indicators.Add(indicator);

            ConfigureAxis(chart, -200, 200, 100);
        }

        static void CreateMacdIndicator(RadCartesianChart chart)
        {
            MacdIndicator indicator = new MacdIndicator();
            indicator.ShortPeriod = 9;
            indicator.LongPeriod = 12;
            indicator.SignalPeriod = 6;
            indicator.CategoryBinding = CreateBinding("Date");
            indicator.ValueBinding = CreateBinding("Close");
            SetSourceBinding(indicator);
            indicator.Stroke = exampleResources["secondaryChartIndicatorStroke"] as Brush;
            indicator.SignalStroke = new SolidColorBrush(Colors.Red);
            indicator.StrokeThickness = (double)exampleResources["indicatorStrokeThickness"];
            chart.Indicators.Add(indicator);

            ConfigureAxis(chart, -2, 2, 1);
        }

        static void CreateMacdhIndicator(RadCartesianChart chart)
        {
            MacdhIndicator indicator = new MacdhIndicator();
            indicator.ShortPeriod = 9;
            indicator.LongPeriod = 12;
            indicator.SignalPeriod = 6;
            indicator.CategoryBinding = CreateBinding("Date");
            indicator.ValueBinding = CreateBinding("Close");
            SetSourceBinding(indicator);
            chart.Indicators.Add(indicator);

            ConfigureAxis(chart, -2, 2, 1);
        }

        static void CreateMomentumIndicator(RadCartesianChart chart)
        {
            MomentumIndicator indicator = new MomentumIndicator();
            indicator.Period = 8;
            indicator.CategoryBinding = CreateBinding("Date");
            indicator.ValueBinding = CreateBinding("Close");
            SetSourceBinding(indicator);
            indicator.Stroke = exampleResources["secondaryChartIndicatorStroke"] as Brush;
            indicator.StrokeThickness = (double)exampleResources["indicatorStrokeThickness"];
            chart.Indicators.Add(indicator);

            ConfigureAxis(chart, 80, 120, 10);
        }

        static void CreateOscillatorIndicator(RadCartesianChart chart)
        {
            OscillatorIndicator indicator = new OscillatorIndicator();
            indicator.ShortPeriod = 4;
            indicator.LongPeriod = 8;
            indicator.CategoryBinding = CreateBinding("Date");
            indicator.ValueBinding = CreateBinding("Close");
            SetSourceBinding(indicator);
            indicator.Stroke = exampleResources["secondaryChartIndicatorStroke"] as Brush;
            indicator.StrokeThickness = (double)exampleResources["indicatorStrokeThickness"];
            chart.Indicators.Add(indicator);

            ConfigureAxis(chart, -5, 5, 5);
        }

        static void CreateRaviIndicator(RadCartesianChart chart)
        {
            RaviIndicator indicator = new RaviIndicator();
            indicator.ShortPeriod = 4;
            indicator.LongPeriod = 8;
            indicator.CategoryBinding = CreateBinding("Date");
            indicator.ValueBinding = CreateBinding("Close");
            SetSourceBinding(indicator);
            indicator.Stroke = exampleResources["secondaryChartIndicatorStroke"] as Brush;
            indicator.StrokeThickness = (double)exampleResources["indicatorStrokeThickness"];
            chart.Indicators.Add(indicator);

            ConfigureAxis(chart, -5, 5, 5);
        }

        static void CreateRateOfChangeIndicator(RadCartesianChart chart)
        {
            RateOfChangeIndicator indicator = new RateOfChangeIndicator();
            indicator.Period = 8;
            indicator.CategoryBinding = CreateBinding("Date");
            indicator.ValueBinding = CreateBinding("Close");
            SetSourceBinding(indicator);
            indicator.Stroke = exampleResources["secondaryChartIndicatorStroke"] as Brush;
            indicator.StrokeThickness = (double)exampleResources["indicatorStrokeThickness"];
            chart.Indicators.Add(indicator);

            ConfigureAxis(chart, -20, 20, 10);
        }

        static void CreateRelativeMomentumIndexIndicator(RadCartesianChart chart)
        {
            RelativeMomentumIndexIndicator indicator = new RelativeMomentumIndexIndicator();
            indicator.Period = 8;
            indicator.CategoryBinding = CreateBinding("Date");
            indicator.ValueBinding = CreateBinding("Close");
            SetSourceBinding(indicator);
            indicator.Stroke = exampleResources["secondaryChartIndicatorStroke"] as Brush;
            indicator.StrokeThickness = (double)exampleResources["indicatorStrokeThickness"];
            chart.Indicators.Add(indicator);

            ConfigureAxis(chart, 0, 100, 20);
        }

        static void CreateRelativeStrengthIndexIndicator(RadCartesianChart chart)
        {
            RelativeStrengthIndexIndicator indicator = new RelativeStrengthIndexIndicator();
            indicator.Period = 8;
            indicator.CategoryBinding = CreateBinding("Date");
            indicator.ValueBinding = CreateBinding("Close");
            SetSourceBinding(indicator);
            indicator.Stroke = exampleResources["secondaryChartIndicatorStroke"] as Brush;
            indicator.StrokeThickness = (double)exampleResources["indicatorStrokeThickness"];
            chart.Indicators.Add(indicator);

            ConfigureAxis(chart, 0, 100, 20);
        }

        static void CreateStochasticFastIndicator(RadCartesianChart chart)
        {
            StochasticFastIndicator indicator = new StochasticFastIndicator();
            indicator.MainPeriod = 14;
            indicator.SignalPeriod = 3;
            indicator.CategoryBinding = CreateBinding("Date");
            indicator.HighBinding = CreateBinding("High");
            indicator.LowBinding = CreateBinding("Low");
            indicator.CloseBinding = CreateBinding("Close");
            SetSourceBinding(indicator);
            indicator.Stroke = exampleResources["secondaryChartIndicatorStroke"] as Brush;
            indicator.SignalStroke = new SolidColorBrush(Colors.Red);
            indicator.StrokeThickness = (double)exampleResources["indicatorStrokeThickness"];
            chart.Indicators.Add(indicator);

            ConfigureAxis(chart, 0, 100, 20);
        }

        static void CreateStochasticSlowIndicator(RadCartesianChart chart)
        {
            StochasticSlowIndicator indicator = new StochasticSlowIndicator();
            indicator.MainPeriod = 14;
            indicator.SignalPeriod = 3;
            indicator.SlowingPeriod = 3;
            indicator.CategoryBinding = CreateBinding("Date");
            indicator.HighBinding = CreateBinding("High");
            indicator.LowBinding = CreateBinding("Low");
            indicator.CloseBinding = CreateBinding("Close");
            SetSourceBinding(indicator);
            indicator.Stroke = exampleResources["secondaryChartIndicatorStroke"] as Brush;
            indicator.SignalStroke = new SolidColorBrush(Colors.Red);
            indicator.StrokeThickness = (double)exampleResources["indicatorStrokeThickness"];
            chart.Indicators.Add(indicator);

            ConfigureAxis(chart, 0, 100, 20);
        }

        static void CreateTrixIndicator(RadCartesianChart chart)
        {
            TrixIndicator indicator = new TrixIndicator();
            indicator.Period = 8;
            indicator.CategoryBinding = CreateBinding("Date");
            indicator.ValueBinding = CreateBinding("Close");
            SetSourceBinding(indicator);
            indicator.Stroke = exampleResources["secondaryChartIndicatorStroke"] as Brush;
            indicator.StrokeThickness = (double)exampleResources["indicatorStrokeThickness"];
            chart.Indicators.Add(indicator);

            ConfigureAxis(chart, -1, 1, 0.5);
        }

        static void CreateTrueRangeIndicator(RadCartesianChart chart)
        {
            TrueRangeIndicator indicator = new TrueRangeIndicator();
            indicator.CategoryBinding = CreateBinding("Date");
            indicator.HighBinding = CreateBinding("High");
            indicator.LowBinding = CreateBinding("Low");
            indicator.CloseBinding = CreateBinding("Close");
            SetSourceBinding(indicator);
            indicator.Stroke = exampleResources["secondaryChartIndicatorStroke"] as Brush;
            indicator.StrokeThickness = (double)exampleResources["indicatorStrokeThickness"];
            chart.Indicators.Add(indicator);

            ConfigureAxis(chart, 0, 6, 1);
        }

        static void CreateUltimateOscillatorIndicator(RadCartesianChart chart)
        {
            UltimateOscillatorIndicator indicator = new UltimateOscillatorIndicator();
            indicator.Period = 6;
            indicator.Period2 = 9;
            indicator.Period3 = 12;
            indicator.CategoryBinding = CreateBinding("Date");
            indicator.CloseBinding = CreateBinding("Close");
            indicator.HighBinding = CreateBinding("High");
            indicator.LowBinding = CreateBinding("Low");
            SetSourceBinding(indicator);
            indicator.Stroke = exampleResources["secondaryChartIndicatorStroke"] as Brush;
            indicator.StrokeThickness = (double)exampleResources["indicatorStrokeThickness"];
            chart.Indicators.Add(indicator);

            ConfigureAxis(chart, 0, 100, 20);
        }

        private static PropertyNameDataPointBinding CreateBinding(string propertyName)
        {
            PropertyNameDataPointBinding binding = new PropertyNameDataPointBinding();
            binding.PropertyName = propertyName;
            return binding;
        }

        private static void SetSourceBinding(IndicatorBase indicator)
        {
            Binding sourceBinding = new Binding("Data");
            indicator.SetBinding(ChartSeries.ItemsSourceProperty, sourceBinding);
        }

        private static void ConfigureAxis(RadCartesianChart chart, double min, double max, double majorStep)
        {
            LinearAxis axis = chart.VerticalAxis as LinearAxis;
            if (axis == null)
                return;

            ClearAxisValues(axis);
            axis.Minimum = min;
            axis.Maximum = max;
            axis.MajorStep = majorStep;
        }

        private static void ClearAxisValues(LinearAxis axis)
        {
            axis.ClearValue(LinearAxis.MinimumProperty);
            axis.ClearValue(LinearAxis.MaximumProperty);
            axis.ClearValue(LinearAxis.MajorStepProperty);
        }
    }
}