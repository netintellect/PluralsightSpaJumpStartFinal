
namespace Telerik.Windows.Examples.ComboBox.FirstLook
{
	public class Category
	{
		private int _ID;
		private string _DisplayName;

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

		public override int GetHashCode()
		{
			return this.ID.GetHashCode();
		}

		public override bool Equals(object obj)
		{
			if (obj is Category)
			{
				return (obj as Category).ID == this.ID;
			}
			return false;
		}
	}
}