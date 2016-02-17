
namespace Telerik.Windows.Examples.Menu.TicTacToe
{
	public class ResetAction : GameAction
	{
		private bool?[] _GameState;
		public ResetAction(TicTacToeViewModel owner)
			: base(owner)
		{
			this._GameState = new bool?[9];
			for (int i = 0; i < 9; i++)
			{
				this._GameState[i] = Owner.Board[i].Checked;
			}
		}
		protected override void ApplyEffectOverride()
		{
			for (int i = 0; i < 9; i++)
			{
				this.Owner.Board[i].Checked = null;
			}
		}
		protected override void UnapplyEffectOverride()
		{
			for (int i = 0; i < 9; i++)
			{
				this.Owner.Board[i].Checked = this._GameState[i];
			}
		}
		public override string Description
		{
			get
			{
				return "Reset";
			}
		}
	}
}
