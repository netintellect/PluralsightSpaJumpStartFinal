using System;
using System.ComponentModel;
using System.Collections.ObjectModel;
using Telerik.Windows.Data;

namespace Telerik.Windows.Examples.Calculator.SampleDataSource
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
                    ObservableCollection<Employee> newEmployees = new ObservableCollection<Employee>();
                    newEmployees.Add(new Employee(new DateTime(2005, 12, 4), "Sarah", "Blake", Employee.OccupationPositions.SuppliesManager, "(555) 943-231", 4500));
                    newEmployees.Add(new Employee(new DateTime(2008, 3, 21), "Jane", "Simpson", Employee.OccupationPositions.Security, "(555) 912-482", 2000));
                    newEmployees.Add(new Employee(new DateTime(2005, 12, 4), "John", "Peterson", Employee.OccupationPositions.Consultant, "(555) 543-231", 3600));
                    newEmployees.Add(new Employee(new DateTime(2005, 12, 4), "Peter", "Bush", Employee.OccupationPositions.Casheer, "(555) 943-221", 2300));
					newEmployees.Add(new Employee(new DateTime(2005, 12, 4), "Michael", "King", Employee.OccupationPositions.StaffManager, "(71) 555-5598", 4000));
					newEmployees.Add(new Employee(new DateTime(2005, 12, 4), "Laura", "Callahan", Employee.OccupationPositions.Casheer, "(555) 555-1189", 3300));
					newEmployees.Add(new Employee(new DateTime(2005, 12, 4), "Anne", "Dodsworth", Employee.OccupationPositions.SuppliesManager, "(71) 555-4444", 4500));
					newEmployees.Add(new Employee(new DateTime(2005, 12, 4), "Janet", "Leverling", Employee.OccupationPositions.Casheer, "(206) 406-3412", 3000));
					newEmployees.Add(new Employee(new DateTime(2005, 12, 4), "Margaret", "Peacock", Employee.OccupationPositions.StaffManager, "(206) 555-8122", 6000));
					newEmployees.Add(new Employee(new DateTime(2005, 12, 4), "Steven", "Buchanan", Employee.OccupationPositions.Supplies, "(71) 555-4848", 4000));
					newEmployees.Add(new Employee(new DateTime(2005, 12, 4), "Andrew", "Fuller", Employee.OccupationPositions.Consultant, "(206) 555-9482", 3500));

                    this.employees = new QueryableCollectionView(newEmployees);
                }
                return this.employees;
            }
        }
    }
}
