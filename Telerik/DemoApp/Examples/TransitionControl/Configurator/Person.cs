using System.Windows.Media;
using Telerik.Windows.Controls;

namespace Telerik.Windows.Examples.TransitionControl.Configurator
{
	public class Person : ViewModelBase
	{

		private string _DisplayName;
		public string DisplayName
		{
			get
			{
				return this._DisplayName;
			}
			set
			{
				if (value != this._DisplayName)
				{
					this._DisplayName = value;
					this.OnPropertyChanged(() => this.DisplayName);
				}
			}
		}

		private ImageSource _Photo;
		public ImageSource Photo
		{
			get
			{
				return this._Photo;
			}
			set
			{
				if ((object)this._Photo != (object)value)
				{
					this._Photo = value;
					this.OnPropertyChanged(() => this.Photo);
				}
			}
		}

		private string _EMail;
		public string EMail
		{
			get
			{
				return this._EMail;
			}
			set
			{
				if (value != this._EMail)
				{
					this._EMail = value;
					this.OnPropertyChanged(() => this.EMail);
				}
			}
		}

		private string _Company;
		public string Company
		{
			get
			{
				return this._Company;
			}
			set
			{
				if (value != this._Company)
				{
					this._Company = value;
					this.OnPropertyChanged(() => this.Company);
				}
			}
		}

		private string _Position;
		public string Position
		{
			get
			{
				return this._Position;
			}
			set
			{
				if (value != this._Position)
				{
					this._Position = value;
					this.OnPropertyChanged(() => this.Position);
				}
			}
		}
	}
}
