using System;
using System.Net;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Documents;
using System.Windows.Ink;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Animation;
using System.Windows.Shapes;
using Telerik.Windows.Controls.Docking;

namespace Telerik.Windows.Examples.Docking.NestedDocking.DockingParts
{
	public class OutterPaneHeader : PaneHeader
	{
		#if !WPF
		public OutterPaneHeader()
		{
			this.DefaultStyleKey = typeof(OutterPaneHeader);
		}
		#else
				static OutterPaneHeader()
				{
					DefaultStyleKeyProperty.OverrideMetadata(typeof(OutterPaneHeader), new FrameworkPropertyMetadata(typeof(OutterPaneHeader)));
				}
		#endif
	}
}
