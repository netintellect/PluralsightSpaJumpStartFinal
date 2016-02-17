using System.Collections.Generic;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Collections;
using Telerik.Windows.Controls;
using System.Windows.Media.Animation;
using Examples.OutlookBar.CS;

namespace Telerik.Windows.Examples.OutlookBar.FirstLook
{
	public partial class Example : System.Windows.Controls.UserControl
	{
		private Storyboard mailMessageSelectedStoryboard; 
		private Storyboard businessCardSelectedStoryboard;
		public Example()
		{
			InitializeComponent();
			this.mailMessageSelectedStoryboard = LayoutRoot.Resources["MailMessageSelected"] as Storyboard;
			this.businessCardSelectedStoryboard = LayoutRoot.Resources["BusinessCardSelected"] as Storyboard;
			ContactsListBox.ItemsSource = new Contacts();
			MessagesTreeView.ItemsSource = new MailMessages();
		}

		private void outlookBar_SelectionChanged(object sender, RoutedEventArgs e)
		{
			RadOutlookBarItem selectedItem = outlookBar.SelectedItem as RadOutlookBarItem;
			string tag = selectedItem.Tag as string;
			switch (tag)
			{
				case "Mail":
					this.businessCardSelectedStoryboard.Stop();
					this.mailMessageSelectedStoryboard.Begin();
					break;

				case "Contacts":
					this.mailMessageSelectedStoryboard.Stop();
					this.businessCardSelectedStoryboard.Begin();
					if (this.ContactsListBox.SelectedIndex == -1)
					{
						this.ContactsListBox.SelectedIndex = 0;
					}

					break;

				default:
					break;

			}
		}

		private void foldersTreeView_SelectionChanged(object sender, RoutedEventArgs e)
		{
			if (foldersTreeView.SelectedItem is Message)
			{
				mailMessageCard.DataContext = foldersTreeView.SelectedItem;
			}
		}

		private void RadTreeViewItem_Loaded(object sender, RoutedEventArgs e)
		{
			RadTreeViewItem firstItem = (sender as RadTreeViewItem).ItemContainerGenerator.ContainerFromIndex(0) as RadTreeViewItem;
			if (firstItem != null)
			{
				firstItem.IsSelected = true;
			}
		}

		private void ContactsListBox_SelectionChanged(object sender, System.Windows.Controls.SelectionChangedEventArgs e)
		{
			if (this.businessCard != null)
			{
				this.businessCard.SetDataContext(ContactsListBox.SelectedItem as Employee);
			}
		}

		private void RadNumericUpDown_ValueChanged(object sender, RadRangeBaseValueChangedEventArgs e)
		{
			if (outlookBar != null)
			{
				outlookBar.MinimizedWidth = (double)e.NewValue;
			}
		}

		private void RadNumericUpDown_ValueChanged_1(object sender, RadRangeBaseValueChangedEventArgs e)
		{
			if (outlookBar != null)
			{
				outlookBar.MinimizedWidthThreshold = (double)e.NewValue;
			}
		}
	}
}