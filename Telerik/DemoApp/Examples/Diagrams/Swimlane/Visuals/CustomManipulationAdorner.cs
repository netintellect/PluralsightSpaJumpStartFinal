using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Windows;
using System.Windows.Controls;
using Telerik.Windows.Controls.Diagrams.Primitives;
using Telerik.Windows.Examples.Diagrams.Swimlane.Base;

namespace Telerik.Windows.Examples.Diagrams.Swimlane
{
    public class CustomManipulationAdorner : ManipulationAdorner
    {
        public static readonly DependencyProperty AdditionalResizeHandlersProperty =
            DependencyProperty.Register("AdditionalResizeHandlers", typeof(ObservableCollection<ResizeHandler>), typeof(CustomManipulationAdorner), new PropertyMetadata(null));

        public static readonly DependencyProperty AdditionalHandlersVisibilityProperty =
            DependencyProperty.Register("AdditionalHandlersVisibility", typeof(Visibility), typeof(CustomManipulationAdorner), new PropertyMetadata(Visibility.Collapsed));

        public ObservableCollection<ResizeHandler> AdditionalResizeHandlers
        {
            get { return (ObservableCollection<ResizeHandler>)GetValue(AdditionalResizeHandlersProperty); }
            set { SetValue(AdditionalResizeHandlersProperty, value); }
        }

        public Visibility AdditionalHandlersVisibility
        {
            get { return (Visibility)GetValue(AdditionalHandlersVisibilityProperty); }
            set { SetValue(AdditionalHandlersVisibilityProperty, value); }
        }

        public CustomManipulationAdorner()
            : base()
        {
            this.AdditionalResizeHandlers = new ObservableCollection<ResizeHandler>();
        }

        internal void UpdateAdditionalHandlers(List<SwimlaneShapeBase> containers, Point boundsPosition, bool isVisible, Orientation orientation)
        {
            int i = 0;
            if (isVisible && containers != null)
            {
                for (; i < containers.Count - 1; i++)
                {
                    var bounds = containers[i].Bounds;
                    bounds.X -= boundsPosition.X;
                    bounds.Y -= boundsPosition.Y;
                    Point position = new Point(bounds.Left + (bounds.Width / 2) - 3, bounds.Bottom - 3);
                    if (orientation == System.Windows.Controls.Orientation.Horizontal)
                        position = new Point(bounds.Right - 3, bounds.Top + (bounds.Height / 2) - 3);
                    if (double.IsNaN(position.X) || double.IsNaN(position.Y) ||
                        double.IsInfinity(position.X) || double.IsInfinity(position.Y))
                        continue;

                    ResizeHandler handler = null;
                    if (i < this.AdditionalResizeHandlers.Count)
                    {
                        handler = this.AdditionalResizeHandlers[i];
                    }
                    else
                    {
                        handler = new ResizeHandler();
                        this.AdditionalResizeHandlers.Add(handler);
                    }
                    handler.X = position.X;
                    handler.Y = position.Y;
                    handler.TopShape = containers[i];
                    handler.BottomShape = containers[i + 1];
                    handler.Orientation = orientation;
                    handler.Cursor = orientation == Orientation.Vertical ? System.Windows.Input.Cursors.SizeNS : System.Windows.Input.Cursors.SizeWE;
                }
            }

            for (int j = this.AdditionalResizeHandlers.Count - 1; j >= i; j--)
            {
                this.AdditionalResizeHandlers.RemoveAt(j);
            }
        }
    }
}
