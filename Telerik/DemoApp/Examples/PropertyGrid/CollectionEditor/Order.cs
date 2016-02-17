using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel;

namespace Telerik.Windows.Examples.PropertyGrid.CollectionEditor
{
	public class Order : INotifyPropertyChanged
	{
		public event PropertyChangedEventHandler PropertyChanged;

		private DateTime orderDate;

		[Display(Order = 1, Name = "Order Date")]
		public DateTime OrderDate
		{
			get
			{
				return this.orderDate;
			}
			set
			{
				if (this.orderDate != value)
				{
					this.orderDate = value;
					this.OnPropertyChanged("OrderDate");
				}
			}
		}

		private DateTime shippedDate;

		[Display(Order = 2, Name = "Shipped Date")]
		public DateTime ShippedDate
		{
			get
			{
				return this.shippedDate;
			}
			set
			{
				if (this.shippedDate != value)
				{
					this.shippedDate = value;
					this.OnPropertyChanged("ShippedDate");
				}
			}
		}

		private string shipAddress;

		[Display(Order = 3, Name = "Address")]
		public string ShipAddress
		{
			get
			{
				return this.shipAddress;
			}
			set
			{
				if (this.shipAddress != value)
				{
					this.shipAddress = value;
					this.OnPropertyChanged("ShipAddress");
				}
			}
		}

		private string shipCountry;

		[Display(Order = 4, Name = "Country")]
		public string ShipCountry
		{
			get
			{
				return this.shipCountry;
			}
			set
			{
				if (this.shipCountry != value)
				{
					this.shipCountry = value;
					this.OnPropertyChanged("ShipCountry");
				}
			}
		}

		private string shipPostalCode;

		[Display(Order = 5, Name = "Postal Code")]
		public string ShipPostalCode
		{
			get
			{
				return this.shipPostalCode;
			}
			set
			{
				if (this.shipPostalCode != value)
				{
					this.shipPostalCode = value;
					this.OnPropertyChanged("ShipPostalCode");
				}
			}
		}

		private string shipName;

		[Display(Order = 0, Name = "Name")]
		public string ShipName
		{
			get
			{
				return this.shipName;
			}
			set
			{
				if (this.shipName != value)
				{
					this.shipName = value;
					this.OnPropertyChanged("ShipName");
				}
			}
		}

		public override string ToString()
		{
			return this.ShipName;
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
