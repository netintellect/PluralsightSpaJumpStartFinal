using System;
using System.Windows;
using System.Windows.Controls;
using Telerik.Windows.Controls;
using Telerik.Windows.Examples.TabControl.Databinding.ViewModel;

namespace Telerik.Windows.Examples.TabControl.Databinding
{
	public partial class Example : System.Windows.Controls.UserControl
	{
		public Example()
		{
			InitializeComponent();

			this.DataContext = new MainViewModel();
		}
	}
}

