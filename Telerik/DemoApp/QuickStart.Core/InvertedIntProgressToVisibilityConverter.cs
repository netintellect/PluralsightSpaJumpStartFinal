using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Data;
using System.Windows;

namespace Telerik.Windows.QuickStart
{
	public class InvertedIntProgressToVisibilityConverter : IValueConverter
	{
		public object Convert(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
		{
			if (value is int)
			{
				return (int)value == 100 ? Visibility.Visible : Visibility.Collapsed;
			}
			else if (value != null)
			{
				int v = 0;
				if (int.TryParse(value.ToString(), out v))
				{
					return v == 100 ? Visibility.Visible : Visibility.Collapsed;
				}
			}
			return Visibility.Visible;
		}

		public object ConvertBack(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
		{
			throw new NotImplementedException();
		}
	}
}
