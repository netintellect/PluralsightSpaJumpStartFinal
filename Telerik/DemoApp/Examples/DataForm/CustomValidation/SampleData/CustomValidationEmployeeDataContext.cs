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
using System.Collections.ObjectModel;

namespace Telerik.Windows.Examples.DataForm.CustomValidation
{
	public class CustomValidationEmployeeDataContext
	{
		private ObservableCollection<Employee> employees;

		public ObservableCollection<Employee> Employees
		{
			get
			{
				if (employees == null)
				{
					employees = new ObservableCollection<Employee>() 
					{ 
						new Employee() { FirstName = "John", LastName = "Peterson", HireDate = new DateTime(2005, 10, 10), Department = Departments.London, Occupation = Occupations.QAEngineer},
						new Employee() { FirstName = "Sarah", LastName = "Richards", HireDate = new DateTime(2009, 6, 27), Department = Departments.Chicago, Occupation = Occupations.SoftwareDeveloper},
						new Employee() { FirstName = "Jane", LastName = "Simpson", HireDate = new DateTime(2002, 11, 6), Department = Departments.Munich, Occupation = Occupations.SupportSpecialist},
						new Employee() { FirstName = "Peter", LastName = "Richards", HireDate = new DateTime(2011, 6, 14), Department = Departments.Munich, Occupation = Occupations.SoftwareDeveloper}
					};
				}
				return employees;
			}
		}
	}
}
