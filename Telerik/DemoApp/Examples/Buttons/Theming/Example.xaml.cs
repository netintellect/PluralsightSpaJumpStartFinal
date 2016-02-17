using System;
using System.Windows.Controls;

namespace Telerik.Windows.Examples.Buttons.Theming
{
	public partial class Example : UserControl
	{
		public Example()
		{
			InitializeComponent();
		}
		private void OnOptionChange(object sender, System.Windows.Input.MouseButtonEventArgs e)
		{
			this.DropDownOption.IsOpen = false;
			this.SplitButtonOption.IsOpen = false;
		}
	}
}
