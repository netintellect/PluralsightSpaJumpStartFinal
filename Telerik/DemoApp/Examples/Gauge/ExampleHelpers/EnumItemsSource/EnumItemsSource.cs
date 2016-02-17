using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Reflection;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Ink;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Animation;
using System.Windows.Shapes;
using Telerik.Windows;
using System.Globalization;

#if WPF
using PropertyMetadata = System.Windows.PropertyMetadata;
#endif

#if SILVERLIGHT
using PropertyMetadata = Telerik.Windows.PropertyMetadata;
#endif

namespace Telerik.Examples.Gauge
{
	/// <summary>
	/// Create items source from enumeration
	/// </summary>
	public class EnumItemsSource : DependencyObject, IEnumerable, IValueConverter
	{
		private List<string> enumList = new List<string>();
		private Type enumType;

		/// <summary>
		/// Identifies the TypeName dependency property. 
		/// </summary>
		public static readonly DependencyProperty TypeNameProperty = DependencyPropertyExtensions.Register(
			"TypeName",
			typeof(string),
			typeof(EnumItemsSource),
			new PropertyMetadata(
				new PropertyChangedCallback(TypeNameChangedHandler)));

		public delegate bool ItemValidatorDelegate(object value);

		private ItemValidatorDelegate validator = null;

		public EnumItemsSource()
		{
		}

		public EnumItemsSource(ItemValidatorDelegate itemValidator)
			: this()
		{
			this.validator = itemValidator;
		}

		/// <summary>
		/// Gets or sets name of the enum
		/// </summary>
		public string TypeName
		{
			get { return (string)GetValue(TypeNameProperty); }
			set { SetValue(TypeNameProperty, value); }
		}

		/// <summary>
		/// TypeName property changed callback 
		/// </summary>
		/// <param name="source"></param>
		/// <param name="eventArgs"></param>
		protected static void TypeNameChangedHandler(DependencyObject source,
			DependencyPropertyChangedEventArgs eventArgs)
		{
			EnumItemsSource itemsSource = source as EnumItemsSource;
			if (source != null)
			{
				itemsSource.RefreshEnumList();
			}
		}

		private void RefreshEnumList()
		{
			enumList.Clear();

			enumType = Type.GetType(this.TypeName);
			if (enumType != null)
			{
				if (!enumType.IsEnum)
				{
					throw new ArgumentException("Type '" + enumType.Name + "' is not an enum");
				}

				IEnumerable<FieldInfo> fields = from field in enumType.GetFields()
							 where field.IsLiteral
							 select field;

				foreach (FieldInfo field in fields)
				{
					object value = field.GetValue(enumType);
					if (this.validator == null || this.validator(value))
					{
						enumList.Add(value.ToString());
					}
				}
			}
		}

		#region IEnumerable Members

		/// <summary>
		/// Gets enumerator
		/// </summary>
		/// <returns></returns>
		public IEnumerator GetEnumerator()
		{
			return enumList.GetEnumerator();
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
			if (enumType != null && value is string)
			{
				string enumString = value as string;

				try
				{
					return Enum.Parse(enumType, enumString, false);
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
			if (enumType != null && enumType.IsInstanceOfType(value))
			{
				return value.ToString();
			}
			else
			{
				return null;
			}
		}

		#endregion
	}
}
