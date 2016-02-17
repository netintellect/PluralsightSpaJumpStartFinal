using System;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using Telerik.Windows.Examples.Diagrams.Swimlane.Base;

namespace Telerik.Windows.Examples.Diagrams.Swimlane
{
    public class ResizeHandler : Control
    {
        private Point? startPosition;
        private double topShapeStart;
        private double start;
        private double max;
        private double min;

        public ResizeHandler()
        {
        }

        protected override void OnMouseLeftButtonDown(MouseButtonEventArgs e)
        {
            base.OnMouseLeftButtonDown(e);

            this.TopShape.UpdateMinBounds();
            this.BottomShape.UpdateMinBounds();
            if (this.Orientation == System.Windows.Controls.Orientation.Vertical)
            {
                this.min = this.TopShape.MinBounds != Rect.Empty ? this.TopShape.MinBounds.Bottom : this.TopShape.Bounds.Top + CustomResizingService.MinShapeHeight;
                this.max = this.BottomShape.MinBounds != Rect.Empty ? this.BottomShape.MinBounds.Top : this.BottomShape.Bounds.Bottom - CustomResizingService.MinShapeHeight;
                this.topShapeStart = this.TopShape.Bounds.Bottom;
                this.start = this.Y;
            }
            else
            {
                this.min = this.TopShape.MinBounds != Rect.Empty ? this.TopShape.MinBounds.Right : this.TopShape.Bounds.Left + CustomResizingService.MinShapeWidth;
                this.max = this.BottomShape.MinBounds != Rect.Empty ? this.BottomShape.MinBounds.Left : this.BottomShape.Bounds.Right - CustomResizingService.MinShapeWidth;
                this.topShapeStart = this.TopShape.Bounds.Right;
                this.start = this.X;
            }

            this.CaptureMouse();
            this.startPosition = e.GetPosition(null);
            this.TopShape.IsInnerResize = true;
            this.BottomShape.IsInnerResize = true;

            e.Handled = true;
        }

        protected override void OnMouseLeftButtonUp(MouseButtonEventArgs e)
        {
            base.OnMouseLeftButtonUp(e);

            this.ReleaseMouseCapture();
            this.startPosition = null;
            this.TopShape.IsInnerResize = false;
            this.BottomShape.IsInnerResize = false;

            e.Handled = true;
        }

        protected override void OnMouseMove(MouseEventArgs e)
        {
            base.OnMouseMove(e);
            if (this.startPosition.HasValue)
            {
                var newPosition = e.GetPosition(null);
                if (this.Orientation == System.Windows.Controls.Orientation.Vertical)
                {
                    var offset = newPosition.Y - this.startPosition.Value.Y;
                    offset = Math.Max(offset, this.min - this.topShapeStart);
                    offset = Math.Min(offset, this.max - this.topShapeStart);

                    var topShapeBottom = this.topShapeStart + offset;

                    this.TopShape.Height = topShapeBottom - this.TopShape.Position.Y;

                    this.BottomShape.Height = this.BottomShape.Bounds.Bottom - topShapeBottom + this.BottomShape.BorderThickness.Top;
                    this.BottomShape.Position = new Point(this.BottomShape.Position.X, topShapeBottom - this.BottomShape.BorderThickness.Top);

                    this.Y = this.start + offset;
                }
                else
                {
                    var offset = newPosition.X - this.startPosition.Value.X;
                    offset = Math.Max(offset, this.min - this.topShapeStart);
                    offset = Math.Min(offset, this.max - this.topShapeStart);

                    var topShapeEnd = this.topShapeStart + offset;

                    this.TopShape.Width = topShapeEnd - this.TopShape.Position.X;

                    this.BottomShape.Width = this.BottomShape.Bounds.Right - topShapeEnd + this.BottomShape.BorderThickness.Left;
                    this.BottomShape.Position = new Point(topShapeEnd - this.BottomShape.BorderThickness.Left, this.BottomShape.Position.Y);

                    this.X = this.start + offset;
                }
            }
        }

        public double X
        {
            get
            {
                return Canvas.GetLeft(this);
            }
            set
            {
                Canvas.SetLeft(this, value);
            }
        }

        public double Y
        {
            get
            {
                return Canvas.GetTop(this);
            }
            set
            {
                Canvas.SetTop(this, value);
            }
        }

        public SwimlaneShapeBase TopShape { get; set; }

        public SwimlaneShapeBase BottomShape { get; set; }

        public Orientation Orientation { get; set; }
    }
}
