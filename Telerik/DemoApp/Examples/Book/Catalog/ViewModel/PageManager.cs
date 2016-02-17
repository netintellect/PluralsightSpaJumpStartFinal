using System;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;
using System.ComponentModel;

namespace Telerik.Windows.Examples.Book.Catalog
{
	public class PageManager : INotifyPropertyChanged
	{
		private Pages pages;
		public PageManager()
		{
			this.Pages = new Pages();
		}

		public Pages Pages
		{
			get
			{
				return this.pages;
			}
			set
			{
				this.pages = value;
			}
		}

		private int selectedIndex;

		public int SelectedIndex
		{
			get
			{
				return this.selectedIndex;
			}
			set
			{
				if (this.selectedIndex != value && value < this.Pages.Count)
				{
					this.selectedIndex = value;
					this.OnPropertyChanged("SelectedIndex");
				}
			}
		}

		public event PropertyChangedEventHandler PropertyChanged;

		private void OnPropertyChanged(string propertyName)
		{
			if (this.PropertyChanged != null)
			{
				this.PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
			}
		}
	}
}
