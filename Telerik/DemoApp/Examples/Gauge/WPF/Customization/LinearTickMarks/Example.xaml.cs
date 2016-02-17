using System;
using System.Windows;
using Telerik.Windows.Controls.Gauges;
using System.Windows.Controls;
using Telerik.Windows.Controls;
using Telerik.Examples.Gauge;

namespace Telerik.Windows.Examples.Gauge.Customization.LinearTickMarks
{
    /// <summary>
    /// Interaction logic for Example.xaml
    /// </summary>
    public partial class Example : DynamicBasePage
    {
        private bool init = false;
        private double oldTickStep = 10;

        public Example()
        {
            InitializeComponent();

            DataTemplateItemsSource itemsSource = new DataTemplateItemsSource();
            itemsSource.Add("Default", (DataTemplate)Resources["DefaultTickShape"]);
            itemsSource.Add("Ellipse", (DataTemplate)Resources["EllipseTickShape"]);
            itemsSource.Add("Triangle", (DataTemplate)Resources["TriangleTickShape"]);

            majorTickStyle.ItemsSource = itemsSource;
            middleTickStyle.ItemsSource = itemsSource;
            minorTickStyle.ItemsSource = itemsSource;

            SetupBinding(majorTickStyle, RadComboBox.SelectedItemProperty,
                linearScale.MajorTick, TickProperties.ItemTemplateProperty,
                itemsSource);
			SetupBinding(middleTickStyle, RadComboBox.SelectedItemProperty,
                linearScale.MiddleTick, TickProperties.ItemTemplateProperty,
                itemsSource);
			SetupBinding(minorTickStyle, RadComboBox.SelectedItemProperty,
                linearScale.MinorTick, TickProperties.ItemTemplateProperty,
                itemsSource);

            majorTicks.Value = 4;
            majorLength.Value = 0.08;
            showLastTick.IsChecked = true;

            middleTicks.Value = 2;
            middleLength.Value = 0.06;

            minorTicks.Value = 2;
            minorLength.Value = 0.02;

            tickValue.Value = 43;

			linearScale.MajorTickStep = double.NaN;

            init = true;

            this.Loaded += new RoutedEventHandler(TickMarks_Loaded);
        }

        private void TickMarks_Loaded(object sender, RoutedEventArgs e)
        {
            majorTickStyle.SelectedItem = "Ellipse";
            middleTickStyle.SelectedItem = "Triangle";
            minorTickStyle.SelectedItem = "Default";
        }

        protected override void NewValue()
        {
            marker.Value = linearScale.Min + (linearScale.Max - linearScale.Min) * rnd.NextDouble();
        }

        private void TurnIndicatorOnOff(object sender, RoutedEventArgs e)
        {
            if (double.IsNaN(marker.Value))
            {
                ToggleOffModeButton.Content = "Turn OFF";
                timer.Start();
            }
            else
            {
                timer.Stop();
                ToggleOffModeButton.Content = "Turn ON";
                marker.Value = double.NaN;
            }
        }

        private void SetWayChanged(object sender, RoutedEventArgs e)
        {
            if (init)
            {
                if (this.ticksCount.IsChecked == true)
                {
                    majorTicks.IsEnabled = true;
                    majorTickStep.IsEnabled = false;
                    showLastTick.IsEnabled = false;
                    oldTickStep = linearScale.MajorTickStep;
                    linearScale.MajorTickStep = double.NaN;
                }
                else
                {
                    majorTicks.IsEnabled = false;
                    majorTickStep.IsEnabled = true;
                    showLastTick.IsEnabled = true;
                    SetupBinding(majorTickStep, RadNumericUpDown.ValueProperty, linearScale, ScaleBase.MajorTickStepProperty,
                        null);
                    majorTickStep.Value = oldTickStep;
                }
            }
        }
    }
}
