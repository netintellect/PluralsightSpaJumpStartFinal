using System.Windows.Controls;

namespace Telerik.Windows.Examples.DataForm.ICollectionViewSynchronization
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