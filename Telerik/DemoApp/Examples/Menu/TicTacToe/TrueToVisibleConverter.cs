using System;
using System.Net;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Documents;
using System.Windows.Ink;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Animation;
using System.Windows.Shapes;
using System.Windows.Data;

namespace Telerik.Windows.Examples.Menu.TicTacToe
{
	public class TrueToVisibleConverter : IValueConverter
	{
		public object Convert(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
		{
			if (value is bool)
			{
				return (bool)value ? Visibility.Visible : Visibility.Collapsed;
			}
			throw new NotImplementedException();
		}

		public object ConvertBack(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
		{
			if (value is Visibility)
			{
				return (Visibility)value == Visibility.Visible;
			}
			throw new NotImplementedException();
		}
	}
}
