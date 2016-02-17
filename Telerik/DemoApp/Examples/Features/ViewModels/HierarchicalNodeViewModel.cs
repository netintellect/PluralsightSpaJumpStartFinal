using System;
using System.Linq;
using Telerik.Windows.Data;

namespace Telerik.Windows.Diagrams.Features.ViewModels
{
	/// <summary>
	/// MVVM representation of a hierarchical node.
	/// </summary>
	public class HierarchicalNodeViewModel : NodeViewModelBase
	{
		private readonly RadObservableCollection<HierarchicalNodeViewModel> children;

		/// <summary>
		/// Initializes a new instance of the <see cref="HierarchicalNodeViewModel" /> class.
		/// </summary>
		public HierarchicalNodeViewModel()
		{
			this.children = new RadObservableCollection<HierarchicalNodeViewModel>();
		}

		/// <summary>
		/// Gets or sets the children of the current node.
		/// </summary>
		/// <value>The children.</value>
		public RadObservableCollection<HierarchicalNodeViewModel> Children
		{
			get
			{
				return this.children;
			}
		}

		/// <summary>
		/// Gets a value indicating whether this instance has children.
		/// </summary>
		/// <value>
		/// 	<c>True</c> if this instance has children; otherwise, <c>false</c>.
		/// </value>
		public bool HasChildren
		{
			get
			{
				return this.Children.Count > 0;
			}
		}
	}
}
