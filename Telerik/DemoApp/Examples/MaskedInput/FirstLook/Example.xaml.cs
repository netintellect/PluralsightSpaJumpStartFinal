using System;
namespace Telerik.Windows.Examples.MaskedInput.FirstLook
{
	public partial class Example : System.Windows.Controls.UserControl
	{
		public Example()
		{
			InitializeComponent();
			this.DataContext = new PersonViewModel();
		}       
	}
}
