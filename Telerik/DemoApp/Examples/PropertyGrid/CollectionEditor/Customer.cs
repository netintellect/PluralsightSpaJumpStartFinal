using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace Telerik.Windows.Examples.PropertyGrid.CollectionEditor
{
	public class Customer : INotifyPropertyChanged
	{
		public event PropertyChangedEventHandler PropertyChanged;

		private string customerID;

		[Display(Order = 4, Name= "Customer ID")]
		public string CustomerID
		{
			get
			{
				return this.customerID;
			}
			set
			{
				if (this.customerID != value)
				{
					this.customerID = value;
					this.OnPropertyChanged("CustomerID");
				}
			}
		}

		private string companyName;

		[Display(Order = 0, Name = "Company Name")]
		public string CompanyName
		{
			get
			{
				return this.companyName;
			}
			set
			{
				if (this.companyName != value)
				{
					this.companyName = value;
					this.OnPropertyChanged("CompanyName");
				}
			}
		}

		private string contactName;

		[Display(Order = 2, Name = "Contact Name")]
		public string ContactName
		{
			get
			{
				return this.contactName;
			}
			set
			{
				if (this.contactName != value)
				{
					this.contactName = value;
					this.OnPropertyChanged("ContactName");
				}
			}
		}

		private string contactTitle;

		[Display(Order = 1, Name = "Company Title")]
		public string ContactTitle
		{
			get
			{
				return this.contactTitle;
			}
			set
			{
				if (this.contactTitle != value)
				{
					this.contactTitle = value;
					this.OnPropertyChanged("ContactTitle");
				}
			}
		}

		private string address;

		[Display(Order = 5)]
		public string Address
		{
			get
			{
				return this.address;
			}
			set
			{
				if (this.address != value)
				{
					this.address = value;
					this.OnPropertyChanged("Address");
				}
			}
		}

		private string city;

		[Display(Order = 6)]
		public string City
		{
			get
			{
				return this.city;
			}
			set
			{
				if (this.city != value)
				{
					this.city = value;
					this.OnPropertyChanged("City");
				}
			}
		}

		private string country;

		[Display(Order = 8)]
		public string Country
		{
			get
			{
				return this.country;
			}
			set
			{
				if (this.country != value)
				{
					this.country = value;
					this.OnPropertyChanged("Country");
				}
			}
		}

		private string phone;

		[Display(Order = 9)]
		public string Phone
		{
			get
			{
				return this.phone;
			}
			set
			{
				if (this.phone != value)
				{
					this.phone = value;
					this.OnPropertyChanged("Phone");
				}
			}
		}

		private List<Order> orders;

		[Display(Order = 10)]
		public List<Order> Orders
		{
			get
			{
				if (this.orders == null)
				{
					this.orders = new List<Order>();
				}
				return this.orders;
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
