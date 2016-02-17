using System.Windows;
using System.Windows.Controls;
using Telerik.Windows.Controls;
using System.Globalization;

namespace Telerik.Windows.Examples.NumericUpDown.FirstLook
{
	public partial class Example : UserControl
	{
		public Example()
		{
			InitializeComponent();
			this.eurNumeric.NumberFormatInfo = new NumberFormatInfo();
			this.eurNumeric.NumberFormatInfo.CurrencySymbol = @"ˆ";
			this.usdNumeric.NumberFormatInfo = new NumberFormatInfo();
			this.usdNumeric.NumberFormatInfo.CurrencySymbol = @"$";
		}
	}
}