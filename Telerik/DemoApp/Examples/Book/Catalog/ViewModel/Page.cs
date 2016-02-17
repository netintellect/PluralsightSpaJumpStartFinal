using System;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;
using System.ComponentModel;

namespace Telerik.Windows.Examples.Book.Catalog
{
	public class Page
	{
		private string imagePath;
		private int index;
		public string ImagePath
		{
			get
			{
				return this.imagePath;
			}
			set
			{
				this.imagePath = value;
			}
		}
		public int Index
		{
			get
			{
				return this.index;
			}
			set
			{
				this.index = value;
			}
		}
	}
}
