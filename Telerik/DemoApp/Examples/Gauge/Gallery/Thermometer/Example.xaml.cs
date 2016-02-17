using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Animation;
using System.Windows.Shapes;
using Telerik.Examples.Gauge;
using Telerik.Windows.Controls.Gauge;
using Telerik.Windows.Controls.QuickStart.Common.Helpers;

namespace Telerik.Windows.Examples.Gauge.Gallery.Thermometer
{
	public partial class Example : DynamicBasePage
	{
		/// <summary>
		/// Randomizer
		/// </summary>
		private RealDataEmulator valueGenerator = new RealDataEmulator(-22, 104, 32, 5, 5);

		public Example()
		{
            if (ApplicationThemeManager.GetInstance().CurrentTheme == "Windows8Touch")
            {
                this.Resources.MergedDictionaries.Add(new System.Windows.ResourceDictionary() { Source = new Uri("/Gauge;component/Gallery/Thermometer/Win8TouchResources.xaml", UriKind.RelativeOrAbsolute) });
            }
            else
            {
                this.Resources.MergedDictionaries.Add(new System.Windows.ResourceDictionary() { Source = new Uri("/Gauge;component/Gallery/Thermometer/Win8Resources.xaml", UriKind.RelativeOrAbsolute) });
            }
			InitializeComponent();

			valueGenerator.AddRange(-22, -0.1, 0.1);
			valueGenerator.AddRange(0, 10, 0.1);
			valueGenerator.AddRange(10, 60, 0.4);
			valueGenerator.AddRange(60, 80, 0.5);
			valueGenerator.AddRange(80, 104, 0.9, 0.5, 5);

			this.SetupRanges();
		}

		protected override void NewValue()
		{
			this.linearBar.Value = valueGenerator.GetNextValue();
			this.overheatState.Value = this.linearBar.Value;
		}

		private void SetupRanges()
		{
			if (this.threshold != null)
			{
				// Threshold marker belongs to the Celsius scale, so 
				// convert it to the Fahrenheit.
				this.coldRange.Max = this.threshold.Value * 9 / 5 + 32;
				this.overheatRange.Min = this.threshold.Value * 9 / 5 + 32;
			}
		}

		private void ThresholdValueCanged(object sender, Telerik.Windows.Controls.Gauge.RoutedPropertyChangedEventArgs<double> e)
		{
			this.SetupRanges();
		}
	}
}
