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
using System.Collections.Generic;

namespace Telerik.Windows.Examples.PropertyGrid.CollectionEditor
{
	public class Utilities
	{
		private static List<Order> GenerateOrders()
		{
			var orders = new List<Order>()
			{
				new Order() { OrderDate = new DateTime(1996, 7, 5), ShippedDate = new DateTime(1996, 8, 16), ShipAddress = "Luisenstr. 48", ShipCountry = "Germany",ShipName = "Toms Spezialitäten", ShipPostalCode = "44087"},
				new Order() { OrderDate = new DateTime(1996-07-16), ShippedDate = new DateTime(1996-07-18), ShipAddress = "59 rue de l'Abbaye", ShipCountry = "France",ShipName = "Vins et alcools Chevalier", ShipPostalCode = "51100"},
				new Order() { OrderDate = new DateTime(1996, 07, 12), ShippedDate = new DateTime(1996, 07, 15), ShipAddress = "Starenweg 5", ShipCountry = "Switzerland",ShipName = "Richter Supermarkt", ShipPostalCode = "1204"},
				new Order() { OrderDate = new DateTime(1996, 07, 18), ShippedDate = new DateTime(1996, 08, 15), ShipAddress = "Sierras de Granada 9993", ShipCountry = "Mexico",ShipName = "Centro comercial Moctezuma", ShipPostalCode = "05022"},				        
			};

			return orders;
		}

		public static Customer GenerateCustomer()
		{
			var customer = new Customer()
			{
				CustomerID = "CACTU",
				CompanyName = "Cactus Comidas para llevar",
				ContactName = "Patricio Simpson",
				ContactTitle = "Sales Agent",
				Address = "Cerrito 333",
				City = "Buenos Aires",
				Country = "Argentina",
				Phone = "(1) 135-5555"
			};

			var orders = Utilities.GenerateOrders();
			customer.Orders.AddRange(orders);

			return customer;
		}
	}
}
