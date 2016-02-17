using System;
using System.Collections;
using System.Net;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Documents;
using System.Windows.Ink;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Animation;
using System.Windows.Shapes;
using Telerik.Windows.Controls.Gauge;

namespace Telerik.Examples.Gauge
{
	/// <summary>
	/// Items source that represents indicator range color mode
	/// </summary>
	public class RangeColorModeItemsSource : EnumItemsSource
	{
		/// <summary>
		/// Creates instance of the class
		/// </summary>
		public RangeColorModeItemsSource()
		{
			this.TypeName = typeof(RangeColorMode).AssemblyQualifiedName;
		}
	}
}
