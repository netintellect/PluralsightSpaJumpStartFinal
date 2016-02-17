using System;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media.Imaging;
using Telerik.Windows.Controls;
using System.Windows.Input;

namespace Telerik.Windows.Examples.Upload.ImageGallery
{
	/// <summary>
	/// 
	/// </summary>
	public partial class Example : System.Windows.Controls.UserControl
	{
		/// <summary>
		/// 
		/// </summary>
		public Example()
		{
			InitializeComponent();
			this.Loaded += Example_Loaded;
		}

		private static Uri ConstructAbsoluteUri(Uri url)
		{
			if (!url.IsAbsoluteUri)
			{
				System.Uri source = System.Windows.Application.Current.Host.Source;
				string server = source.AbsoluteUri.Remove(source.AbsoluteUri.Length - source.AbsolutePath.Length);
				int serverLen = server.Length;
				string relativePath = url.OriginalString;
				const string PathSeparator = "/";

				if (relativePath.StartsWith(PathSeparator, StringComparison.OrdinalIgnoreCase))
				{
					//// ; nothing to do - just continue!
				}
				else if (relativePath.StartsWith("~/", StringComparison.OrdinalIgnoreCase))
				{
					relativePath = relativePath.Substring(1);
				}
				else if (relativePath.StartsWith("./", StringComparison.OrdinalIgnoreCase))
				{
					relativePath = relativePath.Remove(0, 1);
					server = source.AbsoluteUri.Remove(source.AbsoluteUri.LastIndexOf(PathSeparator, StringComparison.OrdinalIgnoreCase));
				}
				else if (relativePath.StartsWith("../", StringComparison.OrdinalIgnoreCase))
				{
					server = RemoveLastNode(source.AbsoluteUri, PathSeparator, serverLen);
					while (relativePath.StartsWith("../", StringComparison.OrdinalIgnoreCase))
					{
						relativePath = relativePath.Remove(0, 3);
						server = RemoveLastNode(server, PathSeparator, serverLen);
					}
					server += PathSeparator;
				}
				else
				{
					server += PathSeparator;
				}
				url = new Uri(server + relativePath, UriKind.Absolute);
			}
			return url;
		}

		private static string RemoveLastNode(string path, string separator, int stopAt)
		{
			int i = path.LastIndexOf(separator, StringComparison.OrdinalIgnoreCase);

			if (i < stopAt)
			{
				i = stopAt;
			}

			if (i < path.Length)
			{
				if (i <= 0)
				{
					path = string.Empty;
				}
				else if (i > 0)
				{
					path = path.Remove(i);
				}
			}

			return path;
		}

		private void Example_Loaded(object sender, RoutedEventArgs e)
		{
			this.scrollViewer.MouseWheel += this.OnMouseWheel;
		}

		private void RadUpload_FileUploaded(object sender, FileUploadedEventArgs e)
		{
			Uri uri = ConstructAbsoluteUri(new Uri(this.RadUpload1.UploadServiceUrl, UriKind.RelativeOrAbsolute));
			string imageURL = uri.AbsoluteUri.Remove(uri.AbsoluteUri.LastIndexOf("/")) +
				"/" + RadUpload1.TargetFolder + "/" + e.SelectedFile.Name;

			Image img = new Image();
			BitmapImage bmp = new BitmapImage(new Uri(imageURL, UriKind.RelativeOrAbsolute));
			img.ImageFailed += this.NewImage_ImageFailed;
			img.Source = bmp;
			img.Margin = new Thickness(1);
			img.Stretch = System.Windows.Media.Stretch.Uniform;

			ImageGalleryItem item = new ImageGalleryItem();
			item.FileSize = this.FormatSize(e.SelectedFile.Size);
			item.FileName = e.SelectedFile.Name;
			item.SetImage(img);
			item.ActionButtonClicked += this.ItemActionButtonHandler;
			this.ImageContainer.Children.Add(item);
		}

		private string FormatSize(long size)
		{
			const long k = 1024;
			const long m = 1024 * 1024;
			const long g = 1024 * 1024 * 1024;
			string postfix = string.Empty;

			if (size < k)
			{
				postfix = "B";
				////size = size;
			}
			else if (size < m)
			{
				postfix = "kB";
				size /= k;
			}
			else if (size < g)
			{
				postfix = "mB";
				size /= m;
			}
			else
			{
				postfix = "gB";
				size /= g;
			}
			return "(" + size + postfix + ")";
		}

		private void NewImage_ImageFailed(object sender, ExceptionRoutedEventArgs e)
		{
			Image img = sender as Image;
			if (img != null)
			{
				img.Source = new BitmapImage(new Uri("Images/Smile.png", UriKind.Relative));
			}
		}

		private void RadUpload1_UploadStarted(object sender, UploadStartedEventArgs e)
		{
			foreach (object o in ImageContainer.Children)
			{
				ImageGalleryItem item = o as ImageGalleryItem;
				if (item != null)
				{
					item.ActionButtonClicked -= this.ItemActionButtonHandler;
				}
			}
			this.ImageContainer.Children.Clear();
		}

		private void ItemActionButtonHandler(object sender, EventArgs e)
		{
			ImageGalleryItem item = sender as ImageGalleryItem;
			if (item != null)
			{
				item.ActionButtonClicked -= this.ItemActionButtonHandler;
				this.ImageContainer.Children.Remove(item);
			}
		}

		private void OnMouseWheel(object sender, MouseWheelEventArgs args)
		{
			double offset;
			const int accelerate = 5;
			if (scrollViewer.ComputedVerticalScrollBarVisibility == Visibility.Visible)
			{
				offset = scrollViewer.VerticalOffset - args.Delta * accelerate;
				if (offset > scrollViewer.ScrollableHeight)
				{
					scrollViewer.ScrollToVerticalOffset(scrollViewer.ScrollableHeight);
				}
				else
				{
					scrollViewer.ScrollToVerticalOffset(offset);
				}
			}
			else
			{
				offset = scrollViewer.HorizontalOffset - args.Delta * accelerate;
				if (offset > scrollViewer.ScrollableWidth)
				{
					scrollViewer.ScrollToHorizontalOffset(scrollViewer.ScrollableWidth);
				}
				else
				{
					scrollViewer.ScrollToHorizontalOffset(offset);
				}
			}
		}
	}
}

