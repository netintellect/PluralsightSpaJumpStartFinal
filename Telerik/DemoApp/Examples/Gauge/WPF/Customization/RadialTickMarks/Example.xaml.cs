using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using Telerik.Windows.Examples.Gauge;
using Telerik.Windows.Controls;
using Telerik.Windows.Controls.Gauges;
using Telerik.Examples.Gauge;

namespace Telerik.Windows.Examples.Gauge.Customization.RadialTickMarks
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
                radialScale.MajorTick, TickProperties.ItemTemplateProperty,
                itemsSource);
			SetupBinding(middleTickStyle, RadComboBox.SelectedItemProperty,
                radialScale.MiddleTick, TickProperties.ItemTemplateProperty,
                itemsSource);
			SetupBinding(minorTickStyle, RadComboBox.SelectedItemProperty,
                radialScale.MinorTick, TickProperties.ItemTemplateProperty,
                itemsSource);

            majorTicks.Value = 10;
            majorLength.Value = 0.08;
            showLastTick.IsChecked = true;

            middleTicks.Value = 2;
            middleLength.Value = 0.06;

            minorTicks.Value = 2;
            minorLength.Value = 0.04;

            tickValue.Value = 43;

			radialScale.MajorTickStep = double.NaN;

			init = true;

            this.Loaded += new RoutedEventHandler(TickMarks_Loaded);
        }

        private void TickMarks_Loaded(object sender, RoutedEventArgs e)
        {
            majorTickStyle.SelectedItem = "Triangle";
            middleTickStyle.SelectedItem = "Default";
            minorTickStyle.SelectedItem = "Default";
        }


        protected override void NewValue()
        {
            radialBar.Value = radialScale.Min + (radialScale.Max - radialScale.Min) * rnd.NextDouble();
            needle.Value = radialScale.Min + (radialScale.Max - radialScale.Min) * rnd.NextDouble();
        }

        private void TurnIndicatorOnOff(object sender, RoutedEventArgs e)
        {
            if (double.IsNaN(needle.Value))
            {
                ToggleButton.Content = "Turn OFF";
                timer.Start();
            }
            else
            {
                timer.Stop();
                ToggleButton.Content = "Turn ON";
                needle.Value = double.NaN;
                radialBar.Value = double.NaN;
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
                    oldTickStep = radialScale.MajorTickStep;
                    radialScale.MajorTickStep = double.NaN;
                }
                else
                {
                    majorTicks.IsEnabled = false;
                    majorTickStep.IsEnabled = true;
                    showLastTick.IsEnabled = true;
                    SetupBinding(majorTickStep, RadNumericUpDown.ValueProperty, radialScale, ScaleBase.MajorTickStepProperty,
                        null);
                    majorTickStep.Value = oldTickStep;
                }
            }
        }
    }
}
