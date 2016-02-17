using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows;
using Telerik.Windows.Controls;
using Telerik.Windows.Diagrams.Core;
using Telerik.Windows.DragDrop;

namespace Telerik.Windows.Examples.Diagrams.Swimlane.Base
{
    public class MainContainerShapeBase : CustomContainerBase, IContainerShape
    {
        private static readonly double childrenMargin = 0;
        private static readonly Size newItemSize = new Size(200, 110);

        private readonly List<IConnection> collapsedItems;
        private List<SwimlaneShapeBase> orderedChildren;
        private bool isInternalResize;

        public List<SwimlaneShapeBase> OrderedChildren
        {
            get
            {
                return this.orderedChildren;
            }
        }

        public System.Windows.Controls.Orientation ChildrenPositioning { get; set; }

        public MainContainerShapeBase()
        {
            this.ChildrenPositioning = System.Windows.Controls.Orientation.Vertical;
            DragDropManager.AddDragEnterHandler(this, this.OnDragEnterManager);
            this.collapsedItems = new List<IConnection>();
        }

        public void UpdateMinBounds()
        {
            foreach (var item in this.Children.OfType<SwimlaneShapeBase>())
            {
                item.UpdateMinBounds();
            }

            this.MinBounds = this.CalculateMinShapeBounds();
        }

        public override void OnApplyTemplate()
        {
            base.OnApplyTemplate();

            this.UpdateChildContainers();
        }

        public void MoveTo(SwimlaneShapeBase dragObject, int endPosition, bool isUndoable = true)
        {
            bool shouldAdd = !this.Items.Contains(dragObject);
            bool addToDiagram = !this.Diagram.Items.Contains(dragObject);

            var diagramPosition = dragObject.Position;
            var startPosition = shouldAdd ? this.Items.Count : dragObject.ContainerPosition;
            endPosition = startPosition <= endPosition ? endPosition : endPosition + 1;

            var doAction = new Action<object>((o) =>
            {
                this.MoveContainer(startPosition, endPosition, dragObject);
                if (shouldAdd)
                    this.AddItem(dragObject);
                this.UpdateChildContainers();
            });

            if (isUndoable)
            {
                var command = new UndoableDelegateCommand("Move container",
                        doAction,
                         new Action<object>((o) =>
                         {
                             this.MoveContainer(endPosition, startPosition, dragObject);
                             if (shouldAdd)
                             {
                                 this.RemoveItem(dragObject);
                                 dragObject.Position = diagramPosition;
                                 if (addToDiagram)
                                     this.Diagram.Items.Remove(dragObject);
                             }
                             this.UpdateChildContainers();
                         }));
                this.Diagram.ServiceLocator.GetService<IUndoRedoService>().ExecuteCommand(command);
            }
            else
            {
                doAction.Invoke(null);
            }
        }

        public void UpdateChildContainers(bool resizeChildren = false)
        {
            var bounds = this.ContentBounds;
            this.orderedChildren = this.Children.OfType<SwimlaneShapeBase>().OrderBy(c => c.ContainerPosition).ToList();
            if (!this.loaded || !this.templateApplied) return;

            if (orderedChildren.Count > 0)
            {
                if (this.ChildrenPositioning == System.Windows.Controls.Orientation.Vertical)
                {
                    double childWidth = bounds.Width;
                    if (!resizeChildren)
                        childWidth = Math.Max(bounds.Width, this.OrderedChildren.Max(c => c.ContentBounds.Width));
                    for (int i = 0; i < this.orderedChildren.Count; i++)
                    {
                        var container = this.orderedChildren[i];
                        if (i == 0)
                            container.Position = new Point(bounds.X, bounds.Y);
                        else
                            container.Position = new Point(bounds.X, this.orderedChildren[i - 1].Bounds.Bottom - 1 + childrenMargin);

                        if (double.IsNaN(container.Height) || container.Height == 0)
                            container.Height = newItemSize.Height;

                        container.Width = childWidth;

                        if (i == this.orderedChildren.Count - 1 && container.Bounds.Bottom != bounds.Bottom)
                        {
                            bool update = true;
                            if (resizeChildren)
                            {
                                var minBottom = container.MinBounds != Rect.Empty ? container.MinBounds.Bottom : container.Bounds.Top + CustomResizingService.MinShapeHeight;
                                if (minBottom > bounds.Bottom)
                                {
                                    container.Height = minBottom - container.Y;
                                }
                                else
                                {
                                    container.Height = bounds.Bottom - container.Y;
                                    update = false;
                                }
                            }

                            if (update)
                            {
                                this.isInternalResize = true;
                                this.ContentBounds = new Rect(this.ContentBounds.TopLeft(), new Size(childWidth, container.Bounds.Bottom - this.ContentBounds.Y));
                            }
                        }
                    }
                }
                else
                {
                    double childHeight = bounds.Height;
                    if (!resizeChildren)
                        childHeight = Math.Max(bounds.Height, this.OrderedChildren.Max(c => c.ContentBounds.Height));
                    for (int i = 0; i < this.orderedChildren.Count; i++)
                    {
                        var container = this.orderedChildren[i];
                        if (i == 0)
                            container.Position = new Point(bounds.X, bounds.Y);
                        else
                            container.Position = new Point(this.orderedChildren[i - 1].Bounds.Right - 1 + childrenMargin, bounds.Y);

                        if (double.IsNaN(container.Width) || container.Width == 0)
                            container.Width = newItemSize.Width;

                        container.Height = childHeight;

                        if (i == this.orderedChildren.Count - 1 && container.Bounds.Right != bounds.Right)
                        {
                            bool update = true;
                            if (resizeChildren)
                            {
                                var minRight = container.MinBounds != Rect.Empty ? container.MinBounds.Right : container.Bounds.Left + CustomResizingService.MinShapeWidth;
                                if (minRight > bounds.Right)
                                {
                                    container.Width = minRight - container.X;
                                }
                                else
                                {
                                    container.Width = bounds.Right - container.X;
                                    update = false;
                                }
                            }

                            if (update)
                            {
                                this.isInternalResize = true;
                                this.ContentBounds = new Rect(this.ContentBounds.TopLeft(), new Size(container.Bounds.Right - bounds.X, childHeight));
                            }
                        }
                    }
                }
            }
        }

        void IContainerShape.AddItem(object item, Point? position)
        {
            var swimLaneItem = item as SwimlaneShapeBase;
            if (this.loaded && swimLaneItem != null)
            {
                var endPos = swimLaneItem.ContainerPosition;
                swimLaneItem.ContainerPosition = this.Items.Count;
                this.MoveTo(swimLaneItem, endPos - 1, false);
                this.TryToSelect();
            }
            else if (swimLaneItem != null || item is IConnection)
            {
                base.AddItem(item);
                this.TryToSelect();
            }
        }

        void IContainerShape.AddItems(IEnumerable<object> items)
        {
            if (items.Any(c => c is SwimlaneShapeBase))
            {
                this.AddItems(items);
                this.UpdateChildContainers();
                this.TryToSelect();
                base.OnDragLeave(new DragItemsEventArgs());
            }
        }

        internal void SwapChildren(SwimlaneShapeBase first, SwimlaneShapeBase second)
        {
            int firstPosition = first.ContainerPosition;
            int secondPosition = second.ContainerPosition;
            var command = new UndoableDelegateCommand("Swap children",
                       new Action<object>((o) =>
                       {
                           first.ContainerPosition = secondPosition;
                           second.ContainerPosition = firstPosition;
                           this.UpdateChildContainers();
                       }),
                          new Action<object>((o) =>
                          {
                              first.ContainerPosition = firstPosition;
                              second.ContainerPosition = secondPosition;
                              this.UpdateChildContainers();
                          }));

            this.Diagram.ServiceLocator.GetService<IUndoRedoService>().ExecuteCommand(command);
        }

        protected override void OnSizeChanged(Size newSize, Size oldSize)
        {
            base.OnSizeChanged(newSize, oldSize);
            if (this.loaded && !this.isInternalResize && this.Diagram != null && !this.Diagram.ServiceLocator.GetService<IResizingService>().IsResizing)
            {
                this.UpdateChildContainers(true);
            }
            this.isInternalResize = false;
        }

        protected override void OnHeaderPresenterSizeChanged(object sender, SizeChangedEventArgs e)
        {
            base.OnHeaderPresenterSizeChanged(sender, e);
            if (this.loaded)
            {
                this.ShouldUpdateChildren = false;
                var newX = this.ContentBounds.X - DiagramConstants.ContainerMargin - this.actualHeaderWidth;
                var newWidth = this.Bounds.Right - newX;
                var widthDelta = newWidth - this.Width;

                this.Position = new Point(newX, this.Position.Y);
                this.Width = Math.Max(0, newWidth);
                if (this.IsCollapsed && e.PreviousSize.Height != 0)
                {
                    if (widthDelta.IsNanOrInfinity() || widthDelta == 0)
                        widthDelta = e.NewSize.Height - e.PreviousSize.Height;

                    this.SetValue(WidthProperty, WidthProperty.GetMetadata(typeof(FrameworkElement)).DefaultValue);
                    this.restoredWidth = Math.Max(0, this.restoredWidth + widthDelta);
                }
                this.ShouldUpdateChildren = true;
            }
        }

        protected override void OnDrop(DragItemsEventArgs args)
        {
        }

        protected override void OnDragEnter(DragItemsEventArgs args)
        {
            if (args.Items.Count() > 0 && args.Items.Any(c => c is SwimlaneShapeBase))
                base.OnDragEnter(args);
        }

        protected override void OnManagerDrop(object sender, DragDrop.DragEventArgs e)
        {
            SwimlaneShapeBase swimlane = this.GetSwimlane(e);
            if (swimlane != null)
            {
                VisualStateManager.GoToState(this, "DropNormal", false);
                var tmpCollapsed = this.IsCollapsed;
                if (tmpCollapsed)
                    this.IsCollapsed = false;

                if (swimlane != null)
                    this.MoveTo(swimlane, this.Items.Count);

                this.TryToSelect();

                this.IsCollapsed = tmpCollapsed;

                e.Handled = true;
            }
        }

        protected override Rect CalculateMinShapeBounds()
        {
            var minBounds = Rect.Empty;
            foreach (var item in this.Children.OfType<SwimlaneShapeBase>())
            {
                minBounds.Union(item.MinBounds);
            }
            if (minBounds != Rect.Empty)
            {
                return this.GetShapeBounds(minBounds);
            }

            return minBounds;
        }

        protected override void OnItemsCollectionChanged(object sender, System.Collections.Specialized.NotifyCollectionChangedEventArgs e)
        {
            base.OnItemsCollectionChanged(sender, e);
            this.IsDropEnabled = this.Items.Count == 0;
            if (e.Action == System.Collections.Specialized.NotifyCollectionChangedAction.Add)
            {
                var container = e.NewItems[0] as SwimlaneShapeBase;
                if (container != null)
                {
                    container.IsResizingEnabled = false;
                }
            }
            else if (e.Action == System.Collections.Specialized.NotifyCollectionChangedAction.Remove)
            {
                var container = e.OldItems[0] as FrameworkElement;
                if (container != null)
                {
                    container.ClearValue(RadDiagramShape.IsResizingEnabledProperty);
                }
            }

            this.orderedChildren = this.Children.OfType<SwimlaneShapeBase>().OrderBy(c => c.ContainerPosition).ToList();
            //this.ContentBounds = this.CalculateContentBounds(this.Bounds);
            this.UpdateChildContainers();
        }

        protected override void OnCustomContainerLoaded(object sender, RoutedEventArgs e)
        {
            base.OnCustomContainerLoaded(sender, e);
            this.UpdateChildContainers();
        }

        private void TryToSelect()
        {
            var diagram = this.Diagram as RadDiagram;
            if (diagram != null)
            {
                diagram.DeselectAll();
                diagram.SelectedItem = this;
            }
        }

        private void MoveContainer(int startPosition, int endPosition, SwimlaneShapeBase dragObject)
        {
            if (startPosition <= endPosition)
            {
                for (int i = 0; i < this.OrderedChildren.Count; i++)
                {
                    var item = this.OrderedChildren[i];
                    if (item.ContainerPosition <= startPosition)
                        continue;
                    if (item.ContainerPosition > endPosition)
                        break;

                    item.ContainerPosition--;
                }

                dragObject.ContainerPosition = endPosition;
            }
            else
            {
                for (int i = 0; i < this.OrderedChildren.Count; i++)
                {
                    var item = this.OrderedChildren[i];
                    if (item.ContainerPosition < endPosition)
                        continue;
                    if (item.ContainerPosition >= startPosition)
                        break;

                    item.ContainerPosition++;
                }

                dragObject.ContainerPosition = endPosition;
            }
        }

        private void OnDragEnterManager(object sender, DragDrop.DragEventArgs e)
        {
            if (this.GetSwimlane(e) != null)
                base.OnDragEnter(new DragItemsEventArgs());
        }
    }
}
