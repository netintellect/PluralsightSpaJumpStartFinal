using System;
using System.Linq;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Controls.Primitives;
using System.Windows.Input;
using Telerik.Windows.Controls.Diagrams;
using Core = Telerik.Windows.Diagrams.Core;

namespace Telerik.Windows.Examples.Diagrams.Swimlane.Base
{
    public class CustomContainerBase : Telerik.Windows.Controls.RadDiagramContainerShape, Core.IContainerShape
    {
        private double restoredMinWidth;
        private Popup editPopup;
        private TextBox editTextBox;

        protected Grid headerElement;
        protected Grid editHeaderElement;
        protected bool templateApplied;
        protected bool loaded;
        protected double restoredWidth;
        protected double actualHeaderWidth;
        private bool isRollback;

        public bool ShouldUpdateChildren { get; set; }

        public Orientation Orientation { get; set; }

        public CustomContainerBase()
        {
            this.Loaded += this.OnCustomContainerLoaded;
            this.ShouldUpdateChildren = true;
        }

        public override void OnApplyTemplate()
        {
            var headerPresenter = this.GetTemplateChild("NormalContentPresenter") as FrameworkElement;
            if (headerPresenter != null)
                headerPresenter.SizeChanged += OnHeaderPresenterSizeChanged;

            base.OnApplyTemplate();

            if (this.editTextBox != null)
            {
                this.editTextBox.KeyDown -= OnEditPopupKeyDown;
            }

            this.headerElement = this.GetTemplateChild("PART_headerElement") as Grid;
            this.editHeaderElement = this.GetTemplateChild("PART_editHeaderElement") as Grid;
            this.editPopup = this.GetTemplateChild("PART_editPopup") as Popup;
            this.editTextBox = this.GetTemplateChild("EditTextBox") as TextBox;

#if WPF
            if (this.editPopup != null)
            {
                this.editPopup.Placement = System.Windows.Controls.Primitives.PlacementMode.Center;
            }
#endif

            if (this.editTextBox != null)
            {
#if SILVERLIGHT
                this.editTextBox.AcceptsReturn = true;
#endif
                this.editTextBox.KeyDown += OnEditPopupKeyDown;
            }

            this.templateApplied = true;
            if (this.loaded)
                this.ContentBounds = this.GetNewContentBounds(this.Bounds);
        }

        public Rect GetNewContentBounds(Rect shapeBounds)
        {
            if (this.headerElement == null) return shapeBounds;

            double margin = Core.DiagramConstants.ContainerMargin;

            if (this.Orientation == Orientation.Vertical)
            {
                double headerOffset = this.headerElement != null ? this.headerElement.ActualHeight + this.headerElement.Margin.Top + this.headerElement.Margin.Bottom : 0;

                var width = Math.Max(0, shapeBounds.Width - (2 * margin));
                var height = Math.Max(0, shapeBounds.Height - (2 * margin) - headerOffset);
                var x = shapeBounds.X + margin;
                var y = shapeBounds.Y + margin + headerOffset;

                return new Rect(x, y, width, height);
            }
            else
            {
                double elementWidth = double.IsNaN(this.headerElement.Width) ? this.actualHeaderWidth : this.headerElement.Width;
                double headerWidth = double.IsNaN(elementWidth) ? this.headerElement.ActualWidth : elementWidth;
                headerWidth = Math.Round(headerWidth, 1);
                var width = Math.Max(0, shapeBounds.Width - (2 * margin) - headerWidth);
                var height = Math.Max(0, shapeBounds.Height - (2 * margin));
                var x = shapeBounds.X + margin + headerWidth;
                var y = shapeBounds.Y + margin;

                var newBounds = new Rect(x, y, width, height);

                return newBounds;
            }
        }

        Rect Core.IContainerShape.ContentBounds
        {
            get
            {
                return this.ContentBounds;
            }
            set
            {
                if (!this.Diagram.ServiceLocator.GetService<Core.IRotationService>().IsRotating)
                {
                    this.ContentBounds = value;
                }
            }
        }

        protected virtual void OnHeaderPresenterSizeChanged(object sender, SizeChangedEventArgs e)
        {
            if (this.loaded)
            {
                var element = sender as FrameworkElement;
                if (element != null && this.headerElement != null)
                {
                    this.actualHeaderWidth = Math.Round(Math.Max(e.NewSize.Height + element.Margin.Top + element.Margin.Bottom, this.headerElement.MinWidth));
                }
                else
                {
                    this.actualHeaderWidth = e.NewSize.Height;
                }
            }
            else if (this.headerElement != null)
            {
                this.actualHeaderWidth = Math.Max(this.headerElement.ActualWidth, this.headerElement.MinWidth);
            }
        }

        protected virtual void OnCustomContainerLoaded(object sender, RoutedEventArgs e)
        {
            if (this.templateApplied)
                this.ContentBounds = this.GetNewContentBounds(this.Bounds);

            this.loaded = true;
        }

        protected override void OnRotationAngleChanged(double newValue, double oldValue)
        {
            if (!this.isRollback)
            {
                this.isRollback = true;
                this.RotationAngle = oldValue;
                this.isRollback = false;
            }
        }

        protected override void UpdateChildrenPositions(Point oldPosition, Point newPosition)
        {
            if (this.ShouldUpdateChildren)
                base.UpdateChildrenPositions(oldPosition, newPosition);
        }

        protected override void OnChildBoundsChanged(Core.IDiagramItem diagramItem)
        {
            if (this.IsNotUserInteration())
                base.OnChildBoundsChanged(diagramItem);
        }

        protected override void OnIsInEditModeChanged(bool oldIsInEditMode, bool isInEditMode)
        {
            base.OnIsInEditModeChanged(oldIsInEditMode, isInEditMode);
            if (this.editPopup == null) return;

            if (isInEditMode)
            {
                this.editPopup.IsOpen = true;
            }
            else
            {
                this.editPopup.IsOpen = false;
            }
        }

        protected override Rect CalculateContentBounds(Rect shapeBounds)
        {
            return this.GetNewContentBounds(shapeBounds);
        }

        protected override Rect CalculateShapeBounds(Rect contentBounds)
        {
            if (this.headerElement == null) return contentBounds;

            var shapeBounds = this.GetShapeBounds(contentBounds);
            this.SetEditElementPosition(shapeBounds.Height);

            return shapeBounds;
        }

        protected override void OnIsCollapsedChanged(bool newValue, bool oldValue)
        {
            if (this.Orientation == Orientation.Vertical)
            {
                base.OnIsCollapsedChanged(newValue, oldValue);
            }
            else
            {
                if (newValue)
                {
                    var tmpMinHeight = this.MinHeight;
                    var tmpHeight = this.Height;

                    base.OnIsCollapsedChanged(newValue, oldValue);

                    this.MinHeight = tmpMinHeight;
                    this.Height = tmpHeight;

                    if (this.MinWidth > 0)
                    {
                        this.restoredMinWidth = this.MinWidth;
                        this.SetValue(MinWidthProperty, MinWidthProperty.GetMetadata(typeof(FrameworkElement)).DefaultValue);
                    }

                    if (this.Width > 0)
                    {
                        this.restoredWidth = this.Width;
                        this.SetValue(WidthProperty, WidthProperty.GetMetadata(typeof(FrameworkElement)).DefaultValue);
                    }
                }
                else
                {
                    base.OnIsCollapsedChanged(newValue, oldValue);
                    this.Width = this.restoredWidth;
                    this.MinWidth = this.restoredMinWidth;
                }
            }
        }

        protected bool IsNotUserInteration()
        {
            return !this.Diagram.ServiceLocator.GetService<Core.IResizingService>().IsResizing &&
                   !this.Diagram.ServiceLocator.GetService<Core.IDraggingService>().IsDragging &&
                   !this.Diagram.ServiceLocator.GetService<Core.IRotationService>().IsRotating;
        }

        protected SwimlaneShapeBase GetSwimlane(DragDrop.DragEventArgs e)
        {
#if SILVERLIGHT
            var swimlane = e.Data as SwimlaneShapeBase;
#else
            var swimlane = (e.Data as DataObject).GetData(typeof(SwimlaneShapeBase)) as SwimlaneShapeBase;
#endif
            if (swimlane == null)
            {
#if SILVERLIGHT
                var data = e.Data is DiagramDropInfo ? e.Data : null;
#else
                var data = (e.Data as DataObject).GetData(typeof(DiagramDropInfo));
#endif
                if (data != null)
                {
                    var dropInfo = (DiagramDropInfo)data;
                    var items = Core.SerializationService.Default.DeserializeItems(dropInfo.Info, true);
                    return items.FirstOrDefault(i => i is SwimlaneShapeBase) as SwimlaneShapeBase;
                }
            }

            return swimlane;
        }

        protected MainContainerShapeBase GetMainContainer(DragDrop.DragEventArgs e)
        {
#if SILVERLIGHT
            var mainContainer = e.Data as MainContainerShapeBase;
#else
            var mainContainer = (e.Data as DataObject).GetData(typeof(MainContainerShapeBase)) as MainContainerShapeBase;
#endif
            if (mainContainer == null)
            {
#if SILVERLIGHT
                var data = e.Data is DiagramDropInfo ? e.Data : null;
#else
                var data = (e.Data as DataObject).GetData(typeof(DiagramDropInfo));
#endif
                if (data != null)
                {
                    var dropInfo = (DiagramDropInfo)data;
                    var items = Core.SerializationService.Default.DeserializeItems(dropInfo.Info, true);
                    return items.FirstOrDefault(i => i is MainContainerShapeBase) as MainContainerShapeBase;
                }
            }

            return mainContainer;
        }

        protected Rect GetShapeBounds(Rect contentBounds)
        {
            if (this.headerElement == null) return contentBounds;

            double margin = Core.DiagramConstants.ContainerMargin;

            if (this.Orientation == Orientation.Vertical)
            {
                double headerOffset = this.headerElement != null ? this.headerElement.ActualHeight + this.headerElement.Margin.Top + this.headerElement.Margin.Bottom : 0;

                var width = Math.Max(0, contentBounds.Width + (2 * margin));
                var height = Math.Max(0, contentBounds.Height + (2 * margin) + headerOffset);
                var x = contentBounds.X - margin;
                var y = contentBounds.Y - margin - headerOffset;

                return new Rect(x, y, width, height);
            }
            else
            {
                double elementWidth = double.IsNaN(this.headerElement.Width) ? actualHeaderWidth : this.headerElement.Width;
                double headerWidth = double.IsNaN(elementWidth) ? this.headerElement.ActualWidth : elementWidth;
                headerWidth = Math.Round(headerWidth, 1);
                var width = contentBounds.Width + (2 * margin) + headerWidth;
                var height = contentBounds.Height + (2 * margin);
                var x = contentBounds.X - margin - headerWidth;
                var y = contentBounds.Y - margin;

                return new Rect(x, y, width, height);
            }
        }

        private void SetEditElementPosition(double height)
        {
#if SILVERLIGHT
            if (this.editHeaderElement == null) return;

            double offset = this.IsCollapsible ? 30 : 8;
            this.editPopup.Margin = new Thickness(0, (height / 2) - offset, 0, 0);
#endif
        }

        private void OnEditPopupKeyDown(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.Enter || e.Key == Key.Escape)
            {
                this.IsInEditMode = false;
            }
        }
    }
}
