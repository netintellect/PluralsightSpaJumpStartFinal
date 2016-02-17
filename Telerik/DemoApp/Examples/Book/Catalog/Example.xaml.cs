using Telerik.Windows.Controls;
using System.Windows.Controls;
using System;
using System.Windows;
using System.Windows.Input;
using System.Windows.Media.Animation;
using System.ComponentModel;
using System.Collections.ObjectModel;
using System.Windows.Data;

namespace Telerik.Windows.Examples.Book.Catalog
{
	public partial class Example : UserControl
	{
		PageManager pageManager;
		bool foldActivated;

		public Example()
		{
			InitializeComponent();
			this.pageManager = LayoutRoot.Resources["PageManager"] as PageManager;
			this.book1.RightPageIndex = 1;
		}

		private void HomeButton_Click(object sender, RoutedEventArgs e)
		{
			if (this.foldActivated)
			{
				return;
			}

			this.book1.RightPageIndex = 1;
		}

		private void PreviousButton_Click(object sender, RoutedEventArgs e)
		{
			if (this.foldActivated)
			{
				return;
			}

			this.book1.RightPageIndex = Math.Max(1, (this.book1.RightPageIndex % 2 == 0) ? this.book1.RightPageIndex - 1 : this.book1.RightPageIndex - 2);
		}

		private void NextButton_Click(object sender, RoutedEventArgs e)
		{
			if (this.foldActivated)
			{
				return;
			}

			this.book1.RightPageIndex = Math.Min(this.pageManager.Pages.Count - 1, (this.book1.RightPageIndex % 2 == 0) ? this.book1.RightPageIndex + 1 : this.book1.RightPageIndex + 2);
		}

		private void EndButton_Click(object sender, RoutedEventArgs e)
		{
			if (this.foldActivated)
			{
				return;
			}

			this.book1.RightPageIndex = this.pageManager.Pages.Count - 1;
		}

		private void ThumbnailsButton_Click(object sender, RoutedEventArgs e)
		{
			this.thumbnails.Visibility = (this.thumbnails.Visibility == Visibility.Visible) ? Visibility.Collapsed : Visibility.Visible;
			this.tocTreeView.Visibility = Visibility.Collapsed;
		}

		private void ToCButton_Click(object sender, RoutedEventArgs e)
		{
			this.thumbnails.Visibility = Visibility.Collapsed;
			this.tocTreeView.Visibility = (this.tocTreeView.Visibility == Visibility.Visible) ? Visibility.Collapsed : Visibility.Visible;
		}

		private void book1_FoldActivated(object sender, FoldEventArgs e)
		{
			this.foldActivated = true;
		}

		private void book1_FoldDeactivated(object sender, FoldEventArgs e)
		{
			this.foldActivated = false;
		}

		private void RadTreeView_SelectionChanged(object sender, RoutedEventArgs e)
		{
			RadTreeView tocTreeView = sender as RadTreeView;
			RadTreeViewItem treeViewItem = tocTreeView.SelectedItem as RadTreeViewItem;
			int rightPageIndex = Convert.ToInt16(treeViewItem.Tag);
			this.book1.RightPageIndex = rightPageIndex;
		}
	}
}