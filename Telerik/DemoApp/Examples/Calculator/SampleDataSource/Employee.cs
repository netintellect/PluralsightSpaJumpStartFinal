using System;
using System.ComponentModel;

namespace Telerik.Windows.Examples.Calculator.SampleDataSource
{
    public class Employee : IEditableObject, INotifyPropertyChanged
    {
        EmployeeData backupEmplData;
        private DateTime startingDate;
        private string firstName;
        private string lastName;
        private double salary;
        private OccupationPositions occupation;
        private string phoneNum;

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
            internal double salary;
            internal OccupationPositions occupation;
            internal string phoneNum;
        }

        public Employee()
        {
            //
        }

        public Employee(DateTime startingDate, string fName, string lName, OccupationPositions occ, string phoneNum, double sal)
        {
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

        [Description("Last actualization - 03/21/2010")]
        public double Salary
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



        public void BeginEdit()
        {

        }

        public void CancelEdit()
        {
            Salary = this.backupEmplData.salary;
            StartingDate = this.backupEmplData.startingDate;
            FirstName = this.backupEmplData.firstName;
            LastName = this.backupEmplData.lastName;
            Occupation = this.backupEmplData.occupation;
            PhoneNumber = this.backupEmplData.phoneNum;
        }

        public void EndEdit()
        {
            this.backupEmplData.salary = Salary;
            this.backupEmplData.startingDate = StartingDate;
            this.backupEmplData.firstName = FirstName;
            this.backupEmplData.lastName = LastName;
            this.backupEmplData.occupation = Occupation;
            this.backupEmplData.phoneNum = PhoneNumber;
        }

        public event PropertyChangedEventHandler PropertyChanged;

        private void NotifyPropertyChanged(string info)
        {
            if (PropertyChanged != null)
                PropertyChanged(this, new PropertyChangedEventArgs(info));
        }
    }
}
