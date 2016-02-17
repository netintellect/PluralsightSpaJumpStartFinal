using System;
using System.Windows;
using System.Windows.Controls;
using Telerik.Windows.Controls;

namespace Telerik.Windows.Examples.PanelBar.Event
{
	public partial class Example : System.Windows.Controls.UserControl
	{
		public Example()
		{
			InitializeComponent();

			pb.Expanded += this.OnPanelBarEvent;
			pb.PreviewCollapsed += this.OnPanelBarEvent;
			pb.PreviewExpanded += this.OnPanelBarEvent;
			pb.Selected += this.OnPanelBarEvent;
		}

		private void OnPanelBarEvent(object sender, RadRoutedEventArgs e)
		{
			RadPanelBarItem panelBarItem = e.Source as RadPanelBarItem;
			TextBlock header = panelBarItem.Header as TextBlock;
			if (header != null)
			{
				this.Log(e.RoutedEvent.Name, header.Text);
			}
			else
			{
				this.Log(e.RoutedEvent.Name, panelBarItem.ToString());
			}
			
		}

		private void Log(string p, string source)
		{
			TextBlock tb = ScrollViewer.Content as TextBlock;
			tb.Text = DateTime.Now.ToLongTimeString() + " [" + p + "] - " + source + "\n" + tb.Text;
		}

		private void ClearButton_Click(object sender, RoutedEventArgs e)
		{
			TextBlock tb = ScrollViewer.Content as TextBlock;
			tb.Text = String.Empty;
		}
	}
}

