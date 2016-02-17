using System;
using System.Windows.Input;
using Telerik.Windows.Controls;

namespace Telerik.Windows.Examples.Menu.TicTacToe
{
	public abstract class GameAction
	{
		public GameAction(TicTacToeViewModel owner)
		{
			this.Owner = owner;

			this._Undo = new DelegateCommand(this.OnExecuteUndo, this.CanUndo);
			this._Redo = new DelegateCommand(this.OnExecuteRedo, this.CanRedo);
		}

		private void OnExecuteUndo(object p)
		{
			this.Owner.UndoAction(this);
		}
		private void OnExecuteRedo(object p)
		{
			this.Owner.RedoAction(this);
		}

		private bool CanUndo(object p)
		{
			return this.IsDone;
		}
		private bool CanRedo(object p)
		{
			return !this.IsDone;
		}

		private bool _IsDone = false;
		private bool IsDone
		{
			get
			{
				return this._IsDone;
			}
			set
			{
				if (this._IsDone != value)
				{
					this._Undo.InvalidateCanExecute();
					this._Redo.InvalidateCanExecute();
					this._IsDone = value;
				}
			}
		}

		private DelegateCommand _Undo;
		public ICommand Undo
		{
			get
			{
				return this._Undo;
			}
		}
		private DelegateCommand _Redo;
		public ICommand Redo
		{
			get
			{
				return this._Redo;
			}
		}

		private TicTacToeViewModel _Owner;
		protected TicTacToeViewModel Owner
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

		internal void ApplyEffect()
		{
			if (!this.IsDone)
			{
				this.ApplyEffectOverride();
				this.IsDone = true;
			}
		}
		internal void UnapplyEffect()
		{
			if (this.IsDone)
			{
				this.UnapplyEffectOverride();
				this.IsDone = false;
			}
		}

		protected abstract void ApplyEffectOverride();
		protected abstract void UnapplyEffectOverride();

		public abstract String Description { get; }
	}
}
