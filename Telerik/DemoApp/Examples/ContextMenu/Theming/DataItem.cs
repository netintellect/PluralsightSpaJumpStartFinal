using System.ComponentModel;
using System.Windows.Markup;

namespace Telerik.Windows.Examples.ContextMenu.Theming
{
	[ContentProperty("Children")]
	public class DataItem : INotifyPropertyChanged
	{
		private string text;
		private bool isExpanded;
		private string imageUrl;
		private DataItem parent;
		private DataItemCollection items;

		public DataItem()
		{
			this.items = new DataItemCollection(this);
		}

		public event PropertyChangedEventHandler PropertyChanged;

		public string ImageUrl 
		{
			get
			{
				return this.imageUrl;
			}
			set
			{
				if (this.imageUrl != value)
				{
					this.imageUrl = value;
					this.OnPropertyChanged("ImageUrl");
				}
			}
		}

		public DataItem Parent
		{
			get
			{
				return this.parent;
			}
			set
			{
				this.parent = value;
			}
		}

		public DataItemCollection Items
		{
			get
			{
				return this.items;
			}
		}

		public string Text
		{
			get
			{
				return this.text;
			}
			set
			{
				if (this.text != value)
				{
					this.text = value;
					this.OnPropertyChanged("Text");
				}
			}
		}

		public bool IsExpanded
		{
			get
			{
				return this.isExpanded;
			}
			set
			{
				if (this.isExpanded != value)
				{
					this.isExpanded = value;
					this.OnPropertyChanged("IsExpanded");
				}
			}
		}

		private void OnPropertyChanged(string propertyName)
		{
			if (this.PropertyChanged != null)
			{
				this.PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
			}
		}
	}
}