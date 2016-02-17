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
using System.ComponentModel.DataAnnotations;

namespace Telerik.Windows.Examples.DataForm.CustomValidation
{
	public class Employee : INotifyPropertyChanged, IEditableObject
	{
		private string firstName;

		public string FirstName
		{
			get
			{
				return firstName;
			}
			set
			{

				firstName = value;
				OnPropertyChanged("FirstName");
			}
		}

		private string lastName;

		public string LastName
		{
			get
			{
				return lastName;
			}
			set
			{
				lastName = value;
				OnPropertyChanged("LastName");
			}
		}

		private DateTime hireDate;
		[CustomValidation(typeof(CustomValidator), "ValidateHireDate")]
		public DateTime HireDate
		{
			get
			{
				return hireDate;
			}
			set
			{
				hireDate = value;				
				OnPropertyChanged("HireDate");
			}
		}

		private Departments department;

		public Departments Department
		{
			get
			{
				return department;
			}
			set
			{
				department = value;
				OnPropertyChanged("Department");
			}
		}

		private Occupations occupation;
		[CustomValidation(typeof(CustomValidator), "ValidateOccupation")]
		public Occupations Occupation
		{
			get
			{
				return occupation;
			}
			set
			{
				occupation = value;
				OnPropertyChanged("Occupation");
			}
		}

		protected void OnPropertyChanged(string propertyName)
		{
			if (this.PropertyChanged != null)
			{
				this.PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
			}
		}

		public event PropertyChangedEventHandler PropertyChanged;

		private BackupData backup = new BackupData();

		private struct BackupData
		{
			public string firstName;
			public string lastName;
			public DateTime hireDate;
			public Departments department;
			public Occupations occupation;
		}

		public void BeginEdit()
		{
			backup.department = this.Department;
			backup.firstName = this.FirstName;
			backup.lastName = this.LastName;
			backup.occupation = this.Occupation;
			backup.hireDate = this.HireDate;			
		}

		public void CancelEdit()
		{
			this.Department = backup.department;
			this.FirstName = backup.firstName;
			this.LastName = backup.lastName;
			this.Occupation = backup.occupation;
			this.HireDate = backup.hireDate;
		}

		public void EndEdit()
		{
			backup.department = this.Department;
			backup.firstName = this.FirstName;
			backup.lastName = this.LastName;
			backup.occupation = this.Occupation;
			backup.hireDate = this.HireDate;
		}
	}
}
