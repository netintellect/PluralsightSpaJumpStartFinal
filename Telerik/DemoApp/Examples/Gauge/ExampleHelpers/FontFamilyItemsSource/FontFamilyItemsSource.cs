using System;
using System.Collections;
using System.Globalization;
using System.Net;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Media;

namespace Telerik.Examples.Gauge
{
	/// <summary>
	/// Items source that represents font family name
	/// </summary>
	public class FontFamilyItemsSource : IEnumerable, IValueConverter
	{
		private static string[] fontFamilyNameList = new string[]
			{
				"Segoe UI Semibold",
				"Segoe UI",
				"Arial",
				"Courier",
				"Times New Roman",
				"Tahoma",
				"Verdana"
			};

		/// <summary>
		/// Static class constructor
		/// </summary>
		static FontFamilyItemsSource()
		{
		}

		/// <summary>
		/// Creates instance of the class
		/// </summary>
		public FontFamilyItemsSource()
		{
		}

		#region IEnumerable Members

		/// <summary>
		/// Gets enumerator
		/// </summary>
		/// <returns></returns>
		public IEnumerator GetEnumerator()
		{
			return fontFamilyNameList.GetEnumerator();
		}

		#endregion

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
			if (value is string)
			{
				string fontName = value as string;

				try
				{
					return new FontFamily(fontName);
				}
				catch
				{
					return null;
				}
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
			FontFamily fontFamily = value as FontFamily;
			if (fontFamily != null)
			{
				return fontFamily.Source;
			}
			else
			{
				return null;
			}
		}

		#endregion
	}
}
