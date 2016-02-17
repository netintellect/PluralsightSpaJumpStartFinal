using System;
using System.Windows;
using System.Windows.Input;
using System.Windows.Media.Animation;
using System.Collections;
using System.ComponentModel;
using System.Linq;
using System.Windows.Threading;
using Telerik.Windows.Controls;

namespace Telerik.Windows.Examples.Book.Paging
{
	public partial class Example : System.Windows.Controls.UserControl
	{
		public Example()
		{
			InitializeComponent();
			this.book1.ItemsSource = Enumerable.Range(0, 26);
			this.displayModeCombo.ItemsSource = EnumHelper.GetValues(typeof(PagerDisplayModes));
			this.autoEllipsisModeCombo.ItemsSource = EnumHelper.GetValues(typeof(AutoEllipsisModes));
		}
	}
}