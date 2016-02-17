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
using System.Windows.Threading;
using Telerik.Examples.Gauge;

namespace Telerik.Windows.Examples.Gauge.Gallery.Thermometer
{
	/// <summary>
	/// Interaction logic for Thermometer
	/// </summary>
	public partial class Example : DynamicBasePage
	{
		/// <summary>
		/// Randomizer
		/// </summary>
		private RealDataEmulator valueGenerator = new RealDataEmulator(-30, 40, 0, 5, 5);

		public Example()
		{
			InitializeComponent();

			valueGenerator.AddRange(-30, -0.1, 0.1);
			valueGenerator.AddRange(0, 10, 0.1);
			valueGenerator.AddRange(10, 25, 0.4);
			valueGenerator.AddRange(25, 30, 0.5);
			valueGenerator.AddRange(30, 40, 0.9, 0.5, 5);
		}

		protected override void NewValue()
		{
			linearBar.Value = valueGenerator.GetNextValue();
		}
	}
}
