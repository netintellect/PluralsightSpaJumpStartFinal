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
using Telerik.Examples.Gauge;

namespace Telerik.Windows.Examples.Gauge.Customization.Range
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
			marker.Value = radialScale.Min + (radialScale.Max - radialScale.Min) * rnd.NextDouble();
		}
	}
}
