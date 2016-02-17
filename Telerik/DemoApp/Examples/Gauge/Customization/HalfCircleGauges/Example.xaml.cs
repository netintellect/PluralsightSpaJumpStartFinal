using System;
using System.Text.RegularExpressions;
using System.Windows;
using System.Windows.Controls;
using Telerik.Examples.Gauge;
using Telerik.Windows.Controls;
using Telerik.Windows.Controls.Gauge;

namespace Telerik.Windows.Examples.Gauge.Customization.HalfCircleGauges
{
	public partial class Example : DynamicBasePage
	{
		private RealDataEmulator valueGenerator = new RealDataEmulator(0, 100, 50, 20, 21);

		public Example()
		{
			InitializeComponent();
		}

		protected override void NewValue()
		{
			needleNorth.Value = valueGenerator.GetNextValue();
			needleSouth.Value = valueGenerator.GetNextValue();
			needleWest.Value = valueGenerator.GetNextValue();
			needleEast.Value = valueGenerator.GetNextValue();
		}
	}
}
