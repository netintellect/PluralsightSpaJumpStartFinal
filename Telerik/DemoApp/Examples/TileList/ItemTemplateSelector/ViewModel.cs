using System;
using System.Collections;
using System.Collections.Generic;
using System.Net;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Documents;
using System.Windows.Ink;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Animation;
using System.Windows.Shapes;
using Telerik.Windows.Controls;
using Telerik.Windows.Data;

namespace Telerik.Windows.Examples.TileList.ItemTemplateSelector
{
    public class ViewModel
    {
        Northwind northwind;
        public Northwind Northwind
        {
            get
            {
                if (northwind == null)
                {
                    northwind = new Northwind();
                }

                return northwind;
            }
        }

        IEnumerable<Employee> employees;
        public IEnumerable<Employee> Employees
        {
            get
            {
                if (employees == null)
                {
                    employees = this.Northwind.EmployeesCollection;
                }

                return employees;
            }
        }
    }
}
