using System.Collections;
using Telerik.Windows.Core;

namespace Telerik.Windows.Examples.GanttView.Highlighting
{
	public class HighlightModes : PropertyChangedBase
	{
		private string label;
		private IEnumerable items;

		/// <Summary>Gets or sets Label and notifies for changes</Summary>
		public string Label
		{
			get { return this.label; }
			set
			{
				if (this.label != value)
				{
					this.label = value;
					this.OnPropertyChanged(() => this.Label);
				}
			}
		}

		/// <Summary>Gets or sets Items and notifies for changes</Summary>
		public IEnumerable Items
		{
			get { return this.items; }
			set
			{
				if (this.items != value)
				{
					this.items = value;
					this.OnPropertyChanged(() => this.Items);
				}
			}
		}

		public override string ToString()
		{
			return this.Label;
		}
	}
}