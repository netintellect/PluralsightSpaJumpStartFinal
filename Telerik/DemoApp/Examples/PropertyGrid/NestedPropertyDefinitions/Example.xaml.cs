using System;
using System.Linq;
using System.Windows.Controls;
using Telerik.Windows.Examples.PropertyGrid.SampleData;
using System.Windows.Data;
using System.Windows;

namespace Telerik.Windows.Examples.PropertyGrid.NestedPropertyDefinitions
{
    public partial class Example : UserControl
    {
        public Example()
        {
            InitializeComponent();
			
            DataContext = new Order()
            {
                OrderDate = new DateTime(1996, 7, 5),
                ShippedDate = new DateTime(1996, 8, 16),
                ShipAddress = "Luisenstr. 48",
                ShipCountry = "Germany",
                ShipName = "Toms Spezialitäten",
                ShipPostalCode = "44087",
                Employee = new Employee()
                {
                    FirstName = "Nancy",
                    LastName = "Davolio",
                    Title = "Sales Representative",
                    HomePhone = "(206) 555-9857",
                    Department = new Department() 
                    { 
                        Country = "USA",
                        ID = 1
                    }
                }
            };
        }
    }
}
