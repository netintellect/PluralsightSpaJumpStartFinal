using System;
using System.Net;
using System.Text.RegularExpressions;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Documents;
using System.Windows.Ink;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Animation;
using System.Windows.Shapes;
using System.Windows.Data;
using System.Globalization;

namespace Telerik.Examples.Gauge
{
	/// <summary>
	/// Converts string to double and vice versa
	/// </summary>
	public class DoubleStringConverter : IValueConverter
	{
		/// <summary>
		/// Regular expression that represents numeric in the current culture format
		/// </summary>
		public static readonly Regex NumericTemplate = new Regex("^\\-*\\d+[\\" + NumberFormatInfo.CurrentInfo.CurrencyDecimalSeparator + "]{0,1}\\d*$");
		/// <summary>
		/// Regular expression that represents numeric in the US culture format
		/// </summary>
		public static readonly Regex USNumericTemplate = new Regex("^\\-*\\d+[\\" + (new CultureInfo("en-US")).NumberFormat.CurrencyDecimalSeparator + "]{0,1}\\d*$");

		/// <summary>
		/// Indicates whether the specified string is number
		/// </summary>
		/// <param name="asStr">String that will be veryfied.</param>
		/// <returns></returns>
		public static bool IsNumeric(string numericString)
		{
			bool isNumeric = IsNumeric(numericString, DoubleStringConverter.NumericTemplate);
			if (!isNumeric)
			{
				isNumeric = IsNumeric(numericString, DoubleStringConverter.USNumericTemplate);
			}

			return isNumeric;
		}

		/// <summary>
		/// Indicates whether the specified string is number according to the given regular expression
		/// </summary>
		/// <param name="asStr">String that will be veryfied.</param>
		/// <param name="aoNumericTemplate">Regular expression</param>
		/// <returns></returns>
		public static bool IsNumeric(string numericString, Regex numericTemplate)
		{
			if (string.IsNullOrEmpty(numericString))
			{
				return false;
			}
			try
			{
				if (numericTemplate.Match(numericString).Success)
				{
					return true;
				}

				return false;
			}
			catch
			{
				return false;
			}
		}

		/// <summary>
		/// Converts string to double
		/// </summary>
		/// <param name="numericString"></param>
		/// <param name="defaultValue"></param>
		/// <returns></returns>
		public static double? GetDouble(string numericString, double? defaultValue)
		{
			if (IsNumeric(numericString, DoubleStringConverter.NumericTemplate))
			{
				try
				{
					return double.Parse(numericString);
				}
				catch (Exception)
				{
					return defaultValue;
				}
			}
			else if (IsNumeric(numericString, DoubleStringConverter.USNumericTemplate))
			{
				try
				{
					return double.Parse(numericString, new CultureInfo("en-US"));
				}
				catch (Exception)
				{
					return defaultValue;
				}
			}

			return defaultValue;
		}


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
				string numericString = value as string;

				return GetDouble(numericString, null);
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
			if (value is double)
			{
				string formatString = parameter as string;
				if (!string.IsNullOrEmpty(formatString))
				{
					return string.Format(culture, formatString, value);
				}
				else
				{
					return ((double)value).ToString(new CultureInfo("en-US"));
				}
			}
			else
			{
				return null;
			}
		}

		#endregion
	}
}
