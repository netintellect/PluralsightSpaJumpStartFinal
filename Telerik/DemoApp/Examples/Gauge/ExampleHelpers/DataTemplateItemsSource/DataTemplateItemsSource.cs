using System;
using System.Collections.Generic;
using System.Net;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Documents;
using System.Windows.Ink;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Animation;
using System.Windows.Shapes;
using System.Collections;
using System.Windows.Data;
using System.Globalization;

namespace Telerik.Examples.Gauge
{
	/// <summary>
	/// Create data source from the data templates
	/// </summary>
	public class DataTemplateItemsSource : IEnumerable, IValueConverter
	{
		private Dictionary<string, DataTemplate> items = new Dictionary<string, DataTemplate>();
		private Dictionary<DataTemplate, string> names = new Dictionary<DataTemplate, string>();

		/// <summary>
		/// Creates instance of the class
		/// </summary>
		public DataTemplateItemsSource()
		{
		}

		/// <summary>
		/// Add new item to the source
		/// </summary>
		/// <param name="name"></param>
		/// <param name="template"></param>
		public void Add(string name, DataTemplate template)
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
			DataTemplate template = value as DataTemplate;
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
