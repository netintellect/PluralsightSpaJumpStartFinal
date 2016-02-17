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

namespace Telerik.Windows.Examples.OutlookBar.ItemPosition
{
	public partial class Example : System.Windows.Controls.UserControl
	{
		private int counter = 5;
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
				if (this.outlookBar.Items.Count == 0)
				{
					this.counter = 0;
				}
			}
		}

		private void ButtonClearLog_Click(object sender, RoutedEventArgs e)
		{
			this.log.Items.Clear();
		}

		private void ButtonClearOutlookBar_Click(object sender, RoutedEventArgs e)
		{
			this.outlookBar.Items.Clear();
		}

		private void CreateItem()
		{
			RadOutlookBarItem item = new RadOutlookBarItem();
			item.Header = "Item " + this.counter;
			item.Content = "Item " + this.counter;
			this.outlookBar.Items.Add(item);
			this.counter += 1;
		}

		private void OutlookBar_ItemPositionChanged(object sender, PositionChangedEventArgs e)
		{
			RadOutlookBarItem obItem = e.OriginalSource as RadOutlookBarItem;
			string header = obItem.Header.ToString();
			string newPosition = e.NewPosition.ToString();
			string oldPosition = e.OldPosition.ToString();

			LogItem logItem = new LogItem(header, newPosition, oldPosition, DateTime.Now.TimeOfDay);
			Dispatcher.BeginInvoke(new Action<LogItem>(AddLogItem), logItem);
		}

		private void AddLogItem(LogItem logItem)
		{
			this.log.Items.Insert(0, logItem);
			this.log.SelectedItem = logItem;
		}
	}

	public class LogItem
	{
		public LogItem(string header, string newPosition, string oldPosition, TimeSpan timeStamp)
		{
			this.Header = header;
			this.NewPosition = newPosition;
			this.OldPosition = oldPosition;
			this.TimeStamp = timeStamp;
		}

		public TimeSpan TimeStamp { get; set; }
		public string Header { get; set; }
		public string NewPosition { get; set; }
		public string OldPosition { get; set; }
	}
}
