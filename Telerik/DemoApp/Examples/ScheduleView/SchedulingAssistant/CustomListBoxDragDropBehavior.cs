using Telerik.Windows.DragDrop.Behaviors;

namespace Telerik.Windows.Examples.ScheduleView.SchedulingAssistant
{
    public class CustomListBoxDragDropBehavior : ListBoxDragDropBehavior
    {
        public override void DragDropCompleted(DragDropState state)
        {
            // In order to avoid the removal of the items from the ListBox,
            // when an item is dropped we shouldn't call the base method.
            //
            // base.DragDropCompleted(state);
        }

        public override bool CanDrop(DragDropState state)
        {
            // Don't want to drop on the ListBox at all.
            return false;
        }
    }
}
