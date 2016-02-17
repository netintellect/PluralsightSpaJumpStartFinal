using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using Telerik.Windows.Controls.Data.PropertyGrid;

namespace Telerik.Windows.Examples.PropertyGrid.GroupStyleSelector
{
	public class ConditionalStyleSelector : StyleSelector
	{
		public override Style SelectStyle(object item, DependencyObject container)
		{
			GroupDefinition group = item as GroupDefinition;
			var displayName = group.DisplayName;

			if (displayName.Contains("Work") || displayName.Contains("Job"))
			{
				return WorkStyle;
			}

			return null;
		}

		public Style WorkStyle { get; set; }
	}
}
