using System;
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

namespace Telerik.Windows.Examples.OutlookBar.AddRemoveDisable
{
	public partial class Example : System.Windows.Controls.UserControl
	{
		private int counter = 0;
		public Example()
		{
			InitializeComponent();
		}

		private void ButtonAdd_Click(object sender, RoutedEventArgs e)
		{
			this.CreateItem();
		}

		private void ButtonRemove_Click(object sender, RoutedEventArgs e)
		{
			if (this.outlookBar.SelectedItem != null)
			{
				this.outlookBar.Items.Remove(this.outlookBar.SelectedItem);
				if(this.outlookBar.Items.Count == 0)
				{
					this.counter = 0;
				}
			}
		}

		private void ButtonDisable_Click(object sender, RoutedEventArgs e)
		{
			if (this.outlookBar.SelectedItem != null)
			{
				(this.outlookBar.SelectedItem as RadOutlookBarItem).IsEnabled = false;
			}
		}

		private void ButtonEnable_Click(object sender, RoutedEventArgs e)
		{
			if (this.outlookBar.SelectedItem != null)
			{
				(this.outlookBar.SelectedItem as RadOutlookBarItem).IsEnabled = true;
			}
		}

		private void outlookBar_ItemPositionChanged(object sender, PositionChangedEventArgs e)
		{

		}

		private void CreateItem()
		{
			RadOutlookBarItem item = new RadOutlookBarItem();
			item.Header = "Item " + this.counter;
			item.Content = "Item " + this.counter;
			this.outlookBar.Items.Add(item);
			this.counter += 1;
		}
	}
}
