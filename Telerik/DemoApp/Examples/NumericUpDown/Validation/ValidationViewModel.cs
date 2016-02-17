using System;
using System.Net;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Documents;
using System.Windows.Ink;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Animation;
using System.Windows.Shapes;
using Telerik.Windows.Controls;
using System.ComponentModel;

namespace Telerik.Windows.Examples.NumericUpDown.Validation
{
	public class ValidationViewModel : ViewModelBase, IDataErrorInfo
	{
		public ValidationViewModel()
		{
			this._StartingPriceChanged = false;
			this._OpenAuction = new DelegateCommand(this.OpenAuctionAction);
		}

		private ICommand _OpenAuction;
		public ICommand OpenAuction
		{
			get
			{
				return this._OpenAuction;
			}
		}

		private void OpenAuctionAction(object param)
		{
			this._StartingPriceChanged = true;
			this.OnPropertyChanged("StartingPrice");
			this.OnPropertyChanged("BuyoutPrice");
		}

		private bool _StartingPriceChanged;

		private double? _StartingPrice;
		public double? StartingPrice
		{
			get
			{
				return this._StartingPrice;
			}
			set
			{
				if (this._StartingPrice != value)
				{
					this._StartingPrice = value;
					this._StartingPriceChanged = true;
					this.ValidateStartingPrice();
					this.OnPropertyChanged("StartingPrice");
				}
			}
		}

		private double? _BuyoutPrice;
		public double? BuyoutPrice
		{
			get
			{
				return this._BuyoutPrice;
			}
			set
			{
				if (this._BuyoutPrice != value)
				{
					this._BuyoutPrice = value;
					this.ValidateBuyoutPrice();
					this.OnPropertyChanged("BuyoutPrice");
				}
			}
		}

		private string ValidateStartingPrice()
		{
			if (this._StartingPriceChanged)
			{
				if (!this.StartingPrice.HasValue)
				{
					return "Starting price can not be empty";
				}
				else if (this.StartingPrice.Value < 5)
				{
					return "Starting price can not be less than $5";
				}
				else if (this.StartingPrice.Value > 500)
				{
					return "Starting price can not be greater than $500";
				}
			}
			return null;
		}

		private string ValidateBuyoutPrice()
		{
			if (this.BuyoutPrice.HasValue && this.StartingPrice.HasValue && this.BuyoutPrice < 5 * this.StartingPrice)
			{
				return "Buyout should be inactive or buyout price should be 5 times larger the starting price.";
			}
			return null;
		}

		public string Error
		{
			get
			{
				return this.ValidateStartingPrice() ?? this.ValidateBuyoutPrice();
			}
		}

		public string this[string columnName]
		{
			get
			{
				switch (columnName)
				{
					case "StartingPrice": return this.ValidateStartingPrice();
					case "BuyoutPrice": return this.ValidateBuyoutPrice();
				}
				return null;
			}
		}
	}
}
