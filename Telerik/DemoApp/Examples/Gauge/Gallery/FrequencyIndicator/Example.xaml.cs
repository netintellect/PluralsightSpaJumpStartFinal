using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Animation;
using System.Windows.Shapes;
using Telerik.Examples.Gauge;
using Telerik.Windows.Controls;
using Telerik.Windows.Controls.Gauge;
using Telerik.Windows.Controls.QuickStart.Common.Helpers;

namespace Telerik.Windows.Examples.Gauge.Gallery.FrequencyIndicator
{
	public partial class Example : DynamicBasePage
	{
		/// <summary>
		/// Randomizer
		/// </summary>
		private RealDataEmulator valueGenerator = new RealDataEmulator(0, 50, 25);

		private double startValue;

		public Example()
		{
            if (ApplicationThemeManager.GetInstance().CurrentTheme == "Windows8Touch")
            {
                this.Resources.MergedDictionaries.Add(new System.Windows.ResourceDictionary()
                {
                    Source = new Uri("/Gauge;component/Gallery/FrequencyIndicator/Win8TouchResource.xaml", UriKind.RelativeOrAbsolute)
                });
            }
            else
            {
                this.Resources.MergedDictionaries.Add(new System.Windows.ResourceDictionary()
                {
                    Source = new Uri("/Gauge;component/Gallery/FrequencyIndicator/Win8Resource.xaml", UriKind.RelativeOrAbsolute)
                });
            }
			InitializeComponent();

			valueGenerator.AddRange(30, 50, 0.57, 5, 5);
			valueGenerator.AddRange(20, 30, 0.49, 5, 5);
			valueGenerator.AddRange(0, 5, 0.3, 5, 2.5);
			valueGenerator.AddRange(5, 20, 0.49, 1.5, 1.5);

			CreateBars(this.Resources["AccentBrush"] as SolidColorBrush);

			interval = TimeSpan.FromMilliseconds(120);
		}

		protected override void NewValue()
		{
			valueGenerator.Value = startValue;
			double value = valueGenerator.GetNextValue();
			startValue = value;
			foreach (BarIndicator bar in linearScale.Indicators)
			{
				bar.Value = value; 
				value = valueGenerator.GetNextValue();
			}
		}

		private void CreateBars(SolidColorBrush color)
		{
			//generation of 32 bar indicators
			for (int i = 0; i < 32; i++)
			{
				BarIndicator bar = new BarIndicator();
				bar.Value = 50d;
				bar.Background = color;
				ScaleObject.SetLocation(bar, ScaleObjectLocation.Inside);
				GaugeMeasure offset = new GaugeMeasure(0.028 * i, GridUnitType.Star);
				ScaleObject.SetOffset(bar, offset);
				bar.StartWidth = 0.02;
				bar.EndWidth = 0.02;
				linearScale.Indicators.Add(bar);
			}
		} 
	}
}
