using System;
using System.Linq;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;

namespace Telerik.Windows.Examples.Diagrams.OrgChart.CustomControls
{
    public class OrgChartTeamItemsControl : ListBox
    {         
#if WPF
        static OrgChartTeamItemsControl()
        {
            DefaultStyleKeyProperty.OverrideMetadata(typeof(OrgChartTeamItemsControl), new FrameworkPropertyMetadata(typeof(OrgChartTeamItemsControl)));
        }
#endif

        protected override bool IsItemItsOwnContainerOverride(object item)
        {
            return item is OrgChartTeamMember;
        }

        protected override System.Windows.DependencyObject GetContainerForItemOverride()
        {
            return new OrgChartTeamMember();
        }
    }
}
