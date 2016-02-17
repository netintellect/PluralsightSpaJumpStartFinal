using System.Windows.Controls;

namespace Telerik.Windows.Examples.DataForm.FirstLook
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