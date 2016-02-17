using System;
using Telerik.Windows.Controls;
using System.ComponentModel;

namespace Telerik.Windows.Examples.TabControl.Databinding.ViewModel
{
	public class TabViewModel : INotifyPropertyChanged
	{
		private bool isSelected;
		private readonly MainViewModel mainViewModel;

		public TabViewModel(MainViewModel mainViewModel)
		{
			this.mainViewModel = mainViewModel;

			this.AddItemCommand = new DelegateCommand(
				delegate
				{
					this.mainViewModel.AddItem(this);
				},
				delegate
				{
					return this.mainViewModel.Tabs.Count < 5;
				});

			this.RemoveItemCommand = new DelegateCommand(
				delegate
				{
					this.mainViewModel.RemoveItem(this);
				},
				delegate
				{
					return this.mainViewModel.Tabs.Count > 1;
				});
		}

		public string Header
		{
			get;
			set;
		}

		public bool IsSelected
		{
			get
			{
				return this.isSelected;
			}
			set
			{
				if (this.isSelected != value)
				{
					this.isSelected = value;
					this.OnPropertyChanged("IsSelected");
				}
			}
		}

		public DelegateCommand AddItemCommand { get; set; }
		public DelegateCommand RemoveItemCommand { get; set; }

		#region INotifyPropertyChanged
		public event PropertyChangedEventHandler PropertyChanged;

		private void OnPropertyChanged(string propertyName)
		{
			if (this.PropertyChanged != null)
			{
				this.PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
			}
		}
		#endregion
	}
}
