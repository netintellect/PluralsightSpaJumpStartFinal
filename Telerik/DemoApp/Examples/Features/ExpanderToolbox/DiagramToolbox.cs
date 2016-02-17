using System.Linq;
using System.Windows;
using Telerik.Windows.Controls.Diagrams;
#if WPF
using System.Windows.Controls;
#else
using Telerik.Windows.Controls;
#endif

namespace Telerik.Windows.Diagrams.Features.ExpanderToolbox
{
	/// <summary>
	/// Custom listbox to collect droppable RadDiagram shapes and other diagram elements.
	/// </summary>
	/// <remarks>This instance will preload a set of geometric shapes.</remarks>
	public class DiagramToolbox : ItemsControl
	{
#if WPF
		/// <summary>
		/// Initializes the <see cref="DiagramToolbox"/> class.
		/// </summary>
		static DiagramToolbox()
		{
			DefaultStyleKeyProperty.OverrideMetadata(typeof(DiagramToolbox), new FrameworkPropertyMetadata(typeof(DiagramToolbox)));
		}
#endif

		/// <summary>
		/// Initializes a new instance of the <see cref="DiagramToolbox"/> class.
		/// </summary>
		public DiagramToolbox()
		{
#if !WPF
			this.DefaultStyleKey = typeof(DiagramToolbox);
#endif
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
			return item is ToolboxGroup;
		}

		/// <summary>
		/// Creates or identifies the element that is used to display the given item.
		/// </summary>
		/// <returns>
		/// The element that is used to display the given item.
		/// </returns>
		protected override DependencyObject GetContainerForItemOverride()
		{
			return new ToolboxGroup();
		}

		/// <summary>
		/// Prepares the specified element to display the specified item.
		/// </summary>
		/// <param name="element">Element used to display the specified item.</param>
		/// <param name="item">Specified item.</param>
		protected override void PrepareContainerForItemOverride(DependencyObject element, object item)
		{
			base.PrepareContainerForItemOverride(element, item);
			var group = element as ToolboxGroup;
			if (group != null) group.ToolBox = this;
		}

		/// <summary>
		/// Undoes the effects of the <see cref="M:System.Windows.Controls.ItemsControl.PrepareContainerForItemOverride(System.Windows.DependencyObject,System.Object)"/> method.
		/// </summary>
		/// <param name="element">The container element.</param>
		/// <param name="item">The item.</param>
		protected override void ClearContainerForItemOverride(DependencyObject element, object item)
		{
			base.ClearContainerForItemOverride(element, item);
			var group = element as ToolboxGroup;
			if (group != null) group.ToolBox = null;
		}
	}
}
