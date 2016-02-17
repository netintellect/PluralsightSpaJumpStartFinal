using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using System.Windows.Media.Imaging;
using sys = System.Windows.Controls;
#if WPF
using selection = System.Windows.Controls;
#else
using selection = Telerik.Windows.Controls;
#endif
using Telerik.Windows.Controls;
using Telerik.Windows.Controls.Diagrams;
using Telerik.Windows.Diagrams.Core;
using Telerik.Windows.DragDrop;
using Telerik.Windows.Examples.Diagrams.Swimlane.Base;

namespace Telerik.Windows.Examples.Diagrams.Swimlane
{
    public class SwimlaneDiagram : RadDiagram
    {
        private CustomManipulationAdorner manipulationAdorner;
        private FrameworkElement horizontalDragVisual;
        private FrameworkElement verticalDragVisual;
        private DiagramSurface itemHost;

        public SwimlaneDiagram()
            : base()
        {
            DragDropManager.AddDropHandler(this, OnDrop);
            this.ItemsChanging += OnSwimlaneDiagramItemsChanging;
        }

        public override void OnApplyTemplate()
        {
            base.OnApplyTemplate();

            this.manipulationAdorner = this.GetTemplateChild("ManipulationAdorner") as CustomManipulationAdorner;
            this.horizontalDragVisual = this.GetTemplateChild("PART_horizontalDragOver") as FrameworkElement;
            this.verticalDragVisual = this.GetTemplateChild("PART_verticalDragOver") as FrameworkElement;
            this.itemHost = this.GetTemplateChild("ItemsHost") as DiagramSurface;

            this.SelectionChanged += OnSelectionChanged;
        }

        protected override void OnDeleteCommandExecutedOverride(object sender, ExecutedRoutedEventArgs e)
        {
            var compositeRemoveCommand = new CompositeCommand("Remove Connections");
            foreach (var item in this.SelectedItems)
            {
                var container = this.ContainerGenerator.ContainerFromItem(item) as IShape;
                if (container != null)
                {
                    foreach (var connection in this.GetConnectionsForShape(container).ToList())
                    {
                        compositeRemoveCommand.AddCommand(new UndoableDelegateCommand("Remove Connection",
                                                                 new Action<object>((o) => this.RemoveConnection(connection)),
                                                                 new Action<object>((o) => this.AddConnection(connection))));
                    }
                }
            }

            base.OnDeleteCommandExecutedOverride(sender, e);

            if (compositeRemoveCommand.Commands.Count() > 0)
            {
                compositeRemoveCommand.Execute();
                ((this.UndoRedoService.UndoStack.FirstOrDefault() as CompositeCommand).Commands as IList<Telerik.Windows.Diagrams.Core.ICommand>).Add(compositeRemoveCommand);
            }
        }

        protected override bool PublishDiagramEvent(DiagramEvent diagramEvent, object args)
        {
            if (diagramEvent == DiagramEvent.SelectionBoundsChanged)
            {
                var mainContainer = this.SelectedItem as MainContainerShapeBase;
                UpdateHandlers(mainContainer);
            }
            return base.PublishDiagramEvent(diagramEvent, args);
        }

        internal WriteableBitmap CreateImage(Rect bounds)
        {
            return BitmapUtils.CreateWriteableBitmap(this.itemHost as UIElement, bounds, bounds.ToSize(), null, new Thickness());
        }

        internal void ShowDragOverVisual(SwimlaneShapeBase shape)
        {
            if (shape.ParentMainContainer == null) return;

            var bounds = shape.Bounds;
            if (shape.ParentMainContainer.ChildrenPositioning == sys.Orientation.Vertical)
            {
                if (this.horizontalDragVisual == null) return;

                this.horizontalDragVisual.Visibility = System.Windows.Visibility.Visible;
                Canvas.SetLeft(this.horizontalDragVisual, bounds.X);
                Canvas.SetTop(this.horizontalDragVisual, bounds.Bottom);
                this.horizontalDragVisual.Width = bounds.Width;
            }
            else
            {
                if (this.verticalDragVisual == null) return;

                this.verticalDragVisual.Visibility = System.Windows.Visibility.Visible;
                Canvas.SetLeft(this.verticalDragVisual, bounds.Right);
                Canvas.SetTop(this.verticalDragVisual, bounds.Y);
                this.verticalDragVisual.Height = bounds.Height;
            }
        }

        internal void HideDragOverVisual()
        {
            if (this.horizontalDragVisual != null)
                this.horizontalDragVisual.Visibility = System.Windows.Visibility.Collapsed;
            if (this.verticalDragVisual != null)
                this.verticalDragVisual.Visibility = System.Windows.Visibility.Collapsed;
        }

        private void OnSelectionChanged(object sender, selection.SelectionChangedEventArgs e)
        {
            var mainContainer = this.SelectedItem as MainContainerShapeBase;
            if (e.AddedItems.Count > 0 && this.manipulationAdorner != null && mainContainer != null)
            {
                this.manipulationAdorner.AdditionalHandlersVisibility = System.Windows.Visibility.Visible;
                this.UpdateHandlers(mainContainer);
            }
            else
            {
                this.manipulationAdorner.AdditionalHandlersVisibility = System.Windows.Visibility.Collapsed;
            }
        }

        private void OnDrop(object sender, DragDrop.DragEventArgs e)
        {
#if SILVERLIGHT
            var swimlane = e.Data as SwimlaneShapeBase;
#else
            var swimlane = (e.Data as DataObject).GetData(typeof(SwimlaneShapeBase)) as SwimlaneShapeBase;
#endif
            if (swimlane != null)
            {
                var transformedPoint = this.GetTransformedPoint(e.GetPosition(this));
                var newPosition = transformedPoint.Substract(swimlane.DragStartOffset);
                var oldPosition = swimlane.Position;
                var mainParent = swimlane.ParentContainer as MainContainerShapeBase;
                if (mainParent != null)
                {
                    var command = new UndoableDelegateCommand("Remove container from main",
                        new Action<object>((o) =>
                        {
                            swimlane.Position = newPosition;
                            mainParent.Items.Remove(swimlane);
                            mainParent.UpdateChildContainers();
                        }),
                           new Action<object>((o) =>
                           {
                               swimlane.Position = oldPosition;
                               mainParent.Items.Add(swimlane);
                               mainParent.UpdateChildContainers();
                           }));

                    this.UndoRedoService.ExecuteCommand(command);
                }
                else
                {
                    var command = new UndoableDelegateCommand("Remove container from main",
                                          new Action<object>((o) =>
                                          {
                                              swimlane.Position = newPosition;
                                          }),
                                          new Action<object>((o) =>
                                          {
                                              swimlane.Position = oldPosition;
                                          }));

                    this.UndoRedoService.ExecuteCommand(command);
                }
            }
        }

        private void OnSwimlaneDiagramItemsChanging(object sender, DiagramItemsChangingEventArgs e)
        {
            if (e.Action == System.Collections.Specialized.NotifyCollectionChangedAction.Remove)
            {
                var container = e.OldItems.ElementAt(0) as SwimlaneShapeBase;
                if (container != null && container.ParentMainContainer != null)
                {
                    foreach (var item in container.ParentMainContainer.OrderedChildren.Where(c => c.ContainerPosition > container.ContainerPosition))
                    {
                        item.ContainerPosition--;
                    }
                }
            }
        }

        private void UpdateHandlers(MainContainerShapeBase mainContainer)
        {
            if (mainContainer != null)
            {
                var offset = this.ServiceLocator.GetService<IAdornerService>().InflatedAdornerBounds.TopLeft();
                if (this.manipulationAdorner != null && !offset.X.IsNanOrInfinity() && !offset.Y.IsNanOrInfinity())
                {
                    this.manipulationAdorner.UpdateAdditionalHandlers(mainContainer.OrderedChildren, offset, !mainContainer.IsCollapsed, mainContainer.ChildrenPositioning);
                }
            }
        }
    }
}
