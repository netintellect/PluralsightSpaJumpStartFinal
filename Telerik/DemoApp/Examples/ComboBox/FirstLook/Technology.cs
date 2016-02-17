using System.Collections.ObjectModel;

namespace Telerik.Windows.Examples.ComboBox.FirstLook
{
	public class Technology
	{
		private int _ID;
		private string _DisplayName;
		private ObservableCollection<Category> _Categories;

		public Technology()
		{
			this._Categories = new ObservableCollection<Category>();
		}

		public int ID
		{
			get
			{
				return this._ID;
			}
			set
			{
				this._ID = value;
			}
		}

		public string DisplayName
		{
			get
			{
				return this._DisplayName;
			}
			set
			{
				this._DisplayName = value;
			}
		}

		public ObservableCollection<Category> Categories
		{
			get
			{
				return this._Categories;
			}
		}

		public override int GetHashCode()
		{
			return this.ID.GetHashCode();
		}

		public override bool Equals(object obj)
		{
			if (obj is Technology)
			{
				return (obj as Technology).ID == this.ID;
			}
			return false;
		}
	}
}