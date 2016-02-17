using System;
using System.Windows;
using System.Windows.Controls;
using Telerik.Examples.Gauge;
using Telerik.Windows.Controls;
using Telerik.Windows.Controls.Gauge;
using Telerik.Windows.Controls.QuickStart.Common.Helpers;

namespace Telerik.Windows.Examples.Gauge.Customization.RadialTickMarks
{
	public partial class Example : DynamicBasePage
	{
		private bool isInitialized = false;
		private double oldTickStep = 10;

		public Example()
		{
            if (ApplicationThemeManager.GetInstance().CurrentTheme == "Windows8Touch")
            {
                this.Resources.MergedDictionaries.Add(new System.Windows.ResourceDictionary() { Source = new Uri("/Gauge;component/Customization/RadialTickMarks/WPF/Win8TouchResources.xaml", UriKind.RelativeOrAbsolute) });
            }
            else
            {
                this.Resources.MergedDictionaries.Add(new System.Windows.ResourceDictionary() { Source = new Uri("/Gauge;component/Customization/RadialTickMarks/WPF/Win8Resources.xaml", UriKind.RelativeOrAbsolute) });
            }
			InitializeComponent();

			DataTemplateItemsSource tickTemplateSource = new DataTemplateItemsSource();
			tickTemplateSource.Add("Default", (DataTemplate)this.Resources["DefaultTickShape"]);
            tickTemplateSource.Add("Triangle", (DataTemplate)this.Resources["TriangleTickShape"]);
			this.majorTickStyle.ItemsSource = tickTemplateSource;

			SetupBinding(this.majorTickStyle, RadComboBox.SelectedItemProperty,
				radialScale, GraphicScale.MajorTickTemplateProperty,
				tickTemplateSource);

			this.isInitialized = true;
			this.SetWayChanged(null, null);
			this.MajorTickSizeChanged(null, null);
			this.MiddleTickSizeChanged(null, null);
			this.MinorTickSizeChanged(null, null);
		}

		private void TickMarks_Loaded(object sender, RoutedEventArgs e)
		{
			this.majorTickStyle.SelectedItem = "Default";
		}

		protected override void NewValue()
		{
			needle.Value = radialScale.Min + (radialScale.Max - radialScale.Min) * rnd.NextDouble();
		}

		private void TurnIndicatorOnOff(object sender, RoutedEventArgs e)
		{
			if (needle.Value == needle.OffPosition)
			{
				ToggleButton.Content = "Turn OFF";
				timer.Start();
			}
			else
			{
				timer.Stop();
				ToggleButton.Content = "Turn ON";
				needle.Value = double.NaN;
			}
		}

		private void SetWayChanged(object sender, RoutedEventArgs e)
		{
			if (isInitialized)
			{
				if (this.ticksCount.IsChecked == true)
				{
					majorTicks.IsEnabled = true;
					majorTickStep.IsEnabled = false;
                    showLastTick.IsEnabled = false;
                    majorTickStepContainer.Visibility = Visibility.Collapsed;
                    majorTicksContainer.Visibility = Visibility.Visible;
					oldTickStep = radialScale.MajorTickStep;
					majorTickStep.Value = null;
				}
				else
				{
					majorTicks.IsEnabled = false;
					majorTickStep.IsEnabled = true;
                    showLastTick.IsEnabled = true;
                    majorTickStepContainer.Visibility = Visibility.Visible;
                    majorTicksContainer.Visibility = Visibility.Collapsed;
					majorTickStep.Value = double.IsNaN(oldTickStep) ? 10 : oldTickStep;
				}
			}
		}

		private void MajorTickSizeChanged(object sender, RadRangeBaseValueChangedEventArgs e)
		{
			if (this.isInitialized)
			{
				this.radialScale.MajorTickRelativeHeight = new GaugeMeasure(this.majorHeight.Value.Value, GridUnitType.Star);
				this.radialScale.MajorTickRelativeWidth = new GaugeMeasure(this.majorWidth.Value.Value, GridUnitType.Star);
			}
		}

		private void MiddleTickSizeChanged(object sender, RadRangeBaseValueChangedEventArgs e)
		{
			if (this.isInitialized)
			{
				this.radialScale.MiddleTickRelativeHeight = new GaugeMeasure(this.middleHeight.Value.Value, GridUnitType.Star);
			}
		}

		private void MinorTickSizeChanged(object sender, RadRangeBaseValueChangedEventArgs e)
		{
			if (this.isInitialized)
			{
				this.radialScale.MinorTickRelativeHeight = new GaugeMeasure(this.minorHeight.Value.Value, GridUnitType.Star);
			}
		}
	}
}
