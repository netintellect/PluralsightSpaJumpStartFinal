using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using System.Windows.Media;
using Telerik.Windows.Controls;
using Telerik.Windows.Controls.Diagrams;
using Telerik.Windows.Diagrams.Core;
using Telerik.Windows.DragDrop;
using Telerik.Windows.Input;

namespace Telerik.Windows.Examples.Diagrams.Swimlane.Base
{
    public class SwimlaneShapeBase : CustomContainerBase, IContainerShape
    {
        private SwimlaneDiagram swimlaneDiagram;
        private bool canDrag;
        private bool keepBackground;

        public static readonly DependencyProperty ContainerPositionProperty =
            DependencyProperty.Register("ContainerPosition", typeof(int), typeof(SwimlaneShapeBase), new PropertyMetadata(-1));

        public SwimlaneShapeBase()
        {
            this.MinBoundsWithChildren = Rect.Empty;

            DragDropManager.AddDragLeaveHandler(this, this.OnDragLeaveManager);
            DragDropManager.AddDragEnterHandler(this, this.OnDragEnterManager);
            DragDropManager.AddDragInitializeHandler(this, OnDragInit);
            DragDropManager.AddDragDropCompletedHandler(this, OnDragComplete);
        }

        public Rect MinBoundsWithChildren { get; set; }
        public bool IsInnerResize { get; set; }
        public int ContainerPosition
        {
            get { return (int)GetValue(ContainerPositionProperty); }
            set { SetValue(ContainerPositionProperty, value); }
        }

        public Point DragStartOffset { get; private set; }
        internal MainContainerShapeBase ParentMainContainer
        {
            get
            {
                return this.ParentContainer as MainContainerShapeBase;
            }
        }

        public override void OnApplyTemplate()
        {
            if (this.headerElement != null)
            {
                this.headerElement.MouseEnter -= OnHeaderElementMouseEnter;
                this.headerElement.MouseLeave -= OnHeaderElementMouseLeave;
            }

            base.OnApplyTemplate();

            if (this.headerElement != null)
            {
                this.headerElement.MouseEnter += OnHeaderElementMouseEnter;
                this.headerElement.MouseLeave += OnHeaderElementMouseLeave;
            }
        }

        void IContainerShape.AddItem(object item, Point? position)
        {
            if (item as SwimlaneShapeBase == null)
                this.AddItem(item, position);
        }

        void IContainerShape.AddItems(IEnumerable<object> items)
        {
            if (!items.Any(c => c is SwimlaneShapeBase || c is MainContainerShapeBase))
                this.AddItems(items);
        }

        public override SerializationInfo Serialize()
        {
            bool[] props = new bool[2] { this.IsResizingEnabled, this.IsDraggingEnabled };
            bool[] restore = new bool[2] { false, false };
            if (this.ReadLocalValue(SwimlaneShapeBase.IsResizingEnabledProperty) != DependencyProperty.UnsetValue)
            {
                restore[0] = true;
                this.ClearValue(SwimlaneShapeBase.IsResizingEnabledProperty);
            }
            if (this.ReadLocalValue(SwimlaneShapeBase.IsDraggingEnabledProperty) != DependencyProperty.UnsetValue)
            {
                restore[1] = true;
                this.ClearValue(SwimlaneShapeBase.IsDraggingEnabledProperty);
            }

            var result = base.Serialize();
            result["ContainerPosition"] = this.ContainerPosition.ToString();

            if (restore[0])
                this.IsResizingEnabled = props[0];

            if (restore[1])
                this.IsDraggingEnabled = props[1];

            return result;
        }

        public override void Deserialize(SerializationInfo info)
        {
            base.Deserialize(info);
            if (info["ContainerPosition"] != null)
                this.ContainerPosition = int.Parse(info["ContainerPosition"].ToString());
        }

        public void UpdateMinBounds()
        {
            this.MinBounds = this.GetMinBounds();
        }

        protected override void Initialize(IGraphServiceLocator serviceLocator, IGraphInternal graph)
        {
            base.Initialize(serviceLocator, graph);
            this.swimlaneDiagram = this.Diagram as SwimlaneDiagram;
        }

        protected override void UpdateChildrenPositions(Point oldPosition, Point newPosition)
        {
            if (!this.IsInnerResize)
                base.UpdateChildrenPositions(oldPosition, newPosition);
        }

        protected override void OnChildBoundsChanged(IDiagramItem diagramItem)
        {
        }

        protected override Rect CalculateMinShapeBounds()
        {
            return this.GetMinBounds();
        }

        protected override void OnManagerDrop(object sender, DragDrop.DragEventArgs e)
        {
            this.swimlaneDiagram.HideDragOverVisual();

            SwimlaneShapeBase swimlane = this.GetSwimlane(e);
            if (swimlane != null && this != swimlane)
            {
                if (this.ParentMainContainer == null) return;

                var transformedPoint = (this.Diagram as RadDiagram).GetTransformedPoint(e.GetPosition(this.Diagram as UIElement));

                this.ParentMainContainer.MoveTo(swimlane, this.ContainerPosition);

                if (swimlane.IsPointOverHeaderElement(transformedPoint))
                    swimlane.keepBackground = true;

                e.Handled = true;
            }
            else if (this.GetMainContainer(e) == null)
            {
                base.OnManagerDrop(sender, e);
            }
        }

        protected override void OnDragEnter(DragItemsEventArgs args)
        {
            if (args.Items.Count() > 0 && !args.Items.Any(c => c is CustomContainerBase))
                base.OnDragEnter(args);
        }

        protected override void OnMouseLeftButtonDown(System.Windows.Input.MouseButtonEventArgs e)
        {
            if (!this.IsPointOverHeaderElement((this.Diagram as RadDiagram).GetTransformedPoint(e.GetPosition(this.Diagram as UIElement))))
            {
                if (this.ParentMainContainer == null)
                    this.IsDraggingEnabled = true;
                else
                    this.ClearValue(SwimlaneShapeBase.IsDraggingEnabledProperty);

                base.OnMouseLeftButtonDown(e);
            }
            else
            {
                this.ClearValue(SwimlaneShapeBase.IsDraggingEnabledProperty);
            }
        }

        private void OnDragEnterManager(object sender, DragDrop.DragEventArgs e)
        {
            if (this.GetSwimlane(e) != null)
            {
                this.swimlaneDiagram.ShowDragOverVisual(this);
            }
            else if (this.GetMainContainer(e) == null)
            {
                base.OnDragEnter(new DragItemsEventArgs());
            }
        }

        private void OnDragLeaveManager(object sender, DragDrop.DragEventArgs e)
        {
            if (this.GetSwimlane(e) != null)
            {
                this.swimlaneDiagram.HideDragOverVisual();
            }
            else if (this.GetMainContainer(e) == null)
            {
                base.OnDragLeave(new DragItemsEventArgs());
            }
        }

        private void OnHeaderElementMouseLeave(object sender, MouseEventArgs e)
        {
            this.OnHeaderElementLeave();
        }

        private void OnHeaderElementMouseEnter(object sender, MouseEventArgs e)
        {
#if SILVERLIGHT
            if (this.IsPointOverHeaderElement((this.Diagram as RadDiagram).GetTransformedPoint(e.GetPosition(this.Diagram as UIElement))))
#endif
                this.OnHeaderElementEnter();
        }

        public bool IsPointOverHeaderElement(Point transformedPoint)
        {
            if (this.headerElement == null) return false;

            return new Rect(this.Position, new Size(this.headerElement.ActualWidth, this.headerElement.ActualHeight)).Contains(transformedPoint);
        }

        private void OnHeaderElementLeave()
        {
            this.canDrag = false;
            VisualStateManager.GoToState(this, "NormalHeader", false);
        }

        private void OnHeaderElementEnter()
        {
            this.canDrag = true;

            VisualStateManager.GoToState(this, "MouseOverHeader", false);
        }

        private Rect GetShapeBounds(Rect contentBounds)
        {
            if (this.headerElement == null) return contentBounds;

            if (this.Orientation == System.Windows.Controls.Orientation.Horizontal)
            {
                var width = contentBounds.Width + this.headerElement.ActualWidth;
                var height = contentBounds.Height;
                var x = contentBounds.X - this.headerElement.ActualWidth;
                var y = contentBounds.Y;

                return new Rect(x, y, width, height);
            }
            else
            {
                var width = contentBounds.Width;
                var height = contentBounds.Height + this.headerElement.ActualHeight;
                var x = contentBounds.X;
                var y = contentBounds.Y - this.headerElement.ActualHeight;

                return new Rect(x, y, width, height);
            }
        }

        private void OnDragInit(object sender, DragInitializeEventArgs e)
        {
            if (this.canDrag)
            {
#if SILVERLIGHT
                e.Data = this;
#else
                e.Data = new DataObject(typeof(SwimlaneShapeBase), this);
#endif
                this.Diagram.ServiceLocator.GetService<IToolService>().IsMouseDown = false;
                this.DragStartOffset = e.RelativeStartPoint;

                var newBounds = new Rect(this.Position, new Size(this.Bounds.Width, this.Height + 1));
                var bm = this.swimlaneDiagram.CreateImage(newBounds);

                var draggingImage = new System.Windows.Controls.Image
                {
                    Source = bm,
                    Width = newBounds.Width,
                    Height = newBounds.Height,
                };

                e.DragVisual = new Border() { Child = draggingImage, Opacity = 0.5 };

                e.AllowedEffects = DragDropEffects.All;
                e.Handled = true;
            }
            else
            {
#if SIVERLIGHT
                this.IsMouseOver = true;
#endif
                e.Cancel = true;
            }
        }

        private void OnDragComplete(object sender, DragDropCompletedEventArgs e)
        {
            if (!this.keepBackground)
                this.OnHeaderElementLeave();

            this.swimlaneDiagram.HideDragOverVisual();
            this.keepBackground = false;
        }

        private Rect GetMinBounds()
        {
            var childrenBounds = this.GetChildrenBounds();

            if (childrenBounds != Rect.Empty)
            {
                childrenBounds = this.GetShapeBounds(childrenBounds);
                this.MinBoundsWithChildren = childrenBounds;
                childrenBounds.Intersect(this.Bounds);
            }
            else
            {
                this.MinBoundsWithChildren = childrenBounds;
            }

            return childrenBounds;
        }
    }
}