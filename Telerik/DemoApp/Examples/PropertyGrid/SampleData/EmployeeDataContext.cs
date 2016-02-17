using System;
using System.Linq;
using System.ComponentModel;
using System.Collections.ObjectModel;
using Telerik.Windows.Data;

namespace Telerik.Windows.Examples.PropertyGrid
{
	public class EmployeeDataContext
	{
		private ICollectionView employees = null;
		public ICollectionView Employees
		{
			get
			{
				if (this.employees == null)
				{
					ObservableCollection<Person> newEmployees = new ObservableCollection<Person>();
					newEmployees.Add(new Person(new DateTime(2005, 12, 4), "Sarah", "Blake", Person.OccupationPositions.SuppliesManager, "(555) 943-231", 3500, 1));
					newEmployees.Add(new Person(new DateTime(2008, 3, 21), "Jane", "Simpson", Person.OccupationPositions.Security, "(555) 912-482", 2000, 1));
					newEmployees.Add(new Person(new DateTime(2005, 12, 4), "John", "Peterson", Person.OccupationPositions.Consultant, "(555) 543-231", 2600, 3));
					newEmployees.Add(new Person(new DateTime(2005, 12, 4), "Peter", "Bush", Person.OccupationPositions.Casheer, "(555) 943-221", 2300, 2));

					this.employees = new QueryableCollectionView(newEmployees);
				}
				return this.employees;
			}
		}

		private Person employee = null;
		public Person Employee
		{ 
			get
			{
				if(employee == null)
				{
					employee = new Person(new DateTime(2005, 12, 4), "Sarah", "Blake", Person.OccupationPositions.SuppliesManager, "(555) 943-231", 3500, 1);
				}
				return employee;
			}
		}

	}
}