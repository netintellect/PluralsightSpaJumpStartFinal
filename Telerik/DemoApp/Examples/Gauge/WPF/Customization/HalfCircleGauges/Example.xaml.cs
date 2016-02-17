using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using Telerik.Windows.Controls;
using Telerik.Examples.Gauge;

namespace Telerik.Windows.Examples.Gauge.Customization.HalfCircleGauges
{
	/// <summary>
	/// Interaction logic for Example.xaml
	/// </summary>
	public partial class Example : DynamicBasePage
	{
		public Example()
		{
			InitializeComponent();

            this.gaugeStyle.SelectedIndex = 0;
		}

		protected override void NewValue()
		{
			needle.Value = radialScale.Min + (radialScale.Max - radialScale.Min) * rnd.NextDouble();
		}

		private void gaugeStyle_SelectionChanged(object sender, SelectionChangedEventArgs e)
		{
			if (gaugeStyle != null && 
                gaugeStyle.SelectedItem != null)
			{
				string styleName = (string)(gaugeStyle.SelectedItem as RadComboBoxItem).DataContext;

                radGauge.Width = 340;
                radGauge.Height = 200;

                if (styleName.EndsWith("E") || styleName.EndsWith("W"))
                {
                    double tmp = radGauge.Width;
                    radGauge.Width = radGauge.Height;
                    radGauge.Height = tmp;
                } 

				string themeName = "Metro"; 

				string gaugeStyleName = themeName + "RadialGauge" + styleName + "Style";
				string scaleStyleName = themeName + "RadialScale" + styleName + "Style";

				radialGauge.Style = this.Resources[gaugeStyleName] as Style;
				radialScale.Style = this.Resources[scaleStyleName] as Style;
			}
		}
	}
}
