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

namespace Telerik.Windows.Examples.Window.Common
{
	public class Employee : INotifyPropertyChanged
	{
		private Uri _photo;
		private string _occupation;		
		private string _firstName;
		private string _lastName;
		private string _country;
		private string _city;
		private string _address;
		private string _phone;

		public Uri Photo
		{
			get
			{
				return this._photo;
			}
			set
			{
				if (this.Photo != value)
				{
					this._photo = value;
					this.OnNotifyPropertyChanged("Photo");
				}
			}
		}

		public string Occupation
		{
			get
			{
				return this._occupation;
			}
			set
			{
				if (this.Occupation != value)
				{
					this._occupation = value;
					this.OnNotifyPropertyChanged("Occupation");
				}
			}
		}

		public string Country
		{
			get
			{
				return this._country;
			}
			set
			{
				if (this.Country != value)
				{
					this._country = value;
					this.OnNotifyPropertyChanged("Country");
				}
			}
		}

		public string FirstName
		{
			get
			{
				return this._firstName;
			}
			set
			{
				if (this.FirstName != value)
				{
					this._firstName = value;
					OnNotifyPropertyChanged("FirstName");
				}
			}
		}

		public string LastName
		{
			get
			{
				return this._lastName;
			}
			set
			{
				if (this.LastName != value)
				{
					this._lastName = value;
					OnNotifyPropertyChanged("LastName");
				}
			}
		}

		public string City
		{
			get
			{
				return this._city;
			}
			set
			{
				if (this.City != value)
				{
					this._city = value;
					OnNotifyPropertyChanged("City");
				}
			}
		}

		public string Address
		{
			get
			{
				return this._address;
			}
			set
			{
				if (this.Address != value)
				{
					this._address = value;
					OnNotifyPropertyChanged("Address");
				}
			}
		}

		public string Phone
		{
			get
			{
				return this._phone;
			}
			set
			{
				if (this.Phone != value)
				{
					this._phone = value;
					OnNotifyPropertyChanged("Phone");
				}
			}
		}

		protected void OnNotifyPropertyChanged(string propertyName)
		{
			if (null != this.PropertyChanged)
			{
				this.PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
			}
		}
		public event PropertyChangedEventHandler PropertyChanged;

		public Employee()
		{
			
		}

		public Employee(string firstName, string lastName, string occupation, string country, Uri photo, string city, string address, string phone)
		{			
			this._firstName = firstName;
			this._lastName = lastName;
			this._occupation = occupation;
			this._country = country;
			this._city = city;
			this._address = address;
			this._phone = phone;
			this._photo = photo;
		}
	}
}
