using System;
using System.Windows;
#if !WPF
using Telerik.Windows.Controls;
#else
using System.Windows.Controls;
#endif

namespace Telerik.Windows.Examples.TreeView.FirstLook
{
	public class MasterDetailTemplateSelector : DataTemplateSelector
	{
		public DataTemplate OfficeTemplate { get; set; }

		public DataTemplate EmployeeTemplate { get; set; }

		public override DataTemplate SelectTemplate(object item, DependencyObject container)
		{
			Office company = item as Office;
			if (company != null)
			{
				return this.OfficeTemplate;
			}

			Employee employee = item as Employee;
			if (employee != null)
			{
				return this.EmployeeTemplate;
			}

			return base.SelectTemplate(item, container);
		}
	}
}
