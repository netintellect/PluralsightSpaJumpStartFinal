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
using System.Collections.Generic;
using System.Linq;
using System.Reflection;

namespace Telerik.Windows.Examples.Book.Paging
{
    /// <summary>
    /// Helper method for enum types
    /// </summary>
    public static class EnumHelper
    {
        /// <summary>
        /// Gets all enum values.
        /// </summary>
        /// <param name="enumType">Type of the enum.</param>
        /// <returns>String array of all enum values</returns>
        public static string[] GetValuesAsString(Type enumType)
        {
            object[] values = EnumHelper.GetValues(enumType);
            List<string> valuesAsString = new List<string>();

            foreach (object value in values)
                valuesAsString.Add(value.ToString());

            return valuesAsString.ToArray();
        }

        /// <summary>
        /// Gets all enum values.
        /// </summary>
        /// <param name="enumType">Type of the enum.</param>
        /// <returns>Object array of all enum values</returns>
        public static object[] GetValues(Type enumType)
        {
            List<object> values = new List<object>();

            IEnumerable<FieldInfo> fields = from field in enumType.GetFields()
                                            where field.IsLiteral
                                            select field;

            foreach (FieldInfo field in fields)
            {
                object value = field.GetValue(enumType);
                values.Add(value);
            }

            return values.ToArray();
        }
    }
}
