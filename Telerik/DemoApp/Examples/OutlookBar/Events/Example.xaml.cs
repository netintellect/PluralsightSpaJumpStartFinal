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

namespace Telerik.Windows.Examples.OutlookBar.Events
{
	public partial class Example : System.Windows.Controls.UserControl
	{
		private int counter = 5;
		public Example()
		{
			InitializeComponent();
			this.PositionChangedEventSubscription = true;
			this.SelectedEventSubscription = true;
			this.AddedItemEventSubscription = true;
			this.RemovedItemEventSubscription = true;
			this.DataContext = this;
		}

		public bool? PositionChangedEventSubscription { get; set; }
		public bool? SelectedEventSubscription { get; set; }
		public bool? AddedItemEventSubscription { get; set; }
		public bool? RemovedItemEventSubscription { get; set; }

		private void ButtonAdd_Click(object sender, RoutedEventArgs e)
		{
			RadOutlookBarItem createdItem = this.CreateOutlookBarItem();
			if (Convert.ToBoolean(this.AddedItemEventSubscription))
			{
				string header = createdItem.Header.ToString();
				string message = String.Format("{0} added.", header);
				this.WriteToLog(message);
			}
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
				if (Convert.ToBoolean(this.RemovedItemEventSubscription) && outlookBar.SelectedItem != null)
				{
					string header = this.GetHeader(outlookBar.SelectedItem);
					string message = String.Format("{0} removed.", header);
					this.WriteToLog(message);
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

		private void OutlookBar_ItemPositionChanged(object sender, PositionChangedEventArgs e)
		{
			if (Convert.ToBoolean(this.PositionChangedEventSubscription))
			{
				string header = this.GetHeader(e.OriginalSource);
				string message = String.Format("{0}'s position: {1}", header, e.NewPosition.ToString());
				this.WriteToLog(message);
			}
		}

		private void OutlookBar_SelectionChanged(object sender, RoutedEventArgs e)
		{
			if (Convert.ToBoolean(this.SelectedEventSubscription) && outlookBar.SelectedItem != null)
			{
				string header = this.GetHeader(outlookBar.SelectedItem);
				string message = String.Format("{0} selected.", header);
				this.WriteToLog(message);
			}
		}

		private RadOutlookBarItem CreateOutlookBarItem()
		{
			RadOutlookBarItem item = new RadOutlookBarItem();
			item.Header = "Item " + this.counter;
			item.Content = "Item " + this.counter;
			this.outlookBar.Items.Add(item);
			this.counter += 1;

			return item;
		}

		private void WriteToLog(string message)
		{
			LogItem logItem = new LogItem(message);
			Dispatcher.BeginInvoke(new Action<LogItem>(AddLogItem), logItem);
		}

		private void AddLogItem(LogItem logItem)
		{
			this.log.Items.Insert(0, logItem);
			this.log.SelectedItem = logItem;
		}

		private string GetHeader(object outlookBarItem)
		{
			RadOutlookBarItem obItem = this.outlookBar.ItemContainerGenerator.ContainerFromItem(outlookBarItem) as RadOutlookBarItem;
			return obItem.Header.ToString();
		}

		private void PositionChanged_Checked(object sender, RoutedEventArgs e)
		{
			this.PositionChangedEventSubscription = true;
		}

		private void PositionChanged_Unchecked(object sender, RoutedEventArgs e)
		{
			this.PositionChangedEventSubscription = false;
		}

		private void Selected_Checked(object sender, RoutedEventArgs e)
		{
			this.SelectedEventSubscription = true;
		}

		private void Selected_Unchecked(object sender, RoutedEventArgs e)
		{
			this.SelectedEventSubscription = false;
		}

		private void ItemAdded_Checked(object sender, RoutedEventArgs e)
		{
			this.AddedItemEventSubscription = true;
		}

		private void ItemAdded_Unchecked(object sender, RoutedEventArgs e)
		{
			this.AddedItemEventSubscription = false;
		}

		private void ItemRemoved_Checked(object sender, RoutedEventArgs e)
		{
			this.RemovedItemEventSubscription = true;
		}

		private void ItemRemoved_Unchecked(object sender, RoutedEventArgs e)
		{
			this.RemovedItemEventSubscription = false;
		}
	}

	public class LogItem
	{
		public LogItem(string eventMessage)
		{
			this.TimeStamp = DateTime.Now.TimeOfDay;
			this.EventMessage = eventMessage;
		}

		public TimeSpan TimeStamp { get; set; }
		public string EventMessage { get; set; }
	}
}
