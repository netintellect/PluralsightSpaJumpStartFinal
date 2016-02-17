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
using System.Windows.Shapes;
using Telerik.Examples.Gauge;

namespace Telerik.Windows.Examples.Gauge.Customization.LinearBarRangesBackground
{
/// <summary>
	/// Interaction logic for Linear Scale Indicators
	/// </summary>
	public partial class Example : DynamicBasePage
	{
		/// <summary>
		/// Randomizer
		/// </summary>
		private RealDataEmulator valueGenerator = new RealDataEmulator(0, 100, 0, 15, 15);

		public Example()
		{
			valueGenerator.AddRange(0, 15, 0.1, 20, 1);
			valueGenerator.AddRange(85, 100, 0.9, 1, 20);

			InitializeComponent();
		}

		protected override void NewValue()
		{
			linearBar.Value = valueGenerator.GetNextValue();
		}
	}
}
