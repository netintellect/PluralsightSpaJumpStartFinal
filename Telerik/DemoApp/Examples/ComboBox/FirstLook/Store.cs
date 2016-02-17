using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Windows.Data;
using Telerik.Windows.Controls;

namespace Telerik.Windows.Examples.ComboBox.FirstLook
{
	public class Store : ViewModelBase
	{
		private string _SortBy;
		public ReadOnlyObservableCollection<string> _SortFields;
		private CollectionViewSource _FilteredBooks;
		private CollectionViewSource _FilteredCategories;
		private Technology _SelectedTechnology;
		private Category _SelectedCategory;
		private ObservableBookCollection _Books;
		private ObservableCollection<Technology> _Technologies;
		private ObservableCollection<Category> _Categories;

		public Store()
		{
			this._Books = new ObservableBookCollection();
			this._Technologies = new ObservableCollection<Technology>();
			this._Categories = new ObservableCollection<Category>();

			this._FilteredBooks = new CollectionViewSource();
			this._FilteredBooks.Source = this.Books;
			this._FilteredBooks.Filter += FilterBooks;

			this._FilteredCategories = new CollectionViewSource();
			this._FilteredCategories.Source = this.Categories;
			this._FilteredCategories.Filter += FilterCategories;

			ObservableCollection<string> sortFields = new ObservableCollection<string>();
			sortFields.Add("Price");
			sortFields.Add("PublishDate");
			sortFields.Add("Rating");
			this._SortFields = new ReadOnlyObservableCollection<string>(sortFields);
		}

		public string SortBy
		{
			get
			{
				return this._SortBy;
			}
			set
			{
				if (this._SortBy != value)
				{
					this._SortBy = value;
					this.OnPropertyChanged("SortBy");
					this.FilteredBooks.SortDescriptions.Clear();
					if (this.SortBy != null)
					{
						this.FilteredBooks.SortDescriptions.Add(new SortDescription(SortBy, ListSortDirection.Descending));
					}
				}
			}
		}

		public ReadOnlyObservableCollection<string> SortFields
		{
			get
			{
				return this._SortFields;
			}
		}

		public CollectionViewSource FilteredBooks
		{
			get
			{
				return this._FilteredBooks;
			}
		}

		public CollectionViewSource FilteredCategories
		{
			get
			{
				return this._FilteredCategories;
			}
		}

		public Technology SelectedTechnology
		{
			get
			{
				return this._SelectedTechnology;
			}
			set
			{
				if (this._SelectedTechnology != value)
				{
					this._SelectedTechnology = value;
					this.OnPropertyChanged("SelectedTechnology");
					this.FilteredCategories.View.Refresh();
					this.FilteredBooks.View.Refresh();
				}
			}
		}

		public Category SelectedCategory
		{
			get
			{
				return this._SelectedCategory;
			}
			set
			{
				if (this._SelectedCategory != value)
				{
					this._SelectedCategory = value;
					this.OnPropertyChanged("SelectedCategory");
					this.FilteredBooks.View.Refresh();
				}
			}
		}

		public ObservableBookCollection Books
		{
			get
			{
				return this._Books;
			}
		}

		public ObservableCollection<Technology> Technologies
		{
			get
			{
				return this._Technologies;
			}
		}

		public ObservableCollection<Category> Categories
		{
			get
			{
				return this._Categories;
			}
		}

		private void FilterCategories(object sender, FilterEventArgs e)
		{
			Category b = e.Item as Category;
			if (b != null)
			{
				e.Accepted = (this.SelectedTechnology == null) || this.SelectedTechnology.Categories.Contains(b);
			}
		}

		private void FilterBooks(object sender, FilterEventArgs e)
		{
			Book b = e.Item as Book;
			if (b != null)
			{
				e.Accepted = (this.SelectedTechnology == null || b.Technology.Equals(this.SelectedTechnology)) && (this.SelectedCategory == null || b.Category.Equals(this.SelectedCategory));
			}
		}
	}
}