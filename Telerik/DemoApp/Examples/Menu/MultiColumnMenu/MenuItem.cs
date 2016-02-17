using System;
using System.ComponentModel;
using System.Windows.Controls;
using System.Windows.Markup;
using System.Windows.Media;
using System.Windows.Media.Imaging;

namespace Examples.Menu.MultiColumnMenu
{
	[ContentProperty("Items")]
	public class MenuItem
	{
		private string text;
		private string imageUrl;

		public string Text
		{
			get
			{
				return this.text;
			}
			set
			{
				this.text = value;
			}
		}

		public string ImageUrl
		{
			get
			{
				return this.imageUrl;
			}
			set
			{
				this.imageUrl = value;
			}
		}

		public Image Image
		{
			get
			{
				if (string.IsNullOrEmpty(this.ImageUrl)) return null;

				return new Image()
				{
					Source = new BitmapImage(new Uri(this.ImageUrl, UriKind.RelativeOrAbsolute)),
					Stretch = Stretch.None
				};
			}
		}
	}
}