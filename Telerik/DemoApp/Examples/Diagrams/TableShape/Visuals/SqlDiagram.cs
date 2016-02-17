using System;
using System.Linq;
using Telerik.Windows.Controls;
using Telerik.Windows.Controls.Diagrams;

namespace Telerik.Windows.Examples.Diagrams.TableShape
{
    public class SqlDiagram : RadDiagram
    {
        protected override Windows.Diagrams.Core.IContainerShape GetShapeContainerForItemOverride(Windows.Diagrams.Core.IContainerItem item)
        {
            return new TableShape();
        }

        protected override Windows.Diagrams.Core.IShape GetShapeContainerForItemOverride(object item)
        {
            return new RowShape();
        }

        protected override bool IsItemItsOwnShapeContainerOverride(object item)
        {
            return item is RadDiagramShapeBase;
        }

        public override void Paste()
        {
            var selectedContainer = this.ContainerGenerator.ContainerFromItem(this.SelectedItem) as TableShape;
            if (selectedContainer != null)
                base.Paste();
        }
    }
}
