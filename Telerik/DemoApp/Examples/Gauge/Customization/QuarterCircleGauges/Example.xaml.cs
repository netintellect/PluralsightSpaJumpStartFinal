using System;
using System.Text.RegularExpressions;
using System.Windows;
using System.Windows.Controls;
using Telerik.Examples.Gauge;
using Telerik.Windows.Controls;
using Telerik.Windows.Controls.Gauge;

namespace Telerik.Windows.Examples.Gauge.Customization.QuarterCircleGauges
{
	public partial class Example : DynamicBasePage
	{
		private RealDataEmulator valueGenerator = new RealDataEmulator(0, 50, 25, 20, 21);

		public Example()
		{
			InitializeComponent();
		}

		protected override void NewValue()
		{
			needleNW.Value = valueGenerator.GetNextValue();
			needleNE.Value = valueGenerator.GetNextValue();
			needleSE.Value = valueGenerator.GetNextValue();
			needleSW.Value = valueGenerator.GetNextValue();
		}
	}
}
