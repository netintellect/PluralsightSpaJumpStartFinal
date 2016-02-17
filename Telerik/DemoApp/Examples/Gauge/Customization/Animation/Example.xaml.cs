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

namespace Telerik.Windows.Examples.Gauge.Customization.Animation
{
	public partial class Example : DynamicBasePage
	{
		/// <summary>
		/// Randomizers
		/// </summary>
		private RealDataEmulator valueGenerator = new RealDataEmulator(0, 100, 50, 20, 21);
		private RealDataEmulator radialBarGenerator = new RealDataEmulator(0, 100, 75, 10, 10);
		private RealDataEmulator markerGenerator = new RealDataEmulator(0, 100, 25, 15, 15);

		public Example()
		{
            if (ApplicationThemeManager.GetInstance().CurrentTheme == "Windows8Touch")
            {
                this.Resources.MergedDictionaries.Add(new System.Windows.ResourceDictionary() { Source = new Uri("/Gauge;component/Customization/Animation/Win8TouchResources.xaml", UriKind.RelativeOrAbsolute) });
            }
            else
            {
                this.Resources.MergedDictionaries.Add(new System.Windows.ResourceDictionary() { Source = new Uri("/Gauge;component/Customization/Animation/Win8Resources.xaml", UriKind.RelativeOrAbsolute) });
            }
			InitializeComponent();
		}

		protected override void NewValue()
		{
			needle.Value = valueGenerator.GetNextValue();
			markerGenerator.GetNextValue();
			marker.Value = markerGenerator.GetNextValue();
			radialBarGenerator.GetNextValue();
			radialBarGenerator.GetNextValue();
			radialBar.Value = radialBarGenerator.GetNextValue();
		}
	}
}
