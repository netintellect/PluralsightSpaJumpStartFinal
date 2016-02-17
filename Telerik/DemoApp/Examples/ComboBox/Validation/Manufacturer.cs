using System.Collections.Generic;
using Telerik.Windows.Controls;

namespace Telerik.Windows.Examples.ComboBox.Validation
{
	public class Manufacturer : ViewModelBase
	{
		private string _DisplayName;
		private List<string> _Models;

		public Manufacturer()
		{
			this._Models = new List<string>();
		}

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

		public List<string> Models
		{
			get
			{
				return this._Models;
			}
		}
	}
}