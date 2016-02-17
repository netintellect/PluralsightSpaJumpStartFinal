using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using Telerik.Windows.Controls;
using Telerik.Windows.Examples.Diagrams.OrgChart.ViewModel;

namespace Telerik.Windows.Examples.Diagrams.OrgChart.Converters
{
    public class TreeViewItemTemplateSelector : DataTemplateSelector
    {
        public DataTemplate TeamTemplate { get; set; }
        public DataTemplate MemberTemplate { get; set; }

        public override DataTemplate SelectTemplate(object item, DependencyObject container)
        {
            if (item is OrgTeamViewModel)
            {
                return this.TeamTemplate;
            }
            else if (item is OrgTeamMemberViewModel)
            {
                return this.MemberTemplate;
            }
            return base.SelectTemplate(item, container);
        }
    }
}
