using System;
using System.Windows.Controls;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using Telerik.Windows.Controls;

namespace Telerik.Windows.Examples.Diagrams.Dashboard
{
	public sealed class ImageToolboxItem : ImageControl, IToolboxItem
	{
		public const string DefaultSymbol = "MSFT";

		public string Address { get; set; }

		public string Header { get; set; }

		public ImageLocation ImageLocation { get; set; }

		public Uri NavigateUri { get; set; }

		public RadDiagramShape CreateShape()
		{
#if WPF
			var im = this.Source as BitmapFrame;
#else
			var im = this.Source as BitmapImage;
#endif
			var data = new Image { Source = im, Width = im.PixelWidth, Height = im.PixelHeight };

			var shape = new ImageShape
				{
					Location = this.ImageLocation,
					Address = this.Address,
					NavigateUri = this.NavigateUri,
					DataContext = data,
					Width = im.PixelWidth,
					Height = im.PixelHeight
				};
			return shape;
		}
	}
}