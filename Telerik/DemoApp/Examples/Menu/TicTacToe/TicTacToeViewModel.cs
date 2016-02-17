using System;
using System.Windows.Input;
using System.ComponentModel;
using System.Collections.ObjectModel;
using System.Collections.Generic;
using System.Windows.Threading;
using Telerik.Windows.Controls;
using System.Linq;

namespace Telerik.Windows.Examples.Menu.TicTacToe
{
	public class TicTacToeViewModel : ViewModelBase
	{

		public TicTacToeViewModel()
		{
			this._AITimer = new DispatcherTimer();
			this._AITimer.Interval = new TimeSpan(0, 0, 0, 0, 333);
			this._AITimer.Tick += new EventHandler(this.AITimer_Tick);

			ObservableCollection<TileViewModel> board = new ObservableCollection<TileViewModel>();
			for (int i = 0; i < 9; i++)
			{
				board.Add(new TileViewModel(this, i % 3, i / 3));
			}
			this.Board = new ReadOnlyObservableCollection<TileViewModel>(board);
			this._InternalUndoStack = new ObservableCollection<GameAction>();
			this.UndoStack = new ReadOnlyObservableCollection<GameAction>(this._InternalUndoStack);
			this._InternalRedoStack = new ObservableCollection<GameAction>();
			this.RedoStack = new ReadOnlyObservableCollection<GameAction>(this._InternalRedoStack);

			this.Reset = new DelegateCommand(OnExecuteReset);
			this.Undo = new DelegateCommand(OnExecuteUndo, CanUndo);
			this.Redo = new DelegateCommand(OnExecuteRedo, CanRedo);

			this.IsAIPaused = true;

			this.IsTruePlayerAI = true;
			this.IsFalsePlayerAI = false;

			this.IsAIPaused = false;

			random = new Random();
		}

		internal void OnBoardChanged()
		{
			this.WinPlayer = TicTacToeAI.WinTest(this.GenerateBoard());
			bool gameOver = true;
			foreach (TileViewModel item in this.Board)
			{
				gameOver = gameOver && item.Checked.HasValue;
			}
			
			this.IsGameOver = gameOver || this.WinPlayer.HasValue;
			foreach (TileViewModel item in this.Board)
			{
				item.Invalidate();
			}
		}

		private bool _IsGameOver;
		public bool IsGameOver
		{
			get
			{
				return this._IsGameOver;
			}
			private set
			{
				if (this._IsGameOver != value)
				{
					this._IsGameOver = value;
					this.OnPropertyChanged(() => this.IsGameOver);
				}
			}
		}

		private bool? _WinPlayer;
		public bool? WinPlayer
		{
			get
			{
				return this._WinPlayer;
			}
			set
			{
				if (!this._WinPlayer.Equals(value))
				{
					this._WinPlayer = value;
					this.OnPropertyChanged(() => this.WinPlayer);
				}
			}
		}

		private Random random;

		private ICommand _Reset;
		public ICommand Reset
		{
			get
			{
				return this._Reset;
			}
			private set
			{
				this._Reset = value;
			}
		}

		private ICommand _Undo;
		public ICommand Undo
		{
			get
			{
				return this._Undo;
			}
			private set
			{
				this._Undo = value;
			}
		}

		private ICommand _Redo;
		public ICommand Redo
		{
			get
			{
				return this._Redo;
			}
			private set
			{
				this._Redo = value;
			}
		}

		private void OnExecuteUndo(object sender)
		{
			if (this.UndoStack.Count() > 0)
			{
				this.UndoAction(this.UndoStack[0]);
			}
		}
		private bool CanUndo(object sender)
		{
			return this.IsUndoAvailable;
		}

		private void OnExecuteRedo(object sender)
		{
			if (this.RedoStack.Count() > 0)
			{
				this.RedoAction(this.RedoStack[0]);
			}
		}
		private bool CanRedo(object sender)
		{
			return this.IsRedoAvailable;
		}

		private void OnExecuteReset(object param)
		{
			this.PerformReset();
		}

		private void UpdateHistoryCommands()
		{
			this.IsRedoAvailable = this.RedoStack.Count() > 0;
			this.IsUndoAvailable = this.UndoStack.Count() > 0;
		}

		private bool _IsUndoAvailable;
		public bool IsUndoAvailable
		{
			get
			{
				return this._IsUndoAvailable;
			}
			private set
			{
				if (this._IsUndoAvailable != value)
				{
					this._IsUndoAvailable = value;
					this.OnPropertyChanged(() => this.IsUndoAvailable);
				}
			}
		}

		private bool _IsRedoAvailable;
		public bool IsRedoAvailable
		{
			get
			{
				return this._IsRedoAvailable;
			}
			private set
			{
				if (this._IsRedoAvailable != value)
				{
					this._IsRedoAvailable = value;
					this.OnPropertyChanged(() => this.IsRedoAvailable);
				}
			}
		}

		private bool _IsTruePlayerAI;
		public bool IsTruePlayerAI
		{
			get
			{
				return this._IsTruePlayerAI;
			}
			set
			{
				if (this._IsTruePlayerAI != value)
				{
					this._IsTruePlayerAI = value;
					this.OnPropertyChanged(() => this.IsTruePlayerAI);
					this.InvalidateAI();
				}
			}
		}

		private bool _IsFalsePlayerAI;
		public bool IsFalsePlayerAI
		{
			get
			{
				return this._IsFalsePlayerAI;
			}
			set
			{
				if (this._IsFalsePlayerAI != value)
				{
					this._IsFalsePlayerAI = value;
					this.OnPropertyChanged(() => this.IsFalsePlayerAI);
					this.InvalidateAI();
				}
			}
		}

		private bool _IsAIPaused;
		public bool IsAIPaused
		{
			get
			{
				return this._IsAIPaused;
			}
			set
			{
				if (this._IsAIPaused != value)
				{
					this._IsAIPaused = value;
					this.OnPropertyChanged(() => this.IsAIPaused);
					this.InvalidateAI();
				}
			}
		}

		private DispatcherTimer _AITimer;

		private void InvalidateAI()
		{
			// NOTE: 
			foreach (TileViewModel tile in this.Board)
			{
				tile.Invalidate();
			}
			// if (!this.IsAIPaused && IsComputerOnTurn && this.Board.Where((b) => !b.Checked.HasValue).FirstOrDefault() != null)
			if (!this.IsAIPaused && IsComputerOnTurn && !this.IsGameOver)
			{
				if (this._AITimer != null)
				{
					if (!this._AITimer.IsEnabled)
					{
						this._AITimer.Start();
					}
				}
			}
			else if (this._AITimer.IsEnabled)
			{
				this._AITimer.Stop();
			}
			return;
		}

		private void AITimer_Tick(object sender, EventArgs e)
		{
			// if (!this.IsAIPaused && IsComputerOnTurn && this.Board.Where((b) => !b.Checked.HasValue).FirstOrDefault() != null)
			if (!this.IsAIPaused && IsComputerOnTurn && !this.IsGameOver)
			{
				PlayAI();
			}
			this._AITimer.Stop();
			this.InvalidateAI();
		}

		private void PlayAI()
		{
			bool pcPlayer = this.Turn;

			if (this.Turn == pcPlayer)
			{
				bool?[] field = this.GenerateBoard();

				IList<int> win;
				IList<int> draw;
				IList<int> loose;
				TicTacToeAI.GeneratePossibleMoves(field, pcPlayer, out win, out draw, out loose);

				if (win.Count() > 0)
				{
					this.PerformCheck(this.Board[win[this.random.Next(win.Count() - 1)]]);
				}
				else if (draw.Count() > 0)
				{
					this.PerformCheck(this.Board[draw[this.random.Next(draw.Count() - 1)]]);
				}
				else if (loose.Count() > 0)
				{
					this.PerformCheck(this.Board[loose[this.random.Next(loose.Count() - 1)]]);
				}
			}
		}

		internal bool?[] GenerateBoard()
		{
			bool?[] field = new bool?[9];
			for (int i = 0; i < 9; i++)
			{
				field[i] = this.Board[i].Checked;
			}
			return field;
		}

		private ReadOnlyObservableCollection<TileViewModel> _Board;
		public ReadOnlyObservableCollection<TileViewModel> Board
		{
			get
			{
				return this._Board;
			}
			private set
			{
				this._Board = value;
			}
		}

		private bool _Turn;
		public bool Turn
		{
			get
			{
				return this._Turn;
			}
			internal set
			{
				if (this._Turn != value)
				{
					this._Turn = value;
					this.OnBoardChanged();
					this.OnPropertyChanged(() => this.Turn);
				}
			}
		}

		private ObservableCollection<GameAction> _InternalUndoStack;
		private ReadOnlyObservableCollection<GameAction> _UndoStack;
		public ReadOnlyObservableCollection<GameAction> UndoStack
		{
			get
			{
				return this._UndoStack;
			}
			set
			{
				this._UndoStack = value;
			}
		}

		private ObservableCollection<GameAction> _InternalRedoStack;
		private ReadOnlyObservableCollection<GameAction> _RedoStack;
		public ReadOnlyObservableCollection<GameAction> RedoStack
		{
			get
			{
				return this._RedoStack;
			}
			set
			{
				this._RedoStack = value;
			}
		}

		internal void PerformCheck(TileViewModel tile)
		{
			this.AddAction(new CheckAction(this, tile, this.Turn));
			this.InvalidateAI();
		}
		internal void PerformReset()
		{
			this.AddAction(new ResetAction(this));
			this.InvalidateAI();
		}

		private void AddAction(GameAction action)
		{
			action.ApplyEffect();
			this._InternalUndoStack.Insert(0, action);
			if (this._InternalUndoStack.Count() > 10)
			{
				this._InternalUndoStack.RemoveAt(this._InternalUndoStack.Count() - 1);
			}
			this._InternalRedoStack.Clear();
			this.UpdateHistoryCommands();
		}
		internal void UndoAction(GameAction action)
		{
			if (this._InternalUndoStack.Contains(action))
			{
				GameAction current;
				do
				{
					current = this._InternalUndoStack[0];
					current.UnapplyEffect();
					this._InternalRedoStack.Insert(0, current);
					this._InternalUndoStack.RemoveAt(0);
				}
				while (action != current);
			}
			this.UpdateHistoryCommands();

			this.IsAIPaused = this.Turn && this.IsTruePlayerAI || !this.Turn && this.IsFalsePlayerAI;
		}
		internal void RedoAction(GameAction action)
		{
			if (this._InternalRedoStack.Contains(action))
			{
				GameAction current;
				do
				{
					current = this._InternalRedoStack[0];
					current.ApplyEffect();
					this._InternalUndoStack.Insert(0, current);
					this._InternalRedoStack.RemoveAt(0);
				}
				while (action != current);
			}
			this.UpdateHistoryCommands();

			this.IsAIPaused = this.Turn && this.IsTruePlayerAI || !this.Turn && this.IsFalsePlayerAI;
		}

		internal bool IsComputerOnTurn
		{
			get
			{
				return this.Turn && this.IsTruePlayerAI || !this.Turn && this.IsFalsePlayerAI;
			}
		}
	}
}
