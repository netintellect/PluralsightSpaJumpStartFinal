using System.Windows.Controls;

namespace Telerik.Windows.Examples.DataForm.DeclaringDataFields
{
	public partial class Example : UserControl
	{
		public Example()
		{
			InitializeComponent();

            DataContext = new EmployeeDataContext();
		}
	}
}