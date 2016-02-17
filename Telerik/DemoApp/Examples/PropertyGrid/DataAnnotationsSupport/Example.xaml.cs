using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace Telerik.Windows.Examples.PropertyGrid.DataAnnotationsSupport
{
	/// <summary>
	/// Interaction logic for Example.xaml
	/// </summary>
	public partial class Example : UserControl
	{
		public Example()
		{
			InitializeComponent();
		
			this.propertyGrid1.Item = new Employee()
									{
										FirstName = "Sarah",
										LastName = "Blake",
										PhoneNum = "(555) 943-231",
										Occupation = "Supplies Manager",
										DepartmentId = 1,
										Salary = 3500,
										StartingDate = new DateTime(2005, 12, 4)
									};
		}
	}
}
