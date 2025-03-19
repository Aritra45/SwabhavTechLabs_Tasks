using System;

namespace TicTacToeGame
{
    internal class TicTac : Board
    {
        //public Board board = new Board();
        public MarkType turn;

        public TicTac()
        {
            turn = MarkType.X;
        }

        public bool PlayTurn(int loc)
        {
            if (IsBoardFull())
            {
                Console.WriteLine("Game Over: The board is full!");
                return false;
            }

            try
            {
                SetCellMark(loc, turn);
                if (CheckWinner(turn))
                {
                    Console.WriteLine($"\nGame Over: Player {turn} wins!");
                    return false;
                }

                if (turn == MarkType.X)
                    turn = MarkType.O;
                else
                    turn = MarkType.X;
            }
            catch (System.Exception e)
            {
                Console.WriteLine(e.Message);
            }

            return true;
        }

        public void DisplayTicTacBoard()
        {
            DisplayBoard();
        }
    }
}
