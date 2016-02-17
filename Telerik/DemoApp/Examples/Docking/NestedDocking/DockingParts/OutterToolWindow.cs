using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows;
using Telerik.Windows.Controls.Docking;

namespace Telerik.Windows.Examples.Docking.NestedDocking.DockingParts
{
	public class OutterToolWindow : ToolWindow
	{
		#if !WPF
		public OutterToolWindow()
		{
			this.DefaultStyleKey = typeof(OutterToolWindow);
		}
#else
		static OutterToolWindow()
		{
			DefaultStyleKeyProperty.OverrideMetadata(typeof(OutterToolWindow), new FrameworkPropertyMetadata(typeof(OutterToolWindow)));
		}
#endif
	}
}