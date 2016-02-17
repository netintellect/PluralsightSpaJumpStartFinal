using System;
using System.Collections.Generic;
#if !WPF
using Telerik.Windows.Controls;
#else
using System.Windows.Controls;
#endif
using Telerik.Windows.Examples.PropertyGrid.SampleData;

namespace Telerik.Windows.Examples.PropertyGrid.Selection
{
	public class MyViewModel : Telerik.Windows.Controls.ViewModelBase
	{
		IEnumerable<SelectionMode> modes;

		public IEnumerable<SelectionMode> Modes
		{
			get
			{
				if (modes == null)
				{
					modes = new List<SelectionMode>()
					{ 
						SelectionMode.Single,
						SelectionMode.Multiple, 
						SelectionMode.Extended 
					};
				}

				return modes;
			}
		}

		private Order currentOrder;
		public Order CurrentOrder
		{
			get 
			{
				if (this.currentOrder == null)
				{
					this.currentOrder = this.GeneratedItem();
				}
				return this.currentOrder; 
			}
		}

		private Order GeneratedItem()
		{
			var order = new Order()
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

			return order;
		}
	}
}
