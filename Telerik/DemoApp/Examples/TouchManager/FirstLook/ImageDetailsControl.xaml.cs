using System;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;
using Telerik.Windows.Input.Touch;

namespace Telerik.Windows.Examples.TouchManager.FirstLook
{
    public partial class ImageDetailsControl : UserControl
    {
        private int pinchStartWidth;
        private int pinchStartHeight;

        public static readonly DependencyProperty ImageSourceProperty = DependencyProperty.Register(
            "ImageSource",
            typeof(ImageSource),
            typeof(ImageDetailsControl),
            new PropertyMetadata(ImageSourceChanged));

        public static readonly DependencyProperty ImageBackgroundProperty = DependencyProperty.Register(
            "ImageBackground",
            typeof(Brush),
            typeof(ImageDetailsControl),
            new PropertyMetadata());

        public ImageDetailsControl()
        {
            InitializeComponent();

            this.canvasDetails.SizeChanged += this.CanvasDetails_SizeChanged;

            Telerik.Windows.Input.Touch.TouchManager.AddPinchStartedEventHandler(this.canvasDetails, this.CanvasDetails_PinchStarted);
            Telerik.Windows.Input.Touch.TouchManager.AddPinchEventHandler(this.canvasDetails, this.CanvasDetails_Pinch);
            Telerik.Windows.Input.Touch.TouchManager.AddPinchFinishedEventHandler(this.canvasDetails, this.CanvasDetails_PinchFinished);

            Telerik.Windows.Input.Touch.TouchManager.AddTapEventHandler(this.canvasDetails, this.CanvasDetails_Tap);
        }

        private void CanvasDetails_SizeChanged(object sender, SizeChangedEventArgs e)
        {
            this.canvasDetails.Clip = new System.Windows.Media.RectangleGeometry { Rect = new System.Windows.Rect(0, 0, this.canvasDetails.ActualWidth, this.canvasDetails.ActualHeight) };
        }

        public ImageSource ImageSource
        {
            get { return (ImageSource)GetValue(ImageSourceProperty); }
            set { SetValue(ImageSourceProperty, value); }
        }

        public Brush ImageBackground
        {
            get { return (Brush)GetValue(ImageBackgroundProperty); }
            set { SetValue(ImageBackgroundProperty, value); }
        }

        private void CanvasDetails_PinchStarted(object sender, PinchEventArgs args)
        {
            args.Handled = true;

            this.pinchStartWidth = (int)this.imageDetails.Width;
            this.pinchStartHeight = (int)this.imageDetails.Height;

            this.RaiseGestureChanged("Pinch");
        }

        private void CanvasDetails_Pinch(object sender, PinchEventArgs args)
        {
            args.Handled = true;

            this.DoPinch(args.Factor);
        }

        private void CanvasDetails_PinchFinished(object sender, PinchEventArgs args)
        {
            args.Handled = true;
        }

        private void CanvasDetails_Tap(object sender, TapEventArgs args)
        {
            this.ImageSource = null;
            this.RaiseGestureChanged("Tap");
        }

        private void DoPinch(double factor)
        {
            double newWidth = (int)this.pinchStartWidth * factor;

            if (newWidth < 300 || 4500 < newWidth)
            {
                return;
            }

            double xDiff = newWidth - this.imageDetails.Width;
            this.imageDetails.Width = newWidth;
            Canvas.SetLeft(this.imageDetails, Canvas.GetLeft(this.imageDetails) - (xDiff / 2));

            double newHeight = (int)this.pinchStartHeight * factor;
            double yDiff = newHeight - this.imageDetails.Height;
            this.imageDetails.Height = newHeight;
            Canvas.SetTop(this.imageDetails, Canvas.GetTop(this.imageDetails) - (yDiff / 2));
        }

        private static void ImageSourceChanged(DependencyObject target, DependencyPropertyChangedEventArgs args)
        {
            var detailsControl = (ImageDetailsControl)target;
            detailsControl.OnImageSourceChanged();
        }

        private void OnImageSourceChanged()
        {
            this.imageDetails.Source = this.ImageSource;
            this.imageDetails.Width = this.ActualWidth;
            this.imageDetails.Height = this.ActualHeight;
            Canvas.SetLeft(this.imageDetails, 0);
            Canvas.SetTop(this.imageDetails, 0);

            if (this.ImageSource != null)
            {
                this.canvasDetails.Background = this.ImageBackground;
            }
            else
            {
                this.canvasDetails.Background = null;
            }
        }

        private static double CalculateDistance(Point position1, Point position2)
        {
            return Math.Sqrt(Math.Pow(position1.X - position2.X, 2) + Math.Pow(position1.Y - position2.Y, 2));
        }

        private void RaiseGestureChanged(string gestureName)
        {
            GestureChangedEventArgs newEventArgs = new GestureChangedEventArgs(gestureName);
            this.RaiseEvent(newEventArgs);
        }
    }
}
