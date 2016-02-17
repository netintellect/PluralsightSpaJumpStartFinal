using System.ComponentModel;
using System;

namespace Telerik.Windows.Examples.DataFilter
{
	/// <summary>
	/// MyBusinessObject.
	/// </summary>
	public class MyBusinessObject : INotifyPropertyChanged
	{
		public event PropertyChangedEventHandler PropertyChanged;
		
		private string name;
		private int quantity;
		private double unitPrice;
		private DateTime orderDate;
		private DateTime orderTime;
		private bool discontinued;

		/// <summary>
		/// Initializes a new instance of the <see cref="MyBusinessObject"/> class.
		/// </summary>
		public MyBusinessObject()
		{
		}

		/// <summary>
		/// Initializes a new instance of the <see cref="MyBusinessObject"/> class.
		/// </summary>
		/// <param name="name">The name.</param>
		/// <param name="amount">The amount.</param>
		/// <param name="unitPrice">The unit price.</param>
		/// <param name="orderDate">The order date.</param>
		/// <param name="discontinued">if set to <c>true</c> [discontinued].</param>
		/// <param name="orderTime">The order time.</param>
		public MyBusinessObject(string name, int amount, double unitPrice, DateTime orderDate, DateTime orderTime, bool discontinued)
		{
			this.name = name;
			this.quantity = amount;
			this.unitPrice = unitPrice;
			this.orderDate = orderDate;
			this.orderTime = orderTime;
			this.discontinued = discontinued;
		}

		/// <summary>
		/// Gets or sets the quantity.
		/// </summary>
		/// <value>The quantity.</value>
		public int Quantity
		{
			get
			{
				return this.quantity;
			}
			set
			{
				if (this.Quantity != value)
				{
					this.quantity = value;
					this.OnPropertyChanged("Quantity");
				}
			}
		}

		/// <summary>
		/// Gets or sets the name.
		/// </summary>
		/// <value>The name.</value>
		public string Name
		{
			get
			{
				return this.name;
			}
			set
			{
				if (this.Name != value)
				{
					this.name = value;
					this.OnPropertyChanged("Name");
				}
			}
		}

		/// <summary>
		/// Gets or sets the unit price.
		/// </summary>
		/// <value>The unit price.</value>
		public double UnitPrice
		{
			get
			{
				return this.unitPrice;
			}
			set
			{
				if (this.UnitPrice != value)
				{
					this.unitPrice = value;
					this.OnPropertyChanged("UnitPrice");
				}
			}
		}

		/// <summary>
		/// Gets or sets the order date.
		/// </summary>
		/// <value>The order date.</value>
		public DateTime OrderDate
		{
			get
			{
				return this.orderDate;
			}
			set
			{
				if (this.OrderDate != value)
				{
					this.orderDate = value;
					this.OnPropertyChanged("OrderDate");
				}
			}
		}

		/// <summary>
		/// Gets or sets the order time.
		/// </summary>
		/// <value>The order time.</value>
		public DateTime OrderTime
		{
			get
			{
				return this.orderTime;
			}
			set
			{
				if (this.OrderTime != value)
				{
					this.orderTime = value;
					this.OnPropertyChanged("OrderTime");
				}
			}
		}

		/// <summary>
		/// Gets or sets a value indicating whether this <see cref="MyBusinessObject"/> is discontinued.
		/// </summary>
		/// <value><c>true</c> if discontinued; otherwise, <c>false</c>.</value>
		public bool Discontinued
		{
			get
			{
				return this.discontinued;
			}
			set
			{
				if (this.Discontinued != value)
				{
					this.discontinued = value;
					this.OnPropertyChanged("Discontinued");
				}
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
