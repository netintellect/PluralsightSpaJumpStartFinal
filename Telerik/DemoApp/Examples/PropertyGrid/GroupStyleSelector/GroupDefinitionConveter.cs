using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Data;
using Telerik.Windows.Controls.Data.PropertyGrid;

namespace Telerik.Windows.Examples.PropertyGrid.GroupStyleSelector
{
	public class GroupDefinitionConverter : IValueConverter
	{
		#region IValueConverter Members

		public object Convert(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
		{
			GroupDefinition group = value as GroupDefinition;

			if (group != null)
			{
				return Int32.Parse(group.DisplayName) % 5 == 0 ? true : false;
			}
			return null;
		}

		public object ConvertBack(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
		{
			throw new NotImplementedException();
		}

		#endregion
	}
}
