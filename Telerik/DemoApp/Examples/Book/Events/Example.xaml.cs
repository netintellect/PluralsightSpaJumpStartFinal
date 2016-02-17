using System.Windows.Controls;
using System;
using System.Windows;

namespace Telerik.Windows.Examples.Book.Events
{
	public partial class Example : UserControl
	{
		private bool handlePreviewEvent;

		public Example()
		{
			InitializeComponent();
		}

		private void RadBook1_FoldActivated(object sender, Telerik.Windows.Controls.FoldEventArgs e)
		{
			this.Log("FoldActivated");
		}

		private void RadBook1_FoldDeactivated(object sender, Telerik.Windows.Controls.FoldEventArgs e)
		{
			this.Log("FoldDeactivated");
		}

		private void RadBook1_PageChanged(object sender, RadRoutedEventArgs e)
		{
			this.Log("PageChanged");
		}

		private void RadBook1_PageFlipEnded(object sender, Telerik.Windows.Controls.PageFlipEventArgs e)
		{
			this.Log("PageFlipEnded");
		}

		private void RadBook1_PageFlipStarted(object sender, Telerik.Windows.Controls.PageFlipEventArgs e)
		{
			this.Log("PageFlipStarted");
		}

		private void RadBook1_PreviewPageFlipStarted(object sender, Telerik.Windows.Controls.PageFlipEventArgs e)
		{
			e.Handled = this.handlePreviewEvent;
			this.Log("PreviewPageFlipStarted");
		}

		private void Log(string message)
		{
			TextBlock tb = ScrollViewer.Content as TextBlock;
			tb.Text = DateTime.Now.ToLongTimeString() + " [" + message + "]" + "\n" + tb.Text;
		}

		private void ClearButton_Click(object sender, RoutedEventArgs e)
		{
			TextBlock tb = ScrollViewer.Content as TextBlock;
			tb.Text = String.Empty;
		}

		private void HandlePreviewPageFlipStarted_Checked(object sender, RoutedEventArgs e)
		{
			this.handlePreviewEvent = true;
		}

		private void UnhandlePreviewPageFlipStarted_Checked(object sender, RoutedEventArgs e)
		{
			this.handlePreviewEvent = false;
		}
	}
}