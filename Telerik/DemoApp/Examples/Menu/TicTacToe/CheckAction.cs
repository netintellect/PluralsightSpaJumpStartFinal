using System;

namespace Telerik.Windows.Examples.Menu.TicTacToe
{
	public class CheckAction : GameAction
	{
		public CheckAction(TicTacToeViewModel owner, TileViewModel tile, bool turn)
			: base(owner)
		{
			this.Tile = tile;
			this.Turn = turn;
		}

		private TileViewModel _Tile;
		public TileViewModel Tile
		{
			get
			{
				return this._Tile;
			}
			set
			{
				this._Tile = value;
			}
		}

		private bool _Turn;
		public bool Turn
		{
			get
			{
				return this._Turn;
			}
			private set
			{
				this._Turn = value;
			}
		}

		protected override void ApplyEffectOverride()
		{
			this.Tile.Checked = (bool?)this.Turn;
			this.Owner.Turn = !this.Owner.Turn;
		}
		protected override void UnapplyEffectOverride()
		{
			this.Tile.Checked = null;
			this.Owner.Turn = this.Turn;
		}
		public override string Description
		{
			get
			{
				return String.Format("{0} on {1}.{2}", this.Turn ? "X" : "O", this.Tile.X, this.Tile.Y);
			}
		}
	}
}
