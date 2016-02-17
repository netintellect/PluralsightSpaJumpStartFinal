using System.Collections.Generic;

namespace Telerik.Windows.Examples.Menu.TicTacToe
{
	public class TicTacToeAI
	{
		public static void GeneratePossibleMoves(bool?[] board, bool player, out IList<int> win, out IList<int> draw, out IList<int> loose)
		{
			win = new List<int>();
			draw = new List<int>();
			loose = new List<int>();

			for (int i = 0; i < 9; i++)
			{
				if (!board[i].HasValue)
				{
					bool CanWin = false;
					bool WillLoose = false;
					Move(i, player, board, out CanWin, out WillLoose);
					if (CanWin)
					{
						win.Add(i);
					}
					else if (WillLoose)
					{
						loose.Add(i);
					}
					else
					{
						draw.Add(i);
					}
				}
			}
		}

		private static void Move(int pos, bool player, bool?[] board, out bool CanWin, out bool WillLoose)
		{
			board[pos] = player;
			bool? myVal = WinTest(board);
			CanWin = myVal.HasValue && myVal.Value == player;
			WillLoose = myVal.HasValue && myVal.Value == !player;
			if (!myVal.HasValue)
			{
				bool otherPlayerEscapes = false;
				bool hasMoreMoves = false;
				for (int i = 0; i < 9; i++)
				{
					if (!board[i].HasValue)
					{
						bool otherPlayerCanWin = false;
						bool otherPlayerWillLoose = false;
						Move(i, !player, board, out otherPlayerCanWin, out otherPlayerWillLoose);
						if (otherPlayerCanWin)
						{
							WillLoose = true;
						}
						if (!otherPlayerWillLoose)
						{
							otherPlayerEscapes = true;
						}
						hasMoreMoves = true;
					}
				}
				CanWin = !otherPlayerEscapes && hasMoreMoves;
			}
			board[pos] = null;
		}

		public static bool? WinTest(bool?[] board)
		{
			for (int i = 0; i < 3; i++)
			{
				if (board[0 + i] == true && board[3 + i] == true && board[6 + i] == true) return true;
				if (board[0 + i] == false && board[3 + i] == false && board[6 + i] == false) return false;
				if (board[0 + i * 3] == true && board[1 + i * 3] == true && board[2 + i * 3] == true) return true;
				if (board[0 + i * 3] == false && board[1 + i * 3] == false && board[2 + i * 3] == false) return false;
			}
			if (board[0] == true && board[4] == true && board[8] == true) return true;
			if (board[0] == false && board[4] == false && board[8] == false) return false;
			if (board[2] == true && board[4] == true && board[6] == true) return true;
			if (board[2] == false && board[4] == false && board[6] == false) return false;
			return null;
		}

	}
}
