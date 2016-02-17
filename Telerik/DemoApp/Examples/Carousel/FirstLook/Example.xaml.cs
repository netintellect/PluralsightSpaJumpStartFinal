using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Controls;

namespace Telerik.Windows.Examples.Carousel.FirstLook
{
	/// <summary>
	/// Interaction logic for Example.xaml
	/// </summary>
	public partial class Example : UserControl
	{
		public Example()
		{
			InitializeComponent();

            this.DataContext = new Northwind();
		}
	}
}