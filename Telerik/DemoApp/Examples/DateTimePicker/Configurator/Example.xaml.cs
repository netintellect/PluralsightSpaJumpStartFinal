using System;
using Telerik.Windows.Controls;
using Telerik.Windows.Controls.Calendar;

namespace Telerik.Windows.Examples.DateTimePicker.Configurator
{		 	
	public partial class Example
	{
		public Example()
		{
			InitializeComponent();
			this.DisplayFormat.ItemsSource = this.GetEnumItemsSource(typeof(DateTimePickerFormat));
			this.InputMode.ItemsSource = this.GetEnumItemsSource(typeof(InputMode));
			this.DateSelectionMode.ItemsSource = this.GetEnumItemsSource(typeof(DateSelectionMode));
        }

        private EnumDataSource GetEnumItemsSource(Type enumType)
        {
            EnumDataSource source = new EnumDataSource();
            source.EnumType = enumType;
            return source;
        }
	}
}
