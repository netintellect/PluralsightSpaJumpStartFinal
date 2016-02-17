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
using Telerik.Windows.Examples;
using System.Collections.Generic;

namespace Examples.OutlookBar.CS
{
	public class Contacts : ObservableCollection<Employee>
	{
		public Contacts()
		{
			ObservableCollection<Employee> employees = ExamplesDB.GetEmployeesCollection();

			foreach (Employee employee in employees)
			{
				employee.Photo = employee.Photo.Insert(0, @"../Images/OutlookBar/");
				employee.Photo = employee.Photo.Replace("jpg", "png");
				this.Add(employee);
			}
		}
	}
}
