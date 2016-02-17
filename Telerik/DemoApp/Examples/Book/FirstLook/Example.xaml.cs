using System;
using System.Collections.Generic;
using Telerik.Windows.Controls;
using System.Windows.Controls;
using System;
using System.Windows;
#if SILVERLIGHT
using System.Windows.Browser;
#endif
using System.Windows.Input;

namespace Telerik.Windows.Examples.Book.FirstLook
{
	public partial class Example : UserControl
	{
		private bool foldActivated;
		private Dictionary<int, Uri> links = new Dictionary<int, Uri>();

		public Example()
		{
			InitializeComponent();
			this.links.Add(4, new Uri("http://www.telerik.com/products/aspnet-ajax.aspx", UriKind.RelativeOrAbsolute));
			this.links.Add(6, new Uri("http://www.telerik.com/products/aspnet-mvc.aspx", UriKind.RelativeOrAbsolute));
			this.links.Add(8, new Uri("http://www.telerik.com/products/silverlight.aspx", UriKind.RelativeOrAbsolute));
			this.links.Add(10, new Uri("http://www.telerik.com/products/wpf.aspx", UriKind.RelativeOrAbsolute));
			this.links.Add(12, new Uri("http://www.telerik.com/products/winforms.aspx", UriKind.RelativeOrAbsolute));
			this.links.Add(14, new Uri("http://www.telerik.com/products/windows-phone.aspx", UriKind.RelativeOrAbsolute));
			this.links.Add(16, new Uri("http://www.telerik.com/products/reporting.aspx", UriKind.RelativeOrAbsolute));
			this.links.Add(18, new Uri("http://www.telerik.com/team-productivity-tools.aspx", UriKind.RelativeOrAbsolute));
		}

		private void RadBook1_FoldActivated(object sender, FoldEventArgs e)
		{
			this.foldActivated = true;
		}

		private void RadBook1_FoldDeactivated(object sender, FoldEventArgs e)
		{
			this.foldActivated = false;
		}

		private void RadTreeViewItemClick(object sender, RadRoutedEventArgs e)
		{
			RadTreeViewItem item = e.OriginalSource as RadTreeViewItem;
			if (item != null && item.Tag != null && !this.foldActivated)
			{
				int index;

				if (int.TryParse(item.Tag.ToString(), out index))
				{
					this.book1.RightPageIndex = index;
				}
			}
		}

		private void RadBookItemMouseLeftButtonUp(object sender, MouseButtonEventArgs e)
		{
			// open the pages on page click
			if (!this.foldActivated)
			{
				this.book1.RightPageIndex = 2;
			}
		}

		private void LinkMouseLeftButtonUp(object sender, MouseButtonEventArgs e)
		{
			var element = sender as FrameworkElement;

			if (element != null && element.Tag != null)
			{
				this.OpenFakeLink(element.Tag.ToString());
			}
		}

		private void OpenFakeLink(string link)
		{
#if WPF
			System.Diagnostics.Process.Start(link);
#else
			HtmlPage.Window.Navigate(new Uri(link, UriKind.RelativeOrAbsolute), "_blank");
#endif
		}

		private void HardPagesRadioButton_Checked(object sender, RoutedEventArgs e)
		{
			if (this.book1 == null)
			{
				return;
			}

			RadioButton btn = sender as RadioButton;
			string content = btn.Content.ToString();

			switch (content)
			{
				case "None":
					this.book1.HardPages = Controls.HardPages.None;
					break;
				case "All":
					this.book1.HardPages = Controls.HardPages.All;
					break;
				case "FirstAndLast":
					this.book1.HardPages = Controls.HardPages.FirstAndLast;
					break;
				case "First":
					this.book1.HardPages = Controls.HardPages.First;
					break;
				case "Last":
					this.book1.HardPages = Controls.HardPages.Last;
					break;
				default:
					break;
			}
		}
	}
}