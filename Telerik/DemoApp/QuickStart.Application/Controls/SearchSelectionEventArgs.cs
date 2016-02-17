using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Telerik.Windows.QuickStart
{
	public class SearchSelectionEventArgs : EventArgs
	{
		public SearchSelectionEventArgs(object selectedItem)
		{
			this.SelectedItem = selectedItem;
		}
		public object SelectedItem { get; private set; }
	}
}
