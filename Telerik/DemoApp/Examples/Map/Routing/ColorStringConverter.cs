using System;
using System.Globalization;
using System.Net;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Ink;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Animation;
using System.Windows.Shapes;

namespace Telerik.Windows.Examples.Map
{
	/// <summary>
	/// Convert string to color and vice versa
	/// </summary>
	public class ColorStringConverter : IValueConverter
	{
		#region IValueConverter Members

		/// <summary>
		/// Converts a value. 
		/// </summary>
		/// <param name="value">The value produced by the binding source.</param>
		/// <param name="targetType">The type of the binding target property.</param>
		/// <param name="parameter">The converter parameter to use.</param>
		/// <param name="culture">The culture to use in the converter.</param>
		/// <returns>A converted value. If the method returns null reference (Nothing in Visual Basic), the valid null value is used.</returns>
		public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
		{
			if (value is SolidColorBrush)
			{
				SolidColorBrush brush = value as SolidColorBrush;
				Color color = brush.Color;

				return SolidBrushItemsSource.GetName(color);
			}
			else
			{
				return null;
			}
		}

		/// <summary>
		/// Converts a value. 
		/// </summary>
		/// <param name="value">The value that is produced by the binding target.</param>
		/// <param name="targetType">The type to convert to.</param>
		/// <param name="parameter">The converter parameter to use.</param>
		/// <param name="culture">The culture to use in the converter.</param>
		/// <returns>A converted value. If the method returns nullNothingnullptra null reference (Nothing in Visual Basic), the valid null value is used.</returns>
		public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
		{
			if (value is string)
			{
				string colorString = value as string;

				return new SolidColorBrush(SolidBrushItemsSource.GetColor(colorString));
			}
			else
			{
				return null;
			}
		}

		#endregion
	}
}
