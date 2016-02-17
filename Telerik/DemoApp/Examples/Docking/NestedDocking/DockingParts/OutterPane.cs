using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows;
using Telerik.Windows.Controls;

namespace Telerik.Windows.Examples.Docking.NestedDocking.DockingParts
{
	public class OutterPane : RadPane
	{
#if !WPF
		public OutterPane()
		{
			this.DefaultStyleKey = typeof(OutterPane);
		}
#else
		static OutterPane()
		{
			DefaultStyleKeyProperty.OverrideMetadata(typeof(OutterPane), new FrameworkPropertyMetadata(typeof(OutterPane)));
		}
#endif
	}
}
