using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows;
using Telerik.Windows.Controls;
using Telerik.Windows.Diagrams.Core;
using Telerik.Windows.Examples.Diagrams.Swimlane.Base;

namespace Telerik.Windows.Examples.Diagrams.Swimlane
{
    public class CustomResizingService : ResizingService
    {
        public static double MinShapeHeight = 12;
        public static double MinShapeWidth = 12;

        private MainContainerShapeBase mainContainer;
        private CompositeAsyncStateCommand compositeCommand;
        private bool isFirstChildResize = false;
        private bool restrictResize = false;
        private Rect startBounds;
        private double min;
        private double max;
        //private bool isFirstResize;

        public CustomResizingService(RadDiagram diagram)
            : base(diagram)
        { }

        public override void InitializeResize(System.Collections.Generic.IEnumerable<IDiagramItem> newSelectedItems, double adornerAngle, Rect adornerBounds, ResizeDirection resizingDirection, Point startPoint)
        {
            this.mainContainer = newSelectedItems.FirstOrDefault() as MainContainerShapeBase;
            if (this.mainContainer != null)
                this.mainContainer.UpdateMinBounds();

            base.InitializeResize(newSelectedItems, adornerAngle, adornerBounds, resizingDirection, startPoint);

            if (this.mainContainer != null)
            {
                var firstChild = this.mainContainer.OrderedChildren.FirstOrDefault();
                var lastChild = this.mainContainer.OrderedChildren.LastOrDefault();

                if (firstChild != null && lastChild != null)
                {
                    this.restrictResize = true;
                    this.startBounds = this.mainContainer.ContentBounds;

                    if (this.mainContainer.ChildrenPositioning == System.Windows.Controls.Orientation.Vertical)
                    {
                        this.isFirstChildResize = resizingDirection == ResizeDirection.NorthEastSouthWest || resizingDirection == ResizeDirection.NorthWestSouthEast;
                        this.min = firstChild.MinBoundsWithChildren != Rect.Empty ? firstChild.MinBoundsWithChildren.Top : firstChild.Bounds.Bottom - CustomResizingService.MinShapeHeight;
                        this.max = lastChild.MinBoundsWithChildren != Rect.Empty ? lastChild.MinBoundsWithChildren.Bottom : lastChild.Bounds.Top + CustomResizingService.MinShapeHeight;
                    }
                    else
                    {
                        this.isFirstChildResize = resizingDirection == ResizeDirection.SouthWestNorthEast || resizingDirection == ResizeDirection.NorthWestSouthEast;
                        this.min = firstChild.MinBoundsWithChildren != Rect.Empty ? firstChild.MinBoundsWithChildren.Left : firstChild.Bounds.Right - CustomResizingService.MinShapeWidth;
                        this.max = lastChild.MinBoundsWithChildren != Rect.Empty ? lastChild.MinBoundsWithChildren.Right : lastChild.Bounds.Left + CustomResizingService.MinShapeWidth;
                    }
                    this.CreateResizeCommand();
                }
                else
                {
                    this.restrictResize = false;
                }
            }

            //this.isFirstResize = true;
        }

        public override void Resize(Point newPoint)
        {
            //if (this.isFirstResize)
            //    this.Graph.ServiceLocator.GetService<IUndoRedoService>();
            //this.isFirstResize = false;

            base.Resize(newPoint);

            if (this.mainContainer != null)
            {
                var newBounds = this.mainContainer.GetNewContentBounds(this.mainContainer.Bounds);
                if (this.mainContainer.ChildrenPositioning == System.Windows.Controls.Orientation.Vertical)
                {
                    for (int i = 0; i < this.mainContainer.OrderedChildren.Count; i++)
                    {
                        var container = this.mainContainer.OrderedChildren[i];
                        if (!container.IsCollapsed)
                            container.Width = newBounds.Width;

                        if (i == 0)
                        {
                            container.Height = Math.Max(0, container.Bounds.Bottom - newBounds.Top);
                            container.Position = new Point(newBounds.X, newBounds.Y);
                        }
                        else
                        {
                            container.Position = new Point(newBounds.X, container.Position.Y);
                        }

                        if (i == this.mainContainer.OrderedChildren.Count - 1)
                        {
                            container.Height = Math.Max(0, newBounds.Bottom - container.Position.Y);
                        }
                    }
                }
                else
                {
                    for (int i = 0; i < this.mainContainer.OrderedChildren.Count; i++)
                    {
                        var container = this.mainContainer.OrderedChildren[i];
                        if (!container.IsCollapsed)
                            container.Height = newBounds.Height;


                        if (i == 0)
                        {
                            container.Width = Math.Max(0, container.Bounds.Right - newBounds.Left);
                            container.Position = new Point(newBounds.X, newBounds.Y);
                        }
                        else
                        {
                            container.Position = new Point(container.Position.X, newBounds.Y);
                        }

                        if (i == this.mainContainer.OrderedChildren.Count - 1)
                        {
                            container.Width = Math.Max(0, newBounds.Right - container.Position.X);
                        }
                    }
                }
            }
        }

        public override void CompleteResize(Rect finalBounds, Point mousePosition)
        {
            var resizeCommand = this.Graph.ServiceLocator.GetService<IUndoRedoService>().UndoStack.ElementAt(0) as CompositeAsyncStateCommand;
            if (resizeCommand != null)
            {
                resizeCommand.InsertCommand(0, new UndoableDelegateCommand("Set property",
                 new Action<object>((o) =>
                 {
                     this.mainContainer.ShouldUpdateChildren = false;
                 }),
                new Action<object>((o) =>
                {
                    this.mainContainer.ShouldUpdateChildren = true;
                })), null);
                resizeCommand.AddCommand(this.compositeCommand);
            }

            base.CompleteResize(finalBounds, mousePosition);

            if (this.mainContainer != null)
            {
                var newStates = this.mainContainer.Children.OfType<IShape>().Select(s => new ShapeInfo(s.Position, s.Bounds.ToSize(), s.RotationAngle)).OfType<object>();
                if (this.compositeCommand != null)
                    this.compositeCommand.Complete(true, newStates);
            }
        }

        protected override Point CalculateNewDelta(Point newPoint)
        {
            var resizeVector = base.CalculateNewDelta(newPoint);
            if (this.mainContainer != null && this.restrictResize)
            {
                if (this.mainContainer.ChildrenPositioning == System.Windows.Controls.Orientation.Vertical)
                {
                    if (this.isFirstChildResize)
                    {
                        if (this.startBounds.Top - resizeVector.Y > min)
                            resizeVector = new Point(resizeVector.X, Math.Min(0, this.startBounds.Top - min));

                    }
                    else
                    {
                        if (this.startBounds.Bottom + resizeVector.Y < max)
                            resizeVector = new Point(resizeVector.X, Math.Min(0, max - this.startBounds.Bottom));
                    }
                }
                else
                {
                    if (this.isFirstChildResize)
                    {
                        if (this.startBounds.Left - resizeVector.X > min)
                            resizeVector = new Point(Math.Min(0, this.startBounds.Left - min), resizeVector.Y);

                    }
                    else
                    {
                        if (this.startBounds.Right + resizeVector.X < max)
                            resizeVector = new Point(Math.Min(0, max - this.startBounds.Right), resizeVector.Y);
                    }
                }
            }

            return resizeVector;
        }

        protected override void UpdateContainers()
        {
        }

        private void CreateResizeCommand()
        {
            var shapeChildren = this.mainContainer.Children.OfType<SwimlaneShapeBase>();
            this.compositeCommand = new CompositeAsyncStateCommand("Resize horizontal containers");
            compositeCommand.AddCommand(new UndoableDelegateCommand("Set property",
                new Action<object>((o) =>
                {
                    if (this.mainContainer != null)
                        this.mainContainer.ShouldUpdateChildren = true;
                }),
                new Action<object>((o) =>
                {
                    if (this.mainContainer != null)
                        this.mainContainer.ShouldUpdateChildren = false;
                })), null);
            var commands = shapeChildren.Select(shape => new AsyncStateCommand("Resize horizontal container",
                state =>
                {
                    shape.ShouldUpdateChildren = false;
                    var info = (ShapeInfo)state;
                    shape.Width = info.Size.Width;
                    shape.Height = info.Size.Height;
                    shape.Position = info.Position;
                    shape.ShouldUpdateChildren = true;
                },
                state =>
                {
                    shape.ShouldUpdateChildren = false;
                    var info = (ShapeInfo)state;
                    shape.Width = info.Size.Width;
                    shape.Height = info.Size.Height;
                    shape.Position = info.Position;
                    shape.ShouldUpdateChildren = true;
                }));
            var states = shapeChildren.Select(s => new ShapeInfo(s.Position, s.Bounds.ToSize(), s.RotationAngle));
            for (int i = 0; i < commands.Count(); i++)
            {
                if (i < states.Count())
                    this.compositeCommand.AddCommand(commands.ElementAt(i), states.ElementAt(i));
                else
                    this.compositeCommand.AddCommand(commands.ElementAt(i), null);
            }
        }
    }
}
