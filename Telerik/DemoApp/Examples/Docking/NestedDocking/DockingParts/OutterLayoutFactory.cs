using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows;
using Telerik.Windows.Controls.Docking;

namespace Telerik.Windows.Examples.Docking.NestedDocking.DockingParts
{
	public class OutterLayoutFactory : DefaultGeneratedItemsFactory
	{
		public override ToolWindow CreateToolWindow()
		{
			return new OutterToolWindow();
		}

		public override Controls.RadPaneGroup CreatePaneGroup()
		{
			return new OutterPaneGroup();
		}
	}
}
