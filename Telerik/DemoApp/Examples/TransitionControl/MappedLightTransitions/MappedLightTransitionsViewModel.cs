using System;
using System.Net;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Documents;
using System.Windows.Ink;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Animation;
using System.Windows.Shapes;
using Telerik.Windows.Controls;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;

namespace Telerik.Windows.Examples.TransitionControl.MappedLightTransitions
{
	public class MappedLightTransitionsViewModel : ViewModelBase, ISupportInitialize
	{
		public MappedLightTransitionsViewModel()
		{
			this._NavigationItems = new ObservableCollection<NavigationItem>();
		}

		//private ICommand _SelectNextWall;
		//public ICommand SelectNextWall
		//{
		//    get
		//    {
		//        return this._SelectNextWall;
		//    }
		//}

		//private ICommand _SelectPreviousWall;
		//public ICommand SelectPreviousWall
		//{
		//    get
		//    {
		//        return this._SelectPreviousWall;
		//    }
		//}

		//private void SelectNextWallAction(object param)
		//{
		//    int index = this.NavigationItems.IndexOf(this.SelectedItem) + 1;
		//    if (index >= this.NavigationItems.Count())
		//    {
		//        this.SelectedItem = this.NavigationItems.FirstOrDefault();
		//    }
		//    else
		//    {
		//        this.SelectedItem = this.NavigationItems[index];
		//    }
		//}

		//private void SelectPreviousWallAction(object param)
		//{
		//    int index = this.NavigationItems.IndexOf(this.SelectedItem) - 1;
		//    if (index <= -1)
		//    {
		//        this.SelectedItem = this.NavigationItems.LastOrDefault();
		//    }
		//    else
		//    {
		//        this.SelectedItem = this.NavigationItems[index];
		//    }
		//}

		private NavigationItem _SelectedItem;
		public NavigationItem SelectedItem
		{
			get
			{
				return this._SelectedItem;
			}
			set
			{
				if (this._SelectedItem != value)
				{
					this._SelectedItem = value;
					this.OnPropertyChanged(() => this.SelectedItem);
				}
			}
		}

		private ObservableCollection<NavigationItem> _NavigationItems;
		public ObservableCollection<NavigationItem> NavigationItems
		{
			get
			{
				return this._NavigationItems;
			}
		}

		public void BeginInit()
		{
		}

		public void EndInit()
		{
			this.SelectedItem = this.NavigationItems.FirstOrDefault();
		}

	}
}
