using Telerik.Windows.Core;

namespace Telerik.Windows.Examples.GanttView.Utils
{
	public class ExampleViewModel : PropertyChangedBase
	{
		private object content;
		private string title;

		/// <Summary>Gets or sets Content and notifies for changes</Summary>
		public object Content
		{
			get { return this.content; }
			set
			{
				if (this.content != value)
				{
					this.content = value;
					this.OnPropertyChanged(() => this.Content);
				}
			}
		}

		/// <Summary>Gets or sets Title and notifies for changes</Summary>
		public string Title
		{
			get { return this.title; }
			set
			{
				if (this.title != value)
				{
					this.title = value;
					this.OnPropertyChanged(() => this.Title);
				}
			}
		}
	}
}