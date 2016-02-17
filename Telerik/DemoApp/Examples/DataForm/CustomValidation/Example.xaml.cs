using System.Windows.Controls;
using Telerik.Windows.Controls;
using Telerik.Windows.Controls.Data.DataForm;
using System.Windows.Data;
using System.Windows;

namespace Telerik.Windows.Examples.DataForm.CustomValidation
{
	public partial class Example : UserControl
	{
		public Example()
		{
			InitializeComponent();
            DataContext = new CustomValidationEmployeeDataContext();
		}
	}
}