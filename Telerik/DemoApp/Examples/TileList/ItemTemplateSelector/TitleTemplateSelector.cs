using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using Telerik.Windows.Controls;

namespace Telerik.Windows.Examples.TileList.ItemTemplateSelector
{
    public class TitleTemplateSelector : DataTemplateSelector
    {
        public override System.Windows.DataTemplate SelectTemplate(object item, System.Windows.DependencyObject container)
        {
            var employee = item as Employee;
            if (employee.Title.Contains("Manager") || employee.Title.Contains("President"))
            {
                return this.ManagerTemplate;
            }
            return this.RepresentativeTemplate;
        }
        public DataTemplate ManagerTemplate { get; set; }
        public DataTemplate RepresentativeTemplate { get; set; }
    }
}
