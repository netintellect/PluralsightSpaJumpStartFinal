
using System.Collections.ObjectModel;
using Telerik.Windows.Controls;

namespace Telerik.Windows.Examples.RibbonView.MVVM.ViewModels
{
	public class TabViewModel : ViewModelBase
	{
		private bool isSelected;
		private string text;

		private ObservableCollection<GroupViewModel> groups;

		public TabViewModel()
		{
			groups = new ObservableCollection<GroupViewModel>();
		}

		public ObservableCollection<GroupViewModel> Groups
		{
			get
			{
				return groups;
			}
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

		public string Text
		{
			get
			{
				return this.text;
			}
			set
			{
				if (this.text != value)
				{
					this.text = value;
					this.OnPropertyChanged("Text");
				}
			}
		}
	}
}
