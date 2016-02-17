//#if WPF
using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows;
using System.Windows.Controls;
using Telerik.Windows.Controls;
using Telerik.Windows.Controls.Diagrams;
using Telerik.Windows.Diagrams.Core;
using Telerik.Windows.DragDrop;

//#endif
namespace Telerik.Windows.Diagrams.Features.ExpanderToolbox
{
    /// <summary>
    /// Holds a group of (diagram) items in the <see cref="DiagramToolbox"/>.
    /// </summary>
    //#if WPF
    // [Themable]
    //public class ToolboxGroup : HeaderedItemsControl, IThemable
    //#else
    public class ToolboxGroup : HeaderedItemsControl
    //#endif
    {
        /// <summary>
        /// 
        /// </summary>
        public static readonly DependencyProperty IsOpenProperty =
            DependencyProperty.Register("IsOpen", typeof(bool), typeof(ToolboxGroup), null);

        /// <summary>
        /// 
        /// </summary>
        public static readonly DependencyProperty ShapePathProperty =
            DependencyProperty.Register("ShapePath", typeof(string), typeof(ToolboxGroup), new PropertyMetadata(null));

        private readonly List<ToolboxItem> activeContainers;

#if WPF
        static ToolboxGroup()
        {
            DefaultStyleKeyProperty.OverrideMetadata(typeof(ToolboxGroup), new FrameworkPropertyMetadata(typeof(ToolboxGroup)));
        }
#endif

        /// <summary>
        /// Initializes a new instance of the <see cref="ToolboxGroup"/> class.
        /// </summary>
        public ToolboxGroup()
        {
#if !WPF
			this.DefaultStyleKey = typeof(ToolboxGroup);
#endif
            DragDropManager.SetAllowDrag(this, true);
            this.activeContainers = new List<ToolboxItem>();
        }

        /// <summary>
        /// Gets or sets a value indicating whether this instance is open.
        /// </summary>
        /// <value>
        ///   <c>true</c> if this instance is open; otherwise, <c>false</c>.
        /// </value>
        public bool IsOpen
        {
            get
            {
                return (bool)GetValue(IsOpenProperty);
            }
            set
            {
                SetValue(IsOpenProperty, value);
            }
        }

        /// <summary>
        /// Gets or sets the shape path.
        /// </summary>
        /// <value>
        /// The shape path.
        /// </value>
        public string ShapePath
        {
            get { return (string)GetValue(ShapePathProperty); }
            set { SetValue(ShapePathProperty, value); }
        }

        /// <summary>
        /// Gets or sets the toolbox.
        /// </summary>
        /// <value>
        /// The tool box.
        /// </value>
        internal DiagramToolbox ToolBox { get; set; }

        /// <summary>
        /// Provides a design-time value for the header if it is not set.
        /// </summary>
        public override void OnApplyTemplate()
        {
            base.OnApplyTemplate();
            this.InitializeDragAndDrop();
        }

#if WPF
        /// <summary>
        /// Resets the theme.
        /// </summary>
        public void ResetTheme()
        {
            this.SetDefaultStyleKey();
        }

        internal virtual void SetDefaultStyleKey()
        {
            var theme = StyleManager.GetTheme(this);
            this.DefaultStyleKey = ThemeResourceKey.GetDefaultStyleKey(theme, typeof(ToolboxGroup));
        }
#endif

        internal void SelectionChanged(ToolboxItem newSelectedItem)
        {
            foreach (var container in this.activeContainers.Where(container => container != newSelectedItem))
            {
                container.IsSelected = false;
            }
        }

#if WPF
        /// <summary>
        /// Raises the <see cref="E:System.Windows.FrameworkElement.Initialized"/> event. This method is invoked whenever <see cref="P:System.Windows.FrameworkElement.IsInitialized"/> is set to true internally.
        /// </summary>
        /// <param name="e">The <see cref="T:System.Windows.RoutedEventArgs"/> that contains the event data.</param>
        protected override void OnInitialized(System.EventArgs e)
        {
            base.OnInitialized(e);

            this.SetDefaultStyleKey();
        }
#endif

        /// <summary>
        /// Creates or identifies the element that is used to display the given item.
        /// </summary>
        /// <returns>
        /// The element that is used to display the given item.
        /// </returns>
        protected override DependencyObject GetContainerForItemOverride()
        {
            return new ToolboxItem();
        }

        /// <summary>
        /// Determines if the specified item is (or is eligible to be) its own container.
        /// </summary>
        /// <param name="item">The item to check.</param>
        /// <returns>
        /// true if the item is (or is eligible to be) its own container; otherwise, false.
        /// </returns>
        protected override bool IsItemItsOwnContainerOverride(object item)
        {
            return item is ToolboxItem;
        }

        /// <summary>
        /// Prepares the specified element to display the specified item.
        /// </summary>
        /// <param name="element">Element used to display the specified item.</param>
        /// <param name="item">Specified item.</param>
        protected override void PrepareContainerForItemOverride(DependencyObject element, object item)
        {
            base.PrepareContainerForItemOverride(element, item);
            var container = element as ToolboxItem;
            if (container != null)
            {
                container.ParentGroup = this;
                this.activeContainers.Add(container);

                if (this.ShapePath != null && item != null)
                {
                    var propertyInfo = item.GetType().GetProperty(this.ShapePath);
                    if (propertyInfo != null)
                        container.Shape = propertyInfo.GetValue(item, null) as RadDiagramShape;
                }
            }
        }

        /// <summary>
        /// Undoes the effects of the <see cref="M:System.Windows.Controls.ItemsControl.PrepareContainerForItemOverride(System.Windows.DependencyObject,System.Object)"/> method.
        /// </summary>
        /// <param name="element">The container element.</param>
        /// <param name="item">The item.</param>
        protected override void ClearContainerForItemOverride(DependencyObject element, object item)
        {
            base.ClearContainerForItemOverride(element, item);

            var container = element as ToolboxItem;
            if (container != null)
            {
                this.activeContainers.Remove(container);
            }
        }

        private void InitializeDragAndDrop()
        {
            DragDropManager.RemoveDragInitializeHandler(this, this.OnDragInitialized);

            DragDropManager.AddDragInitializeHandler(this, this.OnDragInitialized);
        }

        private void OnDragInitialized(object sender, DragInitializeEventArgs args)
        {
            var toolBoxItem = args.OriginalSource as ToolboxItem;
            if (toolBoxItem != null)
            {
                var serializer = new SerializationService(null);
                var shape = toolBoxItem.Shape;
                if (shape != null)
                {
                    args.Data = serializer.SerializeItems(new List<IDiagramItem> { shape as IDiagramItem });

                    args.DragVisualOffset = new Point(args.RelativeStartPoint.X - (shape.ActualWidth / 2), args.RelativeStartPoint.Y - (shape.ActualHeight / 2));

                    var draggingImage = new Image
                        {
                            Source = new Telerik.Windows.Media.Imaging.RadBitmap(shape).Bitmap,
                            Width = shape.ActualWidth,
                            Height = shape.ActualHeight
                        };
                    args.DragVisual = draggingImage;
                }
            }
            args.AllowedEffects = DragDropEffects.All;
            args.Handled = true;
        }
    }
}
