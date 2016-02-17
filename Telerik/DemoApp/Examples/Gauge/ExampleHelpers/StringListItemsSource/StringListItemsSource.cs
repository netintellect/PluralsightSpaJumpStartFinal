using System;
using System.Collections;
using System.Collections.Generic;
using System.Globalization;
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
using Telerik.Windows.Controls.Gauge;

namespace Telerik.Examples.Gauge
{
	/// <summary>
	/// Create data source from the number template lists
	/// </summary>
	public class StringListItemsSource : IEnumerable, IValueConverter
	{
		private Dictionary<string, string> items = new Dictionary<string, string>();
		private Dictionary<string, string> names = new Dictionary<string, string>();

		/// <summary>
		/// Creates instance of the class
		/// </summary>
		public StringListItemsSource()
		{
		}

		/// <summary>
		/// Add new item to the source
		/// </summary>
		/// <param name="name"></param>
		/// <param name="template"></param>
		public void Add(string name, string template)
		{
			items[name] = template;
			names[template] = name;
		}

		#region IEnumerable Members

		public IEnumerator GetEnumerator()
		{
			return items.Keys.GetEnumerator();
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
			string template = value as string;
			if (template != null && names.ContainsKey(template))
			{
				return names[template];
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
			string itemString = value as string;

			if (!string.IsNullOrEmpty(itemString) && items.ContainsKey(itemString))
			{
				return items[itemString];
			}
			else
			{
				return null;
			}
		}

		#endregion
	}
}
