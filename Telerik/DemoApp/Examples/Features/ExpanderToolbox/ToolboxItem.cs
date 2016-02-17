using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using System.Windows.Media;
using Telerik.Windows.Diagrams.Core;
using Telerik.Windows.DragDrop;
using Telerik.Windows.Controls;
#if SILVERLIGHT
using Telerik.Windows.Controls;
#endif

namespace Telerik.Windows.Diagrams.Features.ExpanderToolbox
{
	/// <summary>
	/// Represents a <see cref="DiagramToolbox"/> item.
	/// </summary>
	public class ToolboxItem : HeaderedContentControl, ISupportMouseOver
	{
		/// <summary>
		/// The Label dependency property.
		/// </summary>
		public static readonly DependencyProperty LabelProperty =
		DependencyProperty.Register("Label", typeof(string), typeof(ToolboxItem), new PropertyMetadata(string.Empty));

		/// <summary>
		/// The Description dependency property.
		/// </summary>
		public static readonly DependencyProperty DescriptionProperty =
		DependencyProperty.Register("Description", typeof(string), typeof(ToolboxItem), new PropertyMetadata(string.Empty));

		/// <summary>
		/// The Image dependency property.
		/// </summary>
		public static readonly DependencyProperty ImageProperty =
		DependencyProperty.Register("Image", typeof(ImageSource), typeof(ToolboxItem), new PropertyMetadata(null));

		private bool isMouseOver;
		private bool isSelected;
		internal RadDiagramShape Shape { get; set; }

#if WPF
		static ToolboxItem()
		{
			DefaultStyleKeyProperty.OverrideMetadata(typeof(ToolboxItem), new FrameworkPropertyMetadata(typeof(ToolboxItem)));
		}
#endif

		/// <summary>
		/// Initializes a new instance of the <see cref="ToolboxItem"/> class.
		/// </summary>
		public ToolboxItem()
		{
#if !WPF
			this.DefaultStyleKey = typeof(ToolboxItem);
#endif
			DragDropManager.SetAllowDrag(this, true);
		}

		/// <summary>
		/// Gets (or sets, but see Remarks) the identifying name of the object. The name provides a reference that is initially markup-compiled. After a XAML processor creates the object tree from markup, run-time code can refer to a markup element by this name.
		/// </summary>
		/// <returns>The name of the object, which must be a string that is valid in the XamlName Grammar. The default is an empty string.</returns>
		public string Label
		{
			get
			{
				return (string)GetValue(LabelProperty);
			}
			set
			{
				SetValue(LabelProperty, value);
			}
		}

		/// <summary>
		/// Gets or sets the description.
		/// </summary>
		/// <value>
		/// The description.
		/// </value>
		public string Description
		{
			get
			{
				return (string)GetValue(DescriptionProperty);
			}
			set
			{
				SetValue(DescriptionProperty, value);
			}
		}

		/// <summary>
		/// Gets or sets the image.
		/// </summary>
		/// <value>
		/// The image.
		/// </value>
		public ImageSource Image
		{
			get
			{
				return (ImageSource)GetValue(ImageProperty);
			}
			set
			{
				SetValue(ImageProperty, value);
			}
		}

		/// <summary>
		/// Gets or sets a value indicating whether this instance is mouse over.
		/// </summary>
		/// <value>
		/// 	<c>True</c> if this instance is mouse over; otherwise, <c>false</c>.
		/// </value>
		public
#if WPF
 new
#endif
 bool IsMouseOver
		{
			get
			{
				return this.isMouseOver;
			}
			set
			{
				if (this.isMouseOver != value)
				{
					this.isMouseOver = value;
					this.UpdateMouseOverVisualState();
				}
			}
		}

		/// <summary>
		/// Gets or sets a value indicating whether this instance is selected.
		/// </summary>
		/// <value>
		/// 	<c>true</c> if this instance is selected; otherwise, <c>false</c>.
		/// </value>
		internal bool IsSelected
		{
			get
			{
				return this.isSelected;
			}
			set
			{
				if (this.isSelected != value)
				{
					this.isSelected = value;
					this.UpdateSelectedVisualState();
					if (this.isSelected && this.ParentGroup != null)
						this.ParentGroup.SelectionChanged(this);
				}
			}
		}

		/// <summary>
		/// The parent group in the toolbox.
		/// </summary>
		internal ToolboxGroup ParentGroup { get; set; }

		/// <summary>
		/// Invoked when an unhandled <see cref="E:System.Windows.Input.Mouse.MouseMove" /> attached
		/// event reaches an element in its route that is derived from this class. Implement
		/// this method to add class handling for this event.
		/// </summary>
		/// <param name="e">The <see cref="T:System.Windows.Input.MouseEventArgs" /> that
		/// contains the event data.</param>
		protected override void OnMouseMove(MouseEventArgs e)
		{
			base.OnMouseMove(e);
			this.IsMouseOver = true;
		}

		/// <summary>
		/// Invoked when an unhandled <see cref="E:System.Windows.Input.Mouse.MouseLeave" /> attached
		/// event is raised on this element. Implement this method to add class handling
		/// for this event.
		/// </summary>
		/// <param name="e">The <see cref="T:System.Windows.Input.MouseEventArgs" /> that
		/// contains the event data.</param>
		protected override void OnMouseLeave(MouseEventArgs e)
		{
			base.OnMouseLeave(e);
			this.IsMouseOver = false;
		}

		/// <summary>
		/// Called before the <see cref="E:System.Windows.UIElement.MouseLeftButtonDown"/> event occurs.
		/// </summary>
		/// <param name="e">The data for the event.</param>
		protected override void OnMouseLeftButtonDown(MouseButtonEventArgs e)
		{
			base.OnMouseLeftButtonDown(e);
			this.IsSelected = true;
		}

		private void UpdateMouseOverVisualState()
		{
			VisualStateManager.GoToState(this, this.IsMouseOver ? "MouseEnter" : "MouseLeave", false);
		}

		private void UpdateSelectedVisualState()
		{
			VisualStateManager.GoToState(this, this.IsSelected ? "Selected" : "Unselected", false);
		}
	}
}
