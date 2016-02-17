using System;
using System.ComponentModel;
using Telerik.Windows.Data;
using System.Collections.ObjectModel;

namespace Telerik.Windows.Examples.DataForm
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
					newEmployees.Add(new Person(new DateTime(2005, 12, 4), "Sarah", "Blake", Person.OccupationPositions.SuppliesManager, "(555) 943-231", 3500));
					newEmployees.Add(new Person(new DateTime(2008, 3, 21), "Jane", "Simpson", Person.OccupationPositions.Security, "(555) 912-482", 2000));
					newEmployees.Add(new Person(new DateTime(2005, 12, 4), "John", "Peterson", Person.OccupationPositions.Consultant, "(555) 543-231", 2600));
					newEmployees.Add(new Person(new DateTime(2005, 12, 4), "Peter", "Bush", Person.OccupationPositions.Casheer, "(555) 943-221", 2300));

                    this.employees = new QueryableCollectionView(newEmployees);
                }
				return this.employees;
            }
        }
    }
}
