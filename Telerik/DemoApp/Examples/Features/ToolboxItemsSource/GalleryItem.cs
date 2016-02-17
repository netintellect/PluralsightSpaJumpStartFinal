using System;
using System.Linq;
using Telerik.Windows.Controls;

namespace Telerik.Windows.Diagrams.Features
{
	public class GalleryItem
	{
		public GalleryItem()
			: this(string.Empty, new RadDiagramShape(), string.Empty)
		{ }

		public GalleryItem(string header, RadDiagramShape shape)
			: this(header, shape, string.Empty)
		{ }

		public GalleryItem(string header, RadDiagramShape shape, string type)
		{
			this.Header = header;
			this.Shape = shape;
			this.ItemType = type;
		}

        /// <summary>
        /// Gets or sets the header.
        /// </summary>
        /// <value>
        /// The header.
        /// </value>
		public string Header { get; private set; }

        /// <summary>
        /// Gets or sets the type of the item.
        /// </summary>
        /// <value>
        /// The type of the item.
        /// </value>
        public string ItemType { get; private set; }

        /// <summary>
        /// Gets or sets the shape.
        /// </summary>
        /// <value>
        /// The shape.
        /// </value>
        public RadDiagramShape Shape { get; private set; }
	}
}
