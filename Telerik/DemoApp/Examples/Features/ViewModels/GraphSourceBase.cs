using System.Collections;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using Telerik.Windows.Controls;
using Telerik.Windows.Diagrams.Core;

namespace Telerik.Windows.Diagrams.Features.ViewModels
{
    /// <summary>
    /// Base implementation of the <see cref="IGraphSource"/> which can be used to create MVVM sources for diagrams.
    /// </summary>
    /// <typeparam name="TNode">
    /// The data type of the node.
    /// </typeparam>
    /// <typeparam name="TLink">
    /// The data type of the link.
    /// </typeparam>
    public class GraphSourceBase<TNode, TLink> : ViewModelBase, IGraphSource
        where TLink : ILink
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="GraphSourceBase{TNode,TLink}"/> class.
        /// </summary>
        public GraphSourceBase()
        {
            this.InternalItems = new ObservableCollection<TNode>();
            this.InternalLinks = new ObservableCollection<TLink>();
        }

        /// <summary>
        /// Gets the internal items collection.
        /// </summary>
        public ObservableCollection<TNode> InternalItems { get; private set; }

        /// <summary>
        /// Gets the internal links collection.
        /// </summary>
        public ObservableCollection<TLink> InternalLinks { get; private set; }

        /// <summary>
        /// Gets Items.
        /// </summary>
        public IEnumerable Items
        {
            get
            {
                return this.InternalItems;
            }
        }

        /// <summary>
        /// Gets the links or connections of this diagram source.
        /// </summary>
        public IEnumerable<ILink> Links
        {
            get
            {
                return this.InternalLinks as IEnumerable<ILink>;
            }
        }

        /// <summary>
        /// Adds a node (shape) to this diagram source.
        /// </summary>
        /// <param name="node">
        /// The node to add.
        /// </param>
        public virtual void AddNode(TNode node)
        {
            this.InternalItems.Add(node);
        }

        /// <summary>
        /// Adds the given link to this diagram source.
        /// </summary>
        /// <param name="link">The link to add.</param>
        public virtual void AddLink(TLink link)
        {
            this.InternalLinks.Add(link);
        }
    }
}
