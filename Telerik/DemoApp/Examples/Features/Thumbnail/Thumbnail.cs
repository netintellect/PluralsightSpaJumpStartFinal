using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using Telerik.Windows.Diagrams.Core;
using Telerik.Windows.Controls;
using Telerik.Windows.Controls.Diagrams;

namespace Telerik.Windows.Diagrams.Features
{
	/// <summary>
	/// </summary>
	public class Thumbnail : Control
	{
		/// <summary>
		/// Identifies the Diagram dependency property.
		/// </summary>
		public static readonly DependencyProperty DiagramProperty =
			DependencyPropertyExtensions.Register("Diagram", typeof(RadDiagram), typeof(Thumbnail), new PropertyMetadata(null, OnDiagramPropertyChanged));

		/// <summary>
		/// Identifies the Zoom dependency property.
		/// </summary>
		public static readonly DependencyProperty ZoomProperty =
			DependencyPropertyExtensions.Register("Zoom", typeof(double), typeof(Thumbnail), new PropertyMetadata(1d, OnZoomPropertyChanged, OnZoomCoerced));

		/// <summary>
		/// Identifies the ViewportSize dependency property.
		/// </summary>
		public static readonly DependencyProperty ViewportSizeProperty =
			DependencyPropertyExtensions.Register("ViewportSize", typeof(Size), typeof(Thumbnail), new PropertyMetadata(new Size(), OnViewportSizPropertyChanged));

		/// <summary>
		/// Identifies the ViewportPosition dependency property.
		/// </summary>
		public static readonly DependencyProperty ViewportPositionProperty =
			DependencyPropertyExtensions.Register("ViewportPosition", typeof(Point), typeof(Thumbnail), new PropertyMetadata(new Point(), OnViewportPositionPropertyChanged));

		/// <summary>
		/// Identifies the BackgroundBrush dependency property.
		/// </summary>
		public static readonly DependencyProperty BackgroundBrushProperty =
			DependencyPropertyExtensions.Register("BackgroundBrush", typeof(Brush), typeof(Thumbnail), new PropertyMetadata(null));

		private const string PARTViewportRect = "viewportRect";
		private const string PARTThumbnailSurface = "thumbnailSurface";

		private FrameworkElement viewportRect;
		private FrameworkElement thumbnailSurface;

		private Size diagramSize;
		private Rect shapesBounds;
		private Point dragStartPoint;
		private Point positionOnDragStart;
		private bool isDragging;
		private bool isLeftButtonDown;
		private bool isCreatingImage;
		private bool itemsChanged;
#if WPF
		static Thumbnail()
		{
			DefaultStyleKeyProperty.OverrideMetadata(typeof(Thumbnail), new FrameworkPropertyMetadata(typeof(Thumbnail)));
		}

#endif
		/// <summary>
		/// Initializes a new instance of the <see cref="Thumbnail" /> class.
		/// </summary>
		public Thumbnail()
		{
#if SILVERLIGHT
			DefaultStyleKey = typeof(Thumbnail);
#endif
		}

		public event EventHandler<Telerik.Windows.Diagrams.Core.PositionChangedEventArgs> ViewportPositionChanged;

		/// <summary>
		/// Gets or sets the background brush.
		/// </summary>
		/// <value>The background brush.</value>
		public Brush BackgroundBrush
		{
			get { return (Brush)GetValue(BackgroundBrushProperty); }
			set { SetValue(BackgroundBrushProperty, value); }
		}

		/// <summary>
		/// Gets or sets the viewport position.
		/// </summary>
		/// <value>The viewport position.</value>
		public Point ViewportPosition
		{
			get { return (Point)GetValue(ViewportPositionProperty); }
			set { SetValue(ViewportPositionProperty, value); }
		}

		/// <summary>
		/// Gets or sets the size of the viewport.
		/// </summary>
		/// <value>The size of the viewport.</value>
		public Size ViewportSize
		{
			get { return (Size)GetValue(ViewportSizeProperty); }
			set { SetValue(ViewportSizeProperty, value); }
		}

		/// <summary>
		/// Gets or sets the zoom.
		/// </summary>
		/// <value>The zoom.</value>
		public double Zoom
		{
			get { return (double)GetValue(ZoomProperty); }
			set { SetValue(ZoomProperty, value); }
		}

		/// <summary>
		/// Gets or sets the diagram.
		/// </summary>
		/// <value>The diagram.</value>
		public RadDiagram Diagram
		{
			get { return (RadDiagram)GetValue(DiagramProperty); }
			set { SetValue(DiagramProperty, value); }
		}

		/// <summary>
		/// When overridden in a derived class, is invoked whenever application
		/// code or internal processes (such as a rebuilding layout pass) call <see cref="M:System.Windows.Controls.Control.ApplyTemplate" />.
		/// In simplest terms, this means the method is called just before a UI element displays
		/// in an application. For more information, see Remarks.
		/// </summary>
		public override void OnApplyTemplate()
		{
			base.OnApplyTemplate();

			this.viewportRect = this.GetTemplateChild(PARTViewportRect) as FrameworkElement;
			this.thumbnailSurface = this.GetTemplateChild(PARTThumbnailSurface) as FrameworkElement;

			if (this.viewportRect != null)
			{
				this.viewportRect.Width = this.ViewportSize.Width;
				this.viewportRect.Height = this.ViewportSize.Height;
				Canvas.SetLeft(this.viewportRect, this.ViewportPosition.X);
				Canvas.SetTop(this.viewportRect, this.ViewportPosition.Y);
			}
		}

		/// <summary>
		/// Updates the viewport size and position.
		/// </summary>
		public void UpdateViewportSizeAndPosition()
		{
			if (this.isLeftButtonDown || this.isCreatingImage || this.thumbnailSurface == null)
				return;

			double shapesBoundsSize = Math.Max(this.shapesBounds.Width, this.shapesBounds.Height);
			double viewportWidth = this.thumbnailSurface.ActualWidth * (this.diagramSize.Width / shapesBoundsSize) / this.Zoom;
			double viewportHeight = this.thumbnailSurface.ActualHeight * (this.diagramSize.Height / shapesBoundsSize) / this.Zoom;
			if (viewportHeight >= 0 && viewportWidth >= 0 &&
				!double.IsInfinity(viewportWidth) && !double.IsInfinity(viewportHeight))
				this.ViewportSize = new Size(viewportWidth, viewportHeight);

			double viewPortOffsetX = (this.Diagram.Viewport.X - this.shapesBounds.X) / (shapesBoundsSize / this.thumbnailSurface.ActualWidth);
			double viewPortOffsetY = (this.Diagram.Viewport.Y - this.shapesBounds.Y) / (shapesBoundsSize / this.thumbnailSurface.ActualHeight);
			if (!double.IsInfinity(viewPortOffsetX) && !double.IsInfinity(viewPortOffsetY))
				this.ViewportPosition = new Point(viewPortOffsetX, viewPortOffsetY);
		}

		/// <summary>
		/// Called before the <see cref="E:System.Windows.UIElement.MouseLeftButtonDown" />
		/// event occurs.
		/// </summary>
		/// <param name="e">The data for the event.</param>
		protected override void OnMouseLeftButtonDown(System.Windows.Input.MouseButtonEventArgs e)
		{
			base.OnMouseLeftButtonDown(e);
			this.dragStartPoint = e.GetPosition(this);
			this.isLeftButtonDown = true;
			if (!new Rect(this.ViewportPosition, this.ViewportSize).Contains(this.dragStartPoint))
			{
				this.ViewportPosition = new Point(this.dragStartPoint.X - (this.ViewportSize.Width / 2), this.dragStartPoint.Y - (this.ViewportSize.Height / 2));
				this.RaiseDiagramPositionChanged();
			}
			this.positionOnDragStart = this.ViewportPosition;

			e.Handled = true;
		}

		/// <summary>
		/// Called before the <see cref="E:System.Windows.UIElement.MouseLeftButtonUp" />
		/// event occurs.
		/// </summary>
		/// <param name="e">The data for the event.</param>
		protected override void OnMouseLeftButtonUp(System.Windows.Input.MouseButtonEventArgs e)
		{
			base.OnMouseLeftButtonUp(e);
			this.isLeftButtonDown = false;
			this.isDragging = false;
			this.ReleaseMouseCapture();

			e.Handled = true;
		}

		/// <summary>
		/// Called before the <see cref="E:System.Windows.UIElement.MouseMove" />
		/// event occurs.
		/// </summary>
		/// <param name="e">The data for the event.</param>
		protected override void OnMouseMove(System.Windows.Input.MouseEventArgs e)
		{
			base.OnMouseMove(e);
			if (this.isLeftButtonDown)
			{
				var currentMousePosition = e.GetPosition(this);
				double offsetX = currentMousePosition.X - this.dragStartPoint.X;
				double offsetY = currentMousePosition.Y - this.dragStartPoint.Y;
				if (this.isDragging)
				{
					this.ViewportPosition = new Point(this.positionOnDragStart.X + offsetX, this.positionOnDragStart.Y + offsetY);
					this.RaiseDiagramPositionChanged();
				}
				else if (Math.Abs(offsetX) > 2 || Math.Abs(offsetY) > 2)
				{
					this.isDragging = true;
					this.CaptureMouse();
				}
			}
		}

		/// <summary>
		/// Called before the <see cref="E:System.Windows.UIElement.MouseWheel" />
		/// event occurs to provide handling for the event in a derived class without attaching
		/// a delegate.
		/// </summary>
		/// <param name="e">A <see cref="T:System.Windows.Input.MouseWheelEventArgs" /> that
		/// contains the event data.</param>
		protected override void OnMouseWheel(System.Windows.Input.MouseWheelEventArgs e)
		{
			base.OnMouseWheel(e);

			double newSize = Math.Max(this.shapesBounds.Width, this.shapesBounds.Height);
			Point zoomPoint = e.GetPosition(this.viewportRect);
			var newPoint = new Point(zoomPoint.X * (newSize / this.thumbnailSurface.ActualWidth) * this.Zoom, zoomPoint.Y * (newSize / this.thumbnailSurface.ActualHeight) * this.Zoom);
			if (e.Delta > 0)
			{
				this.Zoom += DiagramConstants.ZoomFactor;
				this.Diagram.ZoomIn(DiagramConstants.ZoomFactor, newPoint);
			}
			else
			{
				this.Zoom -= DiagramConstants.ZoomFactor;
				this.Diagram.ZoomOut(DiagramConstants.ZoomFactor, newPoint);
			}

			e.Handled = true;
		}

		private static void OnViewportPositionPropertyChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
		{
			var thumbnail = d as Thumbnail;
			if (thumbnail != null && thumbnail.viewportRect != null)
			{
				Point newValue = (Point)e.NewValue;
				if (!double.IsNaN(newValue.X))
				{
					Canvas.SetLeft(thumbnail.viewportRect, newValue.X);
				}
				if (!double.IsNaN(newValue.Y))
				{
					Canvas.SetTop(thumbnail.viewportRect, newValue.Y);
				}
			}
		}

		private static object OnZoomCoerced(DependencyObject element, object baseValue)
		{
			var zoom = Convert.ToDouble(baseValue);
			if (zoom < DiagramConstants.MinimumZoom) zoom = DiagramConstants.MinimumZoom;
			if (zoom > DiagramConstants.MaximumZoom) zoom = DiagramConstants.MaximumZoom;
			return zoom;
		}

		private static void OnZoomPropertyChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
		{
			var thumbnail = d as Thumbnail;
			if (thumbnail != null)
			{
				thumbnail.UpdateViewportSizeAndPosition();
			}
		}

		private static void OnViewportSizPropertyChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
		{
			var thumbnail = d as Thumbnail;
			if (thumbnail != null && thumbnail.viewportRect != null)
			{
				Size newValue = (Size)e.NewValue;
				thumbnail.viewportRect.Width = newValue.Width;
				thumbnail.viewportRect.Height = newValue.Height;
			}
		}

		private static void OnDiagramPropertyChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
		{
			var thumbnail = d as Thumbnail;
			if (thumbnail != null)
			{
				thumbnail.OnDiagramChanged((RadDiagram)e.OldValue, (RadDiagram)e.NewValue);
			}
		}

		private void OnDiagramChanged(RadDiagram oldDiagram, RadDiagram newDiagram)
		{
			if (oldDiagram != null)
			{
				newDiagram.SizeChanged -= this.OnDiagramSizeChanged;
				newDiagram.Rotate -= this.OnDiagramRotate;
				newDiagram.Drag -= this.OnDiagramDrag;
				newDiagram.Resize -= this.OnDiagramResize;
				newDiagram.Loaded -= this.OnDiagramLoaded;
				newDiagram.ItemsChanged -= this.OnDiagramItemsChanged;
				newDiagram.LayoutUpdated -= this.OnDiagramLayoutUpdated;
				newDiagram.ZoomChanged -= this.OnDiagramZoomChanged;
				newDiagram.ViewportChanged -= this.OnDiagramViewportChanged;
			}

			if (newDiagram != null)
			{
				newDiagram.SizeChanged += this.OnDiagramSizeChanged;
				newDiagram.Rotate += this.OnDiagramRotate;
				newDiagram.Drag += this.OnDiagramDrag;
				newDiagram.Resize += this.OnDiagramResize;
				newDiagram.Loaded += this.OnDiagramLoaded;
				newDiagram.ItemsChanged += this.OnDiagramItemsChanged;
				newDiagram.LayoutUpdated += this.OnDiagramLayoutUpdated;
				newDiagram.ZoomChanged += this.OnDiagramZoomChanged;
				newDiagram.ViewportChanged += this.OnDiagramViewportChanged;
			}
		}

		private void OnDiagramLoaded(object sender, RoutedEventArgs e)
		{
			this.OnVisualChange();
			this.UpdateViewportSizeAndPosition();
		}

		private void OnDiagramResize(object sender, ResizeRoutedEventArgs e)
		{
			this.OnVisualChange();
			this.UpdateViewportSizeAndPosition();
		}

		private void OnDiagramDrag(object sender, DragRoutedEventArgs e)
		{
			this.OnVisualChange();
			this.UpdateViewportSizeAndPosition();
		}

		private void OnDiagramRotate(object sender, RotateRoutedEventArgs e)
		{
			this.OnVisualChange();
			this.UpdateViewportSizeAndPosition();
		}

		private void OnDiagramLayoutUpdated(object sender, EventArgs e)
		{
			if (itemsChanged)
			{
				this.OnVisualChange();
				this.UpdateViewportSizeAndPosition();
			}
			itemsChanged = false;
		}

		private void OnDiagramZoomChanged(object sender, ZoomRoutedEventArgs e)
		{
			this.Zoom = e.NewZoom;
		}

		private void OnDiagramViewportChanged(object sender, ViewportRoutedEventArgs e)
		{
			this.UpdateViewportSizeAndPosition();
		}

		private void OnDiagramItemsChanged(object sender, DiagramItemsChangedEventArgs e)
		{
			itemsChanged = true;
		}

		private void OnVisualChange()
		{
			if (this.Diagram == null)
				return;

			var enclosingBounds = Rect.Empty;
			foreach (var item in this.Diagram.Shapes)
			{
				enclosingBounds.Union(item.ActualBounds);
			}
			foreach (var item in this.Diagram.Connections)
			{
				enclosingBounds.Union(item.Bounds);
			}
			this.shapesBounds = enclosingBounds;

			double imageWidth = Math.Max(0, Math.Max(enclosingBounds.Width, enclosingBounds.Height));
			if (imageWidth > 0)
			{
				this.isCreatingImage = true;
				bool shouldShow = false;
				if (this.Diagram.IsBackgroundSurfaceVisible)
				{
					shouldShow = true;
					this.Diagram.IsBackgroundSurfaceVisible = false;
				}
				this.Diagram.IsInformationAdornerVisible = false;
				this.Diagram.IsManipulationAdornerVisible = false;
				this.BackgroundBrush = new ImageBrush() { ImageSource = this.Diagram.CreateDiagramImage(new Rect(enclosingBounds.TopLeft(), new Size(imageWidth, imageWidth))) };
				this.Diagram.IsManipulationAdornerVisible = true;
				this.Diagram.IsInformationAdornerVisible = true;
				if (shouldShow)
				{
					this.Diagram.IsBackgroundSurfaceVisible = true;
				}
				this.isCreatingImage = false;
			}
		}

		private void OnDiagramSizeChanged(object sender, SizeChangedEventArgs e)
		{
			if (!this.isCreatingImage)
			{
				this.diagramSize = e.NewSize;
				this.UpdateViewportSizeAndPosition();
			}
		}

		private void RaiseDiagramPositionChanged()
		{
			if (this.ViewportPositionChanged != null)
			{
				this.ViewportPositionChanged(this, new Telerik.Windows.Diagrams.Core.PositionChangedEventArgs(new Point(), this.ConvertToDiagramPoint(this.ViewportPosition), null));
			}
		}

		private Point ConvertToDiagramPoint(Point thumbnailPoint)
		{
			double newSize = Math.Max(this.shapesBounds.Width, this.shapesBounds.Height);

			double offsetX = ((thumbnailPoint.X * (newSize / this.thumbnailSurface.ActualWidth)) + this.shapesBounds.X) * this.Zoom;
			double offsetY = ((thumbnailPoint.Y * (newSize / this.thumbnailSurface.ActualHeight)) + this.shapesBounds.Y) * this.Zoom;
			double diagramX = offsetX - ((this.Diagram.Viewport.X * this.Zoom) + this.Diagram.PositionX);
			double diagramY = offsetY - ((this.Diagram.Viewport.Y * this.Zoom) + this.Diagram.PositionY);

			return new Point(diagramX, diagramY);
		}
	}
}
