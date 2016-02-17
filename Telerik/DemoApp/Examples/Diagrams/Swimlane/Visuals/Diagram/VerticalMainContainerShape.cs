using System.Windows.Controls;
using Telerik.Windows.Examples.Diagrams.Swimlane.Base;

namespace Telerik.Windows.Examples.Diagrams.Swimlane
{
    public class VerticalMainContainerShape : MainContainerShapeBase
    {
        public VerticalMainContainerShape()
        {
            this.ChildrenPositioning = Orientation.Horizontal;
            this.Orientation = Orientation.Vertical;
        }
    }
}
