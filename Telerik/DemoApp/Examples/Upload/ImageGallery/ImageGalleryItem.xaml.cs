using System;
using System.Windows;
using System.Windows.Controls;

namespace Telerik.Windows.Examples.Upload.ImageGallery
{
	/// <summary>
	/// 
	/// </summary>
	public partial class ImageGalleryItem : UserControl
	{
		/// <summary>
		/// 
		/// </summary>
		public event EventHandler ActionButtonClicked;

		/// <summary>
		/// 
		/// </summary>
		public ImageGalleryItem()
		{
			InitializeComponent();
		}

		/// <summary>
		/// 
		/// </summary>
		public string FileName
		{
			get
			{
				if (this.file_Name != null)
				{
					return this.file_Name.Text;
				}
				return string.Empty;
			}
			set
			{
				if (this.file_Name != null)
				{
					this.file_Name.Text = value;
				}
			}
		}

		/// <summary>
		/// 
		/// </summary>
		public string FileSize
		{
			get
			{
				if (this.file_Size != null)
				{
					return this.file_Size.Text;
				}
				return string.Empty;
			}
			set
			{
				if (this.file_Size != null)
				{
					this.file_Size.Text = value;
				}
			}
		}

		/// <summary>
		/// 
		/// </summary>
		/// <param name="image"></param>
		public void SetImage(Image image)
		{
			if (this.PictureHolder != null)
			{
				this.PictureHolder.Child = image;
			}
		}

		/// <summary>
		/// 
		/// </summary>
		public void OnActionButtonClicked()
		{
			if (this.ActionButtonClicked != null)
			{
				this.ActionButtonClicked(this, null);
			}
		}

		private void buttonClose_Click(object sender, RoutedEventArgs e)
		{
			this.OnActionButtonClicked();
		}
	}
}
