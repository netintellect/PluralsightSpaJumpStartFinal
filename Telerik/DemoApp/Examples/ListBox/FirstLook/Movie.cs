using System;

namespace Telerik.Windows.Examples.ListBox.FirstLook
{
	public class Movie
	{
		public string Name { get; set; }
		public string Description { get; set; }
		public string PathSource { get; set; }
		public Uri ImagePath { get; set; }
		public string Studio { get; set; }
		public int PathIconWidth { get; set; }
		public int PathIconHeight { get; set; }
		public int PathIconRotation { get; set; }
	}
}
