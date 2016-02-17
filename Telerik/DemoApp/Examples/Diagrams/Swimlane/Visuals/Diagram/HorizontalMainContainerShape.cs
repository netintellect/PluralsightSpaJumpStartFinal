using System.Windows.Controls;
using Telerik.Windows.Examples.Diagrams.Swimlane.Base;

namespace Telerik.Windows.Examples.Diagrams.Swimlane
{
    public class HorizontalMainContainerShape : MainContainerShapeBase
    {
        public HorizontalMainContainerShape()
        {
            this.ChildrenPositioning = Orientation.Vertical;
            this.Orientation = Orientation.Horizontal;
        }
    }
}
