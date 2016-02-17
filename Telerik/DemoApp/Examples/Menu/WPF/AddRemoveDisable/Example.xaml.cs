using System.Windows;
using System.Windows.Input;
using Examples.Menu.Common;
using Telerik.Windows.Controls;

namespace Telerik.Windows.Examples.Menu.WPF.AddRemoveDisable
{
	public partial class Example : System.Windows.Controls.UserControl
	{
		public Example()
		{
			InitializeComponent();
		}
		 
		private void OnMenuLoaded(object sender, RoutedEventArgs e)
		{
			for (int i = 0; i < menu.Items.Count; i++)
			{
				RadMenuItem container = menu.ItemContainerGenerator.ContainerFromIndex(i) as RadMenuItem;
				if (container != null)
				{
					AddMouseEnter(container);
				}
			}
		}

		private void AddMouseEnter(RadMenuItem item)
		{
			item.MouseEnter += this.OnRadMenuItem_MouseEnter;
		}

		private void OnMenuItemClick(object sender, RadRoutedEventArgs e)
		{
			MenuItem item = (e.OriginalSource as RadMenuItem).DataContext as MenuItem;

			MenuItem parent = item.Parent;

			if (parent == null) return;

			switch (parent.Text.ToLower())
			{
				case "add":
					MenuItem newItem = new MenuItem()
					{
						Text = "New " + item.Text,
						ImageUrl = item.ImageUrl,
						StaysOpenOnClick = item.StaysOpenOnClick
					};
					parent.Items.Add(newItem);
					break;

				case "disable":
					item.IsEnabled = false;
					break;

				case "remove":
					parent.Items.Remove(item);
					break;
			}
		}

		private void OnRadMenuItem_MouseEnter(object sender, MouseEventArgs e)
		{
			MenuItem item = (sender as RadMenuItem).DataContext as MenuItem;

			this.MenuAction.Text = string.Format("Click on an item to {0} it!", item.Text.ToLower());
		}
	}
}