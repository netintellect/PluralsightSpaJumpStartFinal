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
using System.ComponentModel;
using System.Collections.ObjectModel;

namespace Telerik.Windows.Examples
{
	public class Employee : INotifyPropertyChanged
	{
		private int employeeID;

		private string lastName;

		private string firstName;

		private string title;

		private string titleOfCourtesy;

		private DateTime? birthDate;

		private DateTime? hireDate;

		private string address;

		private string city;

		private string email;

		private string region;

		private string postalCode;

		private string country;

		private string homePhone;

		private string extension;

		private string photo;

		private string notes;

		public Employee()
		{
		}

		public event PropertyChangedEventHandler PropertyChanged;

		public int EmployeeID
		{
			get
			{
				return this.employeeID;
			}
			set
			{
				if (this.employeeID != value)
				{
					this.employeeID = value;
					this.OnPropertyChanged("EmployeeID");
				}
			}
		}

		public string LastName
		{
			get
			{
				return this.lastName;
			}
			set
			{
				if (this.lastName != value)
				{
					this.lastName = value;
					this.OnPropertyChanged("LastName");
				}
			}
		}

		public string FirstName
		{
			get
			{
				return this.firstName;
			}
			set
			{
				if (this.firstName != value)
				{
					this.firstName = value;
					this.OnPropertyChanged("FirstName");
				}
			}
		}

		public string Title
		{
			get
			{
				return this.title;
			}
			set
			{
				if (this.title != value)
				{
					this.title = value;
					this.OnPropertyChanged("Title");
				}
			}
		}

		public string TitleOfCourtesy
		{
			get
			{
				return this.titleOfCourtesy;
			}
			set
			{
				if (this.titleOfCourtesy != value)
				{
					this.titleOfCourtesy = value;
					this.OnPropertyChanged("TitleOfCourtesy");
				}
			}
		}

		public DateTime? BirthDate
		{
			get
			{
				return this.birthDate;
			}
			set
			{
				if (this.birthDate != value)
				{
					this.birthDate = value;
					this.OnPropertyChanged("BirthDate");
				}
			}
		}

		public DateTime? HireDate
		{
			get
			{
				return this.hireDate;
			}
			set
			{
				if (this.hireDate != value)
				{
					this.hireDate = value;
					this.OnPropertyChanged("HireDate");
				}
			}
		}

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

		public string Email
		{
			get
			{
				return this.email;
			}
			set
			{
				if (this.email != value)
				{
					this.email = value;
					this.OnPropertyChanged("Email");
				}
			}
		}

		public string Region
		{
			get
			{
				return this.region;
			}
			set
			{
				if (this.region != value)
				{
					this.region = value;
					this.OnPropertyChanged("Region");
				}
			}
		}

		public string PostalCode
		{
			get
			{
				return this.postalCode;
			}
			set
			{
				if (this.postalCode != value)
				{
					this.postalCode = value;
					this.OnPropertyChanged("PostalCode");
				}
			}
		}

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

		public string HomePhone
		{
			get
			{
				return this.homePhone;
			}
			set
			{
				if (this.homePhone != value)
				{
					this.homePhone = value;
					this.OnPropertyChanged("HomePhone");
				}
			}
		}

		public string Extension
		{
			get
			{
				return this.extension;
			}
			set
			{
				if (this.extension != value)
				{
					this.extension = value;
					this.OnPropertyChanged("Extension");
				}
			}
		}

		public string Photo
		{
			get
			{
				return this.photo;
			}
			set
			{
				if (this.photo != value)
				{
					this.photo = value;
					this.OnPropertyChanged("Photo");
				}
			}
		}

		public string Notes
		{
			get
			{
				return this.notes;
			}
			set
			{
				if (this.notes != value)
				{
					this.notes = value;
					this.OnPropertyChanged("Notes");
				}
			}
		}

		protected void OnPropertyChanged(string propertyName)
		{
			if (this.PropertyChanged != null)
			{
				this.PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
			}
		}
	}
}
