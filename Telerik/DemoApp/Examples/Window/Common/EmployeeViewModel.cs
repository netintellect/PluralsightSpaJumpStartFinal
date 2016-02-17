using System;
using Telerik.Windows.Controls;
using Telerik.Windows.Examples.Window.FirstLook;
using System.Windows;

namespace Telerik.Windows.Examples.Window.Common
{
	public class EmployeeViewModel : ViewModelBase
	{
		private DelegateCommand _EditCommand;
		private DelegateCommand _DeleteCommand;
		private DelegateCommand _OKCommand;
		private DelegateCommand _CancelCommand;

		private EmployeeCollection _Employees;
		private Employee _EmployeesBackUp;
		private Employee EditedEmployee { get; set; }

		private EditDialog _EditDialog;
		
		
		public DelegateCommand EditCommand
		{
			get
			{
				return this._EditCommand;
			}
			set
			{
				this._EditCommand = value;
			}
		}

		public DelegateCommand DeleteCommand
		{
			get
			{
				return this._DeleteCommand;
			}
			set
			{
				this._DeleteCommand = value;
			}
		}

		public DelegateCommand CancelCommand
		{
			get
			{
				return this._CancelCommand;
			}
			set
			{
				this._CancelCommand = value;
			}
		}

		public DelegateCommand OKCommand
		{
			get
			{
				return this._OKCommand;
			}
			set
			{
				this._OKCommand = value;
			}
		}		
		
		public EmployeeCollection Employees
		{
			get
			{
				return this._Employees;
			}
			set
			{
				if (this.Employees != value)
				{
					this._Employees = value;
					this.OnPropertyChanged("Employees");
				}
			}
		}

		public Employee EmployeesBackUp
		{
			get
			{
				return this._EmployeesBackUp;
			}
			set
			{
				if (this.EmployeesBackUp != value)
				{
					this._EmployeesBackUp = value;
					this.OnPropertyChanged("EmployeesBackUp");
				}
			}
		}		
		
		private EmployeeCollection GetEmployees()
		{
			EmployeeCollection employees = new EmployeeCollection();
			

			employees.Add(new Employee("Margaret ", "Peacock", "Sales Representative", "USA", new Uri("../Images/Window/FirstLook/Image1.png", UriKind.Relative),
				"Seattle", "1020 J.George", "556-5677"));
			employees.Add(new Employee("Nancy ", "Davolio", "Sales Representative", "USA", new Uri("../Images/Window/FirstLook/Image4.png", UriKind.Relative),
				"New Jersey", "2800 Cann Ave", "421-9089"));
			employees.Add(new Employee("Andrew ", "Fuller", "Vice President, Sales", "USA", new Uri("../Images/Window/FirstLook/Image2.png", UriKind.Relative),
				"Philadelphia", "1134 Strand Ave", "334-5506"));
			employees.Add(new Employee("Robert ", "King", "Sales Representative", "UK", new Uri("../Images/Window/FirstLook/Image5.png", UriKind.Relative),
				"Phillipsburg", "2992 Johnston St", "541-2288"));
			employees.Add(new Employee("Dan ", "Brinke", "Sales Representative", "USA", new Uri("../Images/Window/FirstLook/Image6.png", UriKind.Relative),
				"New York", "54 Martin K. Ave", "262-6564"));
			employees.Add(new Employee("Steven ", "Buchanan", "Sales Representative", "UK", new Uri("../Images/Window/FirstLook/Image7.png", UriKind.Relative),
				"Ashville", "44 N West Murray", "322-3938"));
			employees.Add(new Employee("Janet ", "Levering", "Sales Representative", "USA", new Uri("../Images/Window/FirstLook/Image8.png", UriKind.Relative),
				"Jersey Shore", "445 North Ct.", "116-1918"));

			return employees;
		}

		public EmployeeViewModel()
		{
			this.Employees = GetEmployees();

			this._EditCommand = new DelegateCommand(this.EditCommandExecuted, this.EditCommandCanExecute);
			this._DeleteCommand = new DelegateCommand(this.DeleteCommandExecuted, this.DeleteCommandCanExecute);
			this._OKCommand = new DelegateCommand(this.OkCommandExecuted, this.OKCommandCanExecute);
			this._CancelCommand = new DelegateCommand(this.CancelCommandExecuted, this.CancelCommandCanExecute);
		}

		public void EditCommandExecuted(object parameter)
		{
			if (parameter != null)
			{
				Employee e = parameter as Employee;
				this._EditDialog = new EditDialog();
				this._EditDialog.ResizeMode = ResizeMode.NoResize;
				this._EditDialog.DataContext = new EmployeeEditorViewModel(e, this.OKCommand, this.CancelCommand);
				this.EditedEmployee = e;
				this.EmployeesBackUp = new Employee
				{
					FirstName = e.FirstName,
					LastName = e.LastName,
					Occupation = e.Occupation,
					Address = e.Address,
					City = e.City,
					Country = e.Country,
					Phone = e.Phone,
					Photo = e.Photo
				};

				this._EditDialog.ShowDialog();
			}
		}

		public bool EditCommandCanExecute(object parameter)
		{
			return true;
		}

		public void DeleteCommandExecuted(object parameter)
		{
			if (parameter != null)
			{
				Employee e = parameter as Employee;
				string name = e.FirstName + e.LastName;

				this.EditedEmployee = e;
				AskConfirmation(name);
			}
		}

		public bool DeleteCommandCanExecute(object parameter)
		{
			return true;			
		}

		public void OkCommandExecuted(object parameter)
		{
			this._EditDialog.Close();
		}

		public bool OKCommandCanExecute(object parameter)
		{
			return true;
		}

		public void CancelCommandExecuted(object parameter)
		{
			this._EditDialog.Close();
			
			this.EditedEmployee.FirstName = this.EmployeesBackUp.FirstName;
			this.EditedEmployee.LastName = this.EmployeesBackUp.LastName;
			this.EditedEmployee.Occupation = this.EmployeesBackUp.Occupation;
			this.EditedEmployee.Address = this.EmployeesBackUp.Address;
			this.EditedEmployee.City = this.EmployeesBackUp.City;
			this.EditedEmployee.Country = this.EmployeesBackUp.Country;
			this.EditedEmployee.Phone = this.EmployeesBackUp.Phone;
			this.EditedEmployee.Photo = this.EmployeesBackUp.Photo;
		}

		public bool CancelCommandCanExecute(object parameter)
		{
			return true;
		}

		public void AskConfirmation(string name)
		{
			string confirmText = "Are you sure you want to delete " + name + " ?";

			RadWindow.Confirm(confirmText, new EventHandler<WindowClosedEventArgs>(OnConfirmClosed));			
		}

		private void OnConfirmClosed(object sender, WindowClosedEventArgs e)
		{			
			if (e.DialogResult == true)
			{
				this.Employees.Remove(this.EditedEmployee);			
			}
		}
	}
}
