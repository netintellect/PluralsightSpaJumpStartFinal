using System;
using System.ComponentModel;
using Telerik.Windows.Controls;

namespace Telerik.Windows.Examples.ComboBox.FirstLook
{
	public class Book : ViewModelBase
	{
		private string _DisplayName;
		private string _Image;
		private string _Author;
		private Technology _Technology;
		private Category _Category;
		private double _Price;
		private DateTime _PublishDate;
		private int _Rating;

		public string DisplayName
		{
			get
			{
				return this._DisplayName;
			}
			set
			{
				if (this._DisplayName != value)
				{
					this._DisplayName = value;
					this.OnPropertyChanged("DisplayName");
				}
			}
		}

		public string Image
		{
			get
			{
				return this._Image;
			}
			set
			{
				if (this._Image != value)
				{
					this._Image = value;
					this.OnPropertyChanged("Image");
				}
			}
		}

		public string Author
		{
			get
			{
				return this._Author;
			}
			set
			{
				if (this._Author != value)
				{
					this._Author = value;
					this.OnPropertyChanged("Author");
				}
			}
		}

		public Technology Technology
		{
			get
			{
				return this._Technology;
			}
			set
			{
				if (this._Technology != value)
				{
					this._Technology = value;
					this.OnPropertyChanged("Technology");
				}
			}
		}

		public Category Category
		{
			get
			{
				return this._Category;
			}
			set
			{
				if (this._Category != value)
				{
					this._Category = value;
					this.OnPropertyChanged("Category");
				}
			}
		}

		public double Price
		{
			get
			{
				return this._Price;
			}
			set
			{
				if (this._Price != value)
				{
					this._Price = value;
					this.OnPropertyChanged("Price");
				}
			}
		}

		[TypeConverter(typeof(Telerik.Windows.Controls.DateTimeTypeConverter))]
		public DateTime PublishDate
		{
			get
			{
				return this._PublishDate;
			}
			set
			{
				if (this._PublishDate != value)
				{
					this._PublishDate = value;
					this.OnPropertyChanged("PublishDate");
				}
			}
		}

		public int Rating
		{
			get
			{
				return this._Rating;
			}
			set
			{
				if (this._Rating != value)
				{
					this._Rating = value;
					this.OnPropertyChanged("Rating");
				}
			}
		}
	}
}