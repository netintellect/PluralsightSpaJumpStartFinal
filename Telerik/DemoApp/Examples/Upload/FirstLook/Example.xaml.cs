using System.Globalization;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;

namespace Telerik.Windows.Examples.Upload.FirstLook
{
	/// <summary>
	/// 
	/// </summary>
	public partial class Example : System.Windows.Controls.UserControl
	{

		private string paramValue;

		/// <summary>
		/// 
		/// </summary>
		public Example()
		{
			InitializeComponent();
			this.Loaded += new RoutedEventHandler(Example_Loaded);
		}

   

		/// <summary>
		/// 
		/// </summary>
		public override void OnApplyTemplate()
		{
			base.OnApplyTemplate();
			this.SetFileCountState();
			this.SetBrowseFilter();
			this.SetNumericUpDnFormat();
		}

		private void Example_Loaded(object sender, RoutedEventArgs e)
		{
			this.SetFileCountState();
			this.SetBrowseFilter();
			this.SetNumericUpDnFormat();
		}

		private void SetNumericUpDnFormat()
		{
			System.Globalization.NumberFormatInfo info = new NumberFormatInfo();
			info.NumberDecimalDigits = 0;
			if (this.MaxFileCount != null && this.BrowseFilter != null)
			{
				this.MaxFileCount.NumberFormatInfo = info;
			}
			if (this.MaxUploadSize != null && this.BrowseFilter != null)
			{
				this.MaxUploadSize.NumberFormatInfo = info;
			}
			if (this.MaxFileSize != null && this.BrowseFilter != null)
			{
				this.MaxFileSize.NumberFormatInfo = info;
			}
		}

		private void SetBrowseFilter()
		{
			if (this.RadUpload1 != null && this.BrowseFilter != null)
			{
				this.RadUpload1.Filter = this.BrowseFilter.Text;
				this.RadUpload1.FilterIndex = 0;
			}
		}

		private void SetFileCountState()
		{
			if (this.RadUpload1 != null)
			{
				bool multiple = this.RadUpload1.IsMultiselect == true;
				if (this.MaxFileCountLabel != null)
				{
					this.MaxFileCountLabel.Opacity = multiple ? 1.0 : 0.5;
				}
				if (this.MaxFileCount != null)
				{
					this.MaxFileCount.IsEnabled = multiple;
				}
			}
		}

		private void ButtonUploadMode_Checked(object sender, RoutedEventArgs e)
		{
			if (this.RadUpload1 != null)
			{
				RadioButton cb = sender as RadioButton;
				if (cb != null)
				{
					this.RadUpload1.IsAutomaticUpload = cb.Content.ToString().Equals("Automatic");
				}
			}
		}

		private void ButtonAllowMultiple_Checked(object sender, RoutedEventArgs e)
		{
			if (this.RadUpload1 != null)
			{
				CheckBox cb = sender as CheckBox;
				if (cb != null)
				{
					this.RadUpload1.IsMultiselect = cb.IsChecked == true;
				}
			}
			this.SetFileCountState();
		}

		private void MaxFileCount_ValueChanged(object sender,
            Telerik.Windows.Controls.RadRangeBaseValueChangedEventArgs e)
		{
			if (this.RadUpload1 != null && e.NewValue != null)
			{
				this.RadUpload1.MaxFileCount = (int)this.MaxFileCount.Value;
			}
		}

		private void MaxUploadSize_ValueChanged(object sender,
            Telerik.Windows.Controls.RadRangeBaseValueChangedEventArgs e)
		{
			if (this.RadUpload1 != null && e.NewValue != null)
			{
				this.RadUpload1.MaxUploadSize = (int)this.MaxUploadSize.Value;
			}
		}

		private void MaxFileSize_ValueChanged(object sender,
            Telerik.Windows.Controls.RadRangeBaseValueChangedEventArgs e)
		{
			if (this.RadUpload1 != null && e.NewValue != null)
			{
				this.RadUpload1.MaxFileSize = (int)this.MaxFileSize.Value;
			}
		}

		private void BrowseFilter_TextChanged(object sender, TextChangedEventArgs e)
		{
			this.SetBrowseFilter();
		}

		private void RadUpload1_FileUploadStarting(object sender, Telerik.Windows.Controls.FileUploadStartingEventArgs e)
		{
			// Pass a new parameter to the server handler
			e.FileParameters.Add("MyParam1", paramValue);
		}

		private void RadUpload1_FileUploaded(object sender, Telerik.Windows.Controls.FileUploadedEventArgs e)
		{
			// Get the value of the returned Parameter from the server
			ServerReturnedValue.Text = e.HandlerData.CustomData["MyServerParam1"].ToString();
		}

		private void ButtonAllowMoreFiles_Checked(object sender, RoutedEventArgs e)
		{
			if (this.RadUpload1 != null)
			{
				CheckBox cb = sender as CheckBox;
				if (cb != null)
				{
					this.RadUpload1.IsAppendFilesEnabled = cb.IsChecked == true;
				}
			}
			this.SetFileCountState();
		}

		private void ButtonAllowDrop_Checked(object sender, RoutedEventArgs e)
		{
			if (this.RadUpload1 != null)
			{
				CheckBox cb = sender as CheckBox;
				if (cb != null)
				{
					this.RadUpload1.AllowDrop = cb.IsChecked == true;
				}
			}
		}

		private void RadUpload1_UploadStarted(object sender, Controls.UploadStartedEventArgs e)
		{
			this.paramValue = MyParam.Text;
		}

		private void RadUploadDropPanel1_DragEnter(object sender, DragEventArgs e)
		{
			Color backgroundColor = new Color();
			backgroundColor.R = 208;
			backgroundColor.G = 232;
			backgroundColor.B = 254;
			this.RadUploadDropPanel1.Background = new SolidColorBrush(backgroundColor);
		}

		private void RadUploadDropPanel_DragLeave(object sender, DragEventArgs e)
		{
			this.RadUploadDropPanel1.Background = new SolidColorBrush(Colors.White);
		}
	}
}
