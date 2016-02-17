using System;
using System.Linq;

namespace Telerik.Windows.Examples.PropertyGrid.GroupStyleSelector
{
	public partial class Example
	{
		public Example()
		{
			InitializeComponent();

			this.propertyGrid1.Item = new Employee()
			{
				FirstName = "Nancy",
				LastName = "Davolio",
				PhoneNum = "(555) 943-231",
				WorkPhoneNum = "(555) 21-11-334",
				Occupation = "Supplies Manager",
				DepartmentId = 1,
				Salary = 3500,
				StartingDate = new DateTime(2015, 12, 4),
				Age = 23,
				Email = "n.davolio@example.com",
				WorkEmail = "nancy.davolio@company.com",
				Facebook = "facebook.com/NancyDavolio",
				Gender = "Female"
			};
		}
	}
}
