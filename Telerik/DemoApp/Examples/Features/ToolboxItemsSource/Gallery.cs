using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Collections.ObjectModel;

namespace Telerik.Windows.Diagrams.Features
{
	public class Gallery
	{
		private readonly ObservableCollection<GalleryItem> items;

        /// <summary>
        /// Initializes a new instance of the <see cref="Gallery"/> class.
        /// </summary>
		public Gallery()
		{
			this.items = new ObservableCollection<GalleryItem>();
		}

        /// <summary>
        /// Gets or sets the header.
        /// </summary>
        /// <value>
        /// The header.
        /// </value>
		public string Header { get; set; }

        /// <summary>
        /// Gets the items.
        /// </summary>
		public ObservableCollection<GalleryItem> Items
		{
			get
			{
				return this.items;
			}
		}
	}
}
