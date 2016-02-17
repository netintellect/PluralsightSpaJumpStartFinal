using System;
using System.Windows.Controls;
using Telerik.Windows.Input.Touch;
#if WPF
using System.Windows;
#endif

namespace Telerik.Windows.Examples.TouchManager.FirstLook
{
    public delegate void GestureChangedEventHandler(object sender, GestureChangedEventArgs e);

    public partial class TouchGallery : UserControl
    {
        public static readonly RoutedEvent GestureChangedEvent = EventManager.RegisterRoutedEvent("GestureChanged",
            RoutingStrategy.Bubble,
            typeof(GestureChangedEventHandler),
            typeof(TouchGallery));

        private int columnsCount = 3;
        private int itemMargin = 4;
        private int offset;
        private bool isArrangeGalleryScheduled;
        private System.Windows.Point swipePivotPosition;
        private int swipePivotOffset;

        public TouchGallery()
        {
            InitializeComponent();

            Telerik.Windows.Input.Touch.TouchManager.AddSwipeStartedEventHandler(this.canvasGallery, this.CanvasGallery_SwipeStarted);
            Telerik.Windows.Input.Touch.TouchManager.AddSwipeEventHandler(this.canvasGallery, this.CanvasGallery_Swipe);
            Telerik.Windows.Input.Touch.TouchManager.AddSwipeFinishedEventHandler(this.canvasGallery, this.CanvasGallery_SwipeFinished);
            Telerik.Windows.Input.Touch.TouchManager.AddSwipeInertiaStartedEventHandler(this.canvasGallery, this.CanvasGallery_SwipeInertiaStarted);
            Telerik.Windows.Input.Touch.TouchManager.AddSwipeInertiaEventHandler(this.canvasGallery, this.CanvasGallery_SwipeInertia);
            Telerik.Windows.Input.Touch.TouchManager.AddSwipeInertiaFinishedEventHandler(this.canvasGallery, this.CanvasGallery_SwipeInertiaFinished);

            Telerik.Windows.Input.Touch.TouchManager.AddTapEventHandler(this.canvasGallery, this.CanvasGallery_Tap);

            this.canvasGallery.Loaded += this.CanvasGallery_Loaded;
            this.canvasGallery.SizeChanged += this.CanvasGallery_SizeChanged;
        }

        public event GestureChangedEventHandler GestureChanged
        {
            add { this.AddHandler(GestureChangedEvent, value); }
            remove { this.RemoveHandler(GestureChangedEvent, value); }
        }

        public int Offset
        {
            get
            {
                return this.offset;
            }
            set
            {
                if (this.offset != value)
                {
                    this.offset = value;
                    this.ScheduleArrangeGallery();
                }
            }
        }

        private void CanvasGallery_SwipeStarted(object sender, TouchEventArgs args)
        {
            args.Handled = true;

            this.swipePivotPosition = args.GetTouchPoint(this.canvasGallery).Position;
            this.swipePivotOffset = this.Offset;

            this.RaiseGestureChanged("Swipe");
        }

        private void CanvasGallery_Swipe(object sender, SwipeEventArgs args)
        {
            args.Handled = true;

            System.Windows.Point position = args.GetTouchPoint(this.canvasGallery).Position;
            this.DoSwipe(position);
        }

        private void CanvasGallery_SwipeFinished(object sender, TouchEventArgs args)
        {
            args.Handled = true;
        }

        private void CanvasGallery_SwipeInertiaStarted(object sender, RadRoutedEventArgs args)
        {
            args.Handled = true;

            this.RaiseGestureChanged("Swipe Inertia");
        }

        private void CanvasGallery_SwipeInertia(object sender, SwipeInertiaEventArgs args)
        {
            args.Handled = true;
            this.DoSwipe(args.Position);
        }

        private void CanvasGallery_SwipeInertiaFinished(object sender, RadRoutedEventArgs args)
        {
            args.Handled = true;
        }

        private void CanvasGallery_Tap(object sender, TapEventArgs args)
        {
            var image = args.OriginalSource as Image;
            if (image == null)
            {
                return;
            }

            this.DoTransitionToDetails(image);
            this.RaiseGestureChanged("Tap");
        }

        private void CanvasGallery_Loaded(object sender, System.Windows.RoutedEventArgs e)
        {
            this.ArrangeGallery();
        }

        private void CanvasGallery_SizeChanged(object sender, System.Windows.SizeChangedEventArgs e)
        {
            int minOffset = this.CalculateMinOffset();
            if (this.Offset < minOffset)
            {
                this.Offset = minOffset;
            }

            this.ArrangeGallery();
            this.ClipGallery();
        }

        private void ClipGallery()
        {
            this.canvasGallery.Clip = new System.Windows.Media.RectangleGeometry { Rect = new System.Windows.Rect(0, 0, this.canvasGallery.ActualWidth, this.canvasGallery.ActualHeight) };
        }

        private void DoSwipe(System.Windows.Point position)
        {
            int newOffset = this.swipePivotOffset + (int)(position.Y - this.swipePivotPosition.Y);
            int minOffset = this.CalculateMinOffset();
            newOffset = Math.Min(0, newOffset);
            newOffset = Math.Max(minOffset, newOffset);
            this.Offset = newOffset;
        }

        private void ScheduleArrangeGallery()
        {
            if (!this.isArrangeGalleryScheduled)
            {
                this.isArrangeGalleryScheduled = true;
                this.Dispatcher.BeginInvoke((Action)(() =>
                {
                    if (this.isArrangeGalleryScheduled)
                    {
                        this.ArrangeGallery();
                    }
                }));
            }
        }

        private void ArrangeGallery()
        {
            this.isArrangeGalleryScheduled = false;

            int galleryWidth = (int)this.canvasGallery.ActualWidth;
            int itemWidthWithMargin = galleryWidth / this.columnsCount;
            int itemWidth = itemWidthWithMargin - 2 * this.itemMargin;
            double ratio = 2.0 / 3.0;
            int itemHeight = (int)(ratio * itemWidth);
            int itemHeightWithMargin = itemHeight + 2 * this.itemMargin;
            int totalHeight = (int)(Math.Ceiling(((double)this.canvasGallery.Children.Count / this.columnsCount)) * itemHeightWithMargin);

            for (int i = 0; i < this.canvasGallery.Children.Count; i++)
            {
                var child = (System.Windows.FrameworkElement)this.canvasGallery.Children[i];
                int row = i / this.columnsCount;
                int col = i % this.columnsCount;

                double left = (col * itemWidthWithMargin) + this.itemMargin;
                Canvas.SetLeft(child, left);

                double top = this.offset;
                top += (row * itemHeightWithMargin) + this.itemMargin;
                Canvas.SetTop(child, top);

                child.Width = itemWidth;
                child.Height = itemHeight;
            }

            this.UpdateScrollIndicator((int)this.canvasGallery.ActualHeight, totalHeight);
        }

        private int CalculateMinOffset()
        {
            int galleryWidth = (int)this.canvasGallery.ActualWidth;
            int itemWidthWithMargin = galleryWidth / this.columnsCount;
            int itemWidth = itemWidthWithMargin - 2 * this.itemMargin;
            double ratio = 2.0 / 3.0;
            int itemHeight = (int)(ratio * itemWidth);
            int itemHeightWithMargin = itemHeight + 2 * this.itemMargin;

            int totalHeight = (int)(Math.Ceiling(((double)this.canvasGallery.Children.Count / this.columnsCount)) * itemHeightWithMargin);
            double minOffset = this.canvasGallery.ActualHeight - totalHeight;
            minOffset = Math.Min(0, minOffset);
            return (int)minOffset;
        }

        private void UpdateScrollIndicator(int galleryHeight, int totalHeight)
        {
            double scrollRange = galleryHeight / (double)totalHeight;
            this.scrollIndicator.Height = scrollRange * galleryHeight;
            double top = -this.Offset / (double)totalHeight;
            Canvas.SetTop(this.scrollIndicator, top * galleryHeight);
        }

        private void DoTransitionToDetails(Image image)
        {
            this.imageDetailsUC.ImageSource = image.Source;
        }

        internal void GoToHome()
        {
            this.imageDetailsUC.ImageSource = null;
            this.Offset = 0;
        }

        private void RaiseGestureChanged(string gestureName)
        {
            GestureChangedEventArgs newEventArgs = new GestureChangedEventArgs(gestureName);
            this.RaiseEvent(newEventArgs);
        }
    }
}
