using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Data;

namespace Telerik.Windows.QuickStart
{
	public class SearchFilterEventArgs : EventArgs
	{
		internal SearchFilterEventArgs(string searchText, FilterEventArgs wrappedFilterEventArgs)
		{
			this.filterEventArgs = wrappedFilterEventArgs;
			this.SearchText = searchText;
		}

		FilterEventArgs filterEventArgs;

		public string SearchText { get; private set; }
		
		public bool Accepted
		{ 
			get
			{
				return this.filterEventArgs.Accepted;
			}
			set
			{
				this.filterEventArgs.Accepted = value;
			}
		}
		public object Item
		{
			get
			{
				return this.filterEventArgs.Item;
			}
		}
	}
}
