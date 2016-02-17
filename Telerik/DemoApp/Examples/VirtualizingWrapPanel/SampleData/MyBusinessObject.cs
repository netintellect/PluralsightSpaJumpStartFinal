using System.ComponentModel;
using System;

namespace Telerik.Windows.Examples.VirtualizingWrapPanel
{
	/// <summary>
	/// MyBusinessObject.
	/// </summary>
	public class MyBusinessObject : INotifyPropertyChanged
	{
		public event PropertyChangedEventHandler PropertyChanged;
		
		private int id;
		private string name;
		private double unitPrice;
		private DateTime date;
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
		/// <param name="id">The id.</param>
		/// <param name="name">The name.</param>
		/// <param name="unitPrice">The unit price.</param>
		/// <param name="date">The date.</param>
		/// <param name="discontinued">if set to <c>true</c> [discontinued].</param>
		public MyBusinessObject(int id, string name, double unitPrice, DateTime date, bool discontinued)
		{
			this.id = id;
			this.name = name;
			this.unitPrice = unitPrice;
			this.date = date;
			this.discontinued = discontinued;
		}

		/// <summary>
		/// Gets or sets the ID.
		/// </summary>
		/// <value>The ID.</value>
		public int ID
		{
			get
			{
				return this.id;
			}
			set
			{
				if (this.ID != value)
				{
					this.id = value;
					this.OnPropertyChanged("ID");
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
		/// Gets or sets the date.
		/// </summary>
		/// <value>The date.</value>
		public DateTime Date
		{
			get
			{
				return this.date;
			}
			set
			{
				if (this.Date != value)
				{
					this.date = value;
					this.OnPropertyChanged("Date");
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
