using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Windows.Input;
using Telerik.Windows.Controls;

namespace Telerik.Windows.Examples.ComboBox.Validation
{
	public class ViewModel : ViewModelBase, IDataErrorInfo
	{
		private List<Manufacturer> _Manufacturers;
		private ICommand _Search;
		private bool _IsManufacturerChanged;
		private string _Manufacturer;
		private bool _IsModelChanged;
		private string _Model;

		public ViewModel()
		{
			this._Manufacturers = new List<Manufacturer>();
			this._IsManufacturerChanged = false;
			this._IsModelChanged = false;
			this._Search = new DelegateCommand(this.SearchAction);
		}

		public List<Manufacturer> Manufacturers
		{
			get
			{
				return this._Manufacturers;
			}
		}

		public ICommand Search
		{
			get
			{
				return this._Search;
			}
		}

		private void SearchAction(object parameter)
		{
			this._IsManufacturerChanged = true;
			this._IsModelChanged = true;
			this.OnPropertyChanged("Manufacturer");
			this.OnPropertyChanged("Model");
		}

		public string Manufacturer
		{
			get
			{
				return this._Manufacturer;
			}
			set
			{
				if (this._Manufacturer != value)
				{
					this._Manufacturer = value;
					this._IsManufacturerChanged = true;
					this.OnPropertyChanged("Manufacturer");
					this.OnPropertyChanged("Model");
				}
			}
		}

		public string Model
		{
			get
			{
				return this._Model;
			}
			set
			{
				if (this._Model != value)
				{
					this._Model = value;
					this._IsModelChanged = true;
					this.OnPropertyChanged("Model");
				}
			}
		}

		public string Error
		{
			get
			{
				return ValidateManufacturer() ?? ValidateModel();
			}
		}

		public string this[string columnName]
		{
			get
			{
				switch (columnName)
				{
					case "Manufacturer": return this.ValidateManufacturer();
					case "Model": return this.ValidateModel();
				}
				return null;
			}
		}

		private string ValidateManufacturer()
		{
			if (this._IsManufacturerChanged)
			{
				if (this.Manufacturer == String.Empty || this.Manufacturer == null)
				{
					return "Manufacturer field can not be empty";
				}
				if (!this.Manufacturers.Any(this.MatchManufacturerName))
				{
					return "There is no such known manufacturer";
				}
			}
			return null;
		}

		private string ValidateModel()
		{
			if (this._IsModelChanged)
			{
				if (this.Model == String.Empty || this.Model == null)
				{
					return "Model field can not be empty";
				}
				else if (!this.Manufacturers.Where(this.MatchManufacturerName).Any(this.ContainModel))
				{
					return String.Format("There is no such known {0} model", this.Manufacturer);
				}
			}
			return null;
		}

		private bool MatchManufacturerName(Manufacturer m)
		{
			return m.DisplayName == this.Manufacturer;
		}

		private bool ContainModel(Manufacturer m)
		{
			return m.Models.Contains(this.Model);
		}
	}
}