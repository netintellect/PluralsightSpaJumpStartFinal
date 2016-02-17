using System;
using System.Windows;

namespace Telerik.Windows.Examples.Diagrams.Dashboard
{
	public class HyperlinkToolboxItem : GeometryToolboxItem
	{
		public override Windows.Controls.RadDiagramShape CreateShape()
		{
			var uri = this.Address;
			var text = this.Header;
			if (string.IsNullOrEmpty(text) || string.IsNullOrEmpty(uri))
				return null;

			var shape = new HyperlinkShape
			{
				Address = uri,
				Text = text
			};
			return shape;
		}
	}
}

