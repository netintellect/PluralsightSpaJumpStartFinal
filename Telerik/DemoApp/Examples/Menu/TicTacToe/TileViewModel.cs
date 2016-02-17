using System;
using System.ComponentModel;
using System.Windows.Input;
using Telerik.Windows.Controls;

namespace Telerik.Windows.Examples.Menu.TicTacToe
{
	public class TileViewModel : ViewModelBase
	{
		internal TileViewModel(TicTacToeViewModel owner, int x, int y)
		{
			this.X = x;
			this.Y = y;
			this.Owner = owner;
			this._Check = new DelegateCommand(OnCheck, CanCheck);
		}

		private void OnCheck(object param)
		{
			this.Owner.PerformCheck(this);
		}
		private bool CanCheck(object param)
		{
			return !this.Checked.HasValue && !this.Owner.IsComputerOnTurn && !this.Owner.WinPlayer.HasValue;
		}

		internal void Invalidate()
		{
			this._Check.InvalidateCanExecute();
		}

		private DelegateCommand _Check;
		public ICommand Check
		{
			get
			{
				return this._Check;
			}
		}

		private bool? _Checked;
		public bool? Checked
		{
			get
			{
				return this._Checked;
			}
			internal set
			{
				if (!this._Checked.Equals(value))
				{
					this._Checked = value;
					this.OnPropertyChanged(() => this.Checked);
					Invalidate();
					this.Owner.OnBoardChanged();
				}
			}
		}

		private TicTacToeViewModel _Owner;
		public TicTacToeViewModel Owner
		{
			get
			{
				return this._Owner;
			}
			private set
			{
				this._Owner = value;
			}
		}


		private int _X;
		public int X
		{
			get
			{
				return this._X;
			}
			private set
			{
				this._X = value;
			}
		}

		private int _Y;
		public int Y
		{
			get
			{
				return this._Y;
			}
			private set
			{
				this._Y = value;
			}
		}
	}
}
