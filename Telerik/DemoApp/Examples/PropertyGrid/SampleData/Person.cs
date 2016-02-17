using System;
using System.Linq;
using System.ComponentModel;

namespace Telerik.Windows.Examples.PropertyGrid
{
	public class Person : INotifyPropertyChanged
	{
		readonly EmployeeData backupEmplData;
		private DateTime startingDate;
		private string firstName;
		private string lastName;
		private int salary;
		private OccupationPositions occupation;
		private string phoneNum;
        private int departmentId;

		public enum OccupationPositions
		{
			Casheer,
			Consultant,
			Security,
			Supplies,
			SuppliesManager,
			StaffManager,
			HygeneStaff
		}

		public struct EmployeeData
		{
			internal DateTime startingDate;
			internal string firstName;
			internal string lastName;
			internal int salary;
			internal OccupationPositions occupation;
			internal string phoneNum;
            internal int departmentId;
		}

		public Person()
		{
			//
		}

		public Person(DateTime startingDate, string fName, string lName, OccupationPositions occ, string phoneNum, int sal, int departmentId)
		{
            this.departmentId = departmentId;
            this.backupEmplData.departmentId = departmentId;
			this.backupEmplData = new EmployeeData();
			this.backupEmplData.startingDate = startingDate;
			this.StartingDate = startingDate;
			this.backupEmplData.salary = sal;
			this.Salary = sal;
			this.backupEmplData.firstName = fName;
			this.FirstName = fName;
			this.backupEmplData.lastName = lName;
			this.LastName = lName;
			this.backupEmplData.occupation = occ;
			this.Occupation = occ;
			this.backupEmplData.phoneNum = phoneNum;
			this.PhoneNumber = phoneNum;
			this.StartingDate = startingDate;
		}

		public string FirstName
		{
			get
			{
				return firstName;
			}
			set
			{
				firstName = value;
				NotifyPropertyChanged("FirstName");
			}
		}

		public string LastName
		{
			get
			{
				return lastName;
			}
			set
			{
				lastName = value;
				NotifyPropertyChanged("LastName");
			}
		}

		public OccupationPositions Occupation
		{
			get
			{
				return occupation;
			}
			set
			{
				occupation = value;
				NotifyPropertyChanged("Occupation");
			}
		}

		public DateTime StartingDate
		{
			get
			{
				return startingDate;
			}
			set
			{
				startingDate = value;
				NotifyPropertyChanged("StartingDate");
			}
		}
       
        public int DepartmentID
        {
            get 
            { 
                return departmentId; 
            }
            set 
            { 
                departmentId = value;
                NotifyPropertyChanged("DepartmentID");
            }
        }
        

		public string PhoneNumber
		{
			get
			{
				return phoneNum;
			}
			set
			{
				phoneNum = value;
				NotifyPropertyChanged("PhoneNumber");
			}
		}
		
		public int Salary
		{
			get
			{
				return salary;
			}
			set
			{
				salary = value;
				NotifyPropertyChanged("Salary");
			}
		}


		public event PropertyChangedEventHandler PropertyChanged;

		private void NotifyPropertyChanged(string info)
		{
			if (PropertyChanged != null)
				PropertyChanged(this, new PropertyChangedEventArgs(info));
		}
	}
}