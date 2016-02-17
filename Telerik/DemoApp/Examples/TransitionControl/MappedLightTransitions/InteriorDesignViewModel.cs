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
	public class InteriorDesignViewModel : ViewModelBase, ISupportInitialize
	{
		public InteriorDesignViewModel()
		{
			this._Walls = new ObservableCollection<Wall>();
			this._SelectNextWall = new DelegateCommand(this.SelectNextWallAction);
			this._SelectPreviousWall = new DelegateCommand(this.SelectPreviousWallAction);
		}

		private ICommand _SelectNextWall;
		public ICommand SelectNextWall
		{
			get
			{
				return this._SelectNextWall;
			}
		}

		private ICommand _SelectPreviousWall;
		public ICommand SelectPreviousWall
		{
			get
			{
				return this._SelectPreviousWall;
			}
		}

		private void SelectNextWallAction(object param)
		{
			int index = this.Walls.IndexOf(this.SelectedWall) + 1;
			if (index >= this.Walls.Count())
			{
				this.SelectedWall = this.Walls.FirstOrDefault();
			}
			else
			{
				this.SelectedWall = this.Walls[index];
			}
		}

		private void SelectPreviousWallAction(object param)
		{
			int index = this.Walls.IndexOf(this.SelectedWall) - 1;
			if (index <= -1)
			{
				this.SelectedWall = this.Walls.LastOrDefault();
			}
			else
			{
				this.SelectedWall = this.Walls[index];
			}
		}

		private Wall _SelectedWall;
		public Wall SelectedWall
		{
			get
			{
				return this._SelectedWall;
			}
			set
			{
				if (this._SelectedWall != value)
				{
					this._SelectedWall = value;
					this.OnPropertyChanged(() => this.SelectedWall);
				}
			}
		}

		private ObservableCollection<Wall> _Walls;
		public ObservableCollection<Wall> Walls
		{
			get
			{
				return this._Walls;
			}
		}

		public void BeginInit()
		{
		}

		public void EndInit()
		{
			this.SelectedWall = this.Walls.FirstOrDefault();
		}
	}
}
