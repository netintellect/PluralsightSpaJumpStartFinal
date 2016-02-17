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

namespace Telerik.Windows.Examples.PropertyGrid.SampleData
{
    public class Employee
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Title { get; set; }
        public string HomePhone { get; set; }
        public Department Department { get; set; }
    }

    public class Order
    {
        public string ShipAddress { get; set; }
        public string ShipName { get; set; }
        public string ShipPostalCode { get; set; }
        public string ShipCountry { get; set; }
        public DateTime OrderDate { get; set; }
        public DateTime ShippedDate { get; set; }
        public Employee Employee { get; set; }
    }

    public class Department
    {
        public int ID { get; set; }
        public string Country { get; set; }
    }
}
