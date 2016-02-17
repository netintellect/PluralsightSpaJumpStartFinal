using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Input;
using System.Windows.Media;

using Telerik.Windows.Controls;
using Telerik.Windows.Controls.Diagrams;

namespace Telerik.Windows.Diagrams.Features
{
	/// <summary>
	/// Represents a <see cref="Toolbox"/> item.
	/// </summary>
	public class ToolboxItem : HeaderedContentControl
	{
		/// <summary>
		/// 
		/// </summary>
		public static new readonly DependencyProperty IsVisibleProperty =
			DependencyProperty.Register("IsVisible", typeof(bool), typeof(ToolboxItem), new PropertyMetadata(false));

		private static SolidColorBrush MouseOverBrush = new SolidColorBrush(Color.FromArgb(255, 21, 172, 169));
		private bool isMouseOverItem;

#if WPF
		/// <summary>
		/// Initializes the <see cref="ToolboxItem"/> class.
		/// </summary>
		static ToolboxItem()
		{
			DefaultStyleKeyProperty.OverrideMetadata(typeof(ToolboxItem), new FrameworkPropertyMetadata(typeof(ToolboxItem)));
		}
#endif

		public ToolboxItem()
		{
#if SILVERLIGHT
			this.DefaultStyleKey = typeof(ToolboxItem);
#endif

			//// Check if this binding is properly cleaned.
			Binding binding = new Binding("IsVisible") { Mode = BindingMode.TwoWay, Source = this, Converter = new Telerik.Windows.Controls.BooleanToVisibilityConverter() };
			this.SetBinding(ToolboxItem.VisibilityProperty, binding);
		}

		/// <summary>
		/// Gets a value indicating whether this element is visible in the user interface (UI).
		/// </summary>
		/// <returns>true if the element is visible; otherwise, false.</returns>
		public new bool IsVisible
		{
			get { return (bool)GetValue(IsVisibleProperty); }
			set { SetValue(IsVisibleProperty, value); }
		}

        /// <summary>
        /// Gets or sets the shape.
        /// </summary>
        /// <value>
        /// The shape.
        /// </value>
        internal RadDiagramShape Shape { get; set; }

        /// <summary>
        /// Gets or sets a value indicating whether this instance is mouse over item.
        /// </summary>
        /// <value>
        /// 	<c>true</c> if this instance is mouse over item; otherwise, <c>false</c>.
        /// </value>
        internal bool IsMouseOverItem
        {
            get
            {
                return this.isMouseOverItem;
            }
            set
            {
                if (this.isMouseOverItem != value)
                {
                    this.isMouseOverItem = value;
                    this.UnpdateVisualStates();
                }
            }
        }

        /// <summary>
        /// Invoked when an unhandled <see cref="E:System.Windows.Input.Mouse.MouseEnter"/> attached event is raised on this element. Implement this method to add class handling for this event.
        /// </summary>
        /// <param name="e">The <see cref="T:System.Windows.Input.MouseEventArgs"/> that contains the event data.</param>
		protected override void OnMouseEnter(MouseEventArgs e)
		{
			base.OnMouseEnter(e);
			this.IsMouseOverItem = true;
		}

        /// <summary>
        /// Invoked when an unhandled <see cref="E:System.Windows.Input.Mouse.MouseLeave"/> attached event is raised on this element. Implement this method to add class handling for this event.
        /// </summary>
        /// <param name="e">The <see cref="T:System.Windows.Input.MouseEventArgs"/> that contains the event data.</param>
		protected override void OnMouseLeave(MouseEventArgs e)
		{
			base.OnMouseLeave(e);
			this.IsMouseOverItem = false;
		}

        /// <summary>
        /// Invoked when an unhandled <see cref="E:System.Windows.Input.Mouse.MouseMove"/> attached event reaches an element in its route that is derived from this class. Implement this method to add class handling for this event.
        /// </summary>
        /// <param name="e">The <see cref="T:System.Windows.Input.MouseEventArgs"/> that contains the event data.</param>
		protected override void OnMouseMove(MouseEventArgs e)
		{
			base.OnMouseMove(e);
			this.IsMouseOverItem = true;
		}

		private void UnpdateVisualStates()
		{
			VisualStateManager.GoToState(this, this.IsMouseOverItem ? "MouseOver" : "Normal", false);
		}
	}
}
