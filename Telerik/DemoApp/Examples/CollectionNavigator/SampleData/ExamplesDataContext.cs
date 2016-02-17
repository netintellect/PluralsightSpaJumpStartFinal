using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;

namespace Telerik.Windows.Examples
{
    public class ExamplesDataContext
    {
        Northwind _Northwind;
        public Northwind Northwind
        {
            get
            {
                if (_Northwind == null)
                {
                    _Northwind = new Northwind();
                }

                return _Northwind;
            }
        }

        IEnumerable<Employees> employees;
        public IEnumerable<Employees> Employees
        {
            get
            {
                if (employees == null)
                {
                    employees = Northwind.EmployeesCollection;
                }

                return employees;
            }
        }
    }
}
