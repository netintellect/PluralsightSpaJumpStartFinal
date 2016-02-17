using System;
using System.Collections;
using System.Linq;
using System.Reflection;
using System.Windows.Input;
using Telerik.Windows.Controls;
using Telerik.Windows.Controls.MaskedInput;
using System.Globalization;
using System.Collections.Generic;

namespace Telerik.Windows.Examples.MaskedInput.MaskedCurrencyInput
{
	public partial class Example : System.Windows.Controls.UserControl
	{
		public Example()
		{
			InitializeComponent();

            this.TextMode.ItemsSource = HelperClass.GetEnumNames(typeof(TextMode));
            this.InputBehavior.ItemsSource = HelperClass.GetEnumNames(typeof(InputBehavior));
            this.SpinMode.ItemsSource = HelperClass.GetEnumNames(typeof(SpinMode));
            this.SelectionOnFocus.ItemsSource = HelperClass.GetEnumNames(typeof(SelectionOnFocus));
            this.Culture.ItemsSource = HelperClass.GetCultures();
            this.UpdateValueEvent.ItemsSource = HelperClass.GetEnumNames(typeof(UpdateValueEvent));
		}
	}
}
