using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Data;
using System.Windows;

namespace Telerik.Windows.QuickStart
{
	public class ThemingToVisibleConverter : IValueConverter
	{
		public object Convert(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
		{
			if (value is Enums.ExampleType)
			{
				Enums.ExampleType viewMode = (Enums.ExampleType)value;
				return viewMode == Enums.ExampleType.Theming ? Visibility.Visible : Visibility.Collapsed;
			}
			return Visibility.Collapsed;
		}
		public object ConvertBack(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
		{
			throw new NotImplementedException();
		}
	}
}
