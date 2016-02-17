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
using Telerik.Windows.Controls;
using Telerik.Examples.Gauge;

namespace Telerik.Windows.Examples.Gauge.Customization.QuarterCircleGauges
{
	/// <summary>
	/// Interaction logic for Example.xaml
	/// </summary>
	public partial class Example : DynamicBasePage
	{
		public Example()
		{
			InitializeComponent();
		}

		protected override void NewValue()
		{
			needle.Value = radialScale.Min + (radialScale.Max - radialScale.Min) * rnd.NextDouble();
		}

		private void gaugeStyle_SelectionChanged(object sender, SelectionChangedEventArgs e)
		{
			if (gaugeStyle != null && gaugeStyle.SelectedItem != null)
			{
				string styleName = (string)(gaugeStyle.SelectedItem as RadComboBoxItem).DataContext;

				Theme theme = StyleManager.GetTheme(radGauge);
                //if (theme == null)
                //    theme = StyleManager.ApplicationTheme;

				string themeName = "Metro";
                //if (theme != null)
                //    themeName = theme.ToString();

				string gaugeStyleName = themeName + "RadialGauge" + styleName + "Style";
				string scaleStyleName = themeName + "RadialScale" + styleName + "Style";

				radialGauge.Style = this.Resources[gaugeStyleName] as Style;
				radialScale.Style = this.Resources[scaleStyleName] as Style;
			}
		}
	}
}
