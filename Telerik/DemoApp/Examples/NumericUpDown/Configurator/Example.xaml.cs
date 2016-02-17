using System;
using System.Windows.Controls;
using Telerik.Windows.Controls;

namespace Telerik.Windows.Examples.NumericUpDown.Configurator
{
	public partial class Example : UserControl
	{
		public Example()
		{
			InitializeComponent();

			this.ValueFormat.ItemsSource = this.GetEnumItemsSource(typeof(ValueFormat));
		}

		private EnumDataSource GetEnumItemsSource(Type enumType)
		{
			EnumDataSource source = new EnumDataSource();
			source.EnumType = enumType;
			return source;
		}
	}
}