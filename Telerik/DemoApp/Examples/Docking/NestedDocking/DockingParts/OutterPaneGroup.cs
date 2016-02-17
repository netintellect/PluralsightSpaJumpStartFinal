using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows;
using Telerik.Windows.Controls;

namespace Telerik.Windows.Examples.Docking.NestedDocking.DockingParts
{
	public class OutterPaneGroup : RadPaneGroup
	{
#if !WPF
		public OutterPaneGroup()
		{
			this.DefaultStyleKey = typeof(OutterPaneGroup);
		}
#else
		static OutterPaneGroup()
		{
			DefaultStyleKeyProperty.OverrideMetadata(typeof(OutterPaneGroup), new FrameworkPropertyMetadata(typeof(OutterPaneGroup)));
		}
#endif
	}
}