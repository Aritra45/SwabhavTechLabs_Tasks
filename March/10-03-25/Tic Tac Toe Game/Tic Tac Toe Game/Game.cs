using System;
using System.Collections.Generic;
using System.ComponentModel.Design;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tic_Tac_Toe_Game
{
    public class Game
    {
        private Board board;
        public MarkType currentPlayer;

        public Game()
        {
            board = new Board();
            currentPlayer = MarkType.X;
        }

        public void Start()
        {
            bool gameEnded = false;

            while (!gameEnded)
            {
                board.DisplayBoard();
                Console.WriteLine($"Player {currentPlayer}, enter your move row and column ):");
                var input = Console.ReadLine().Split(' ');
                int row = Convert.ToInt32(input[0]);
                int col = Convert.ToInt32(input[1]);

                try
                {
                    board.SetCellMark(row, col, currentPlayer);

                    if (IsWinner(currentPlayer))
                    {
                        board.DisplayBoard();
                        Console.WriteLine($"Player {currentPlayer} wins!");
                        gameEnded = true;
                    }
                    else if (board.IsBoardFull())
                    {
                        board.DisplayBoard();
                        Console.WriteLine("The game is a draw!");
                        gameEnded = true;
                    }
                    else
                    {
                        if (currentPlayer == MarkType.X)
                        {
                            currentPlayer = MarkType.O;
                        }
                        else
                        {
                            currentPlayer = MarkType.X;
                        }
                    }
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                }
            }
        }

        public bool IsWinner(MarkType player  )
        {
 
            return CheckRow(player) || CheckColoumn(player) || CheckDiagonal(player) ;
        }

        public bool CheckRow(MarkType player)
        {
            for (int i = 0; i < 3; i++)
            {
                if ((board.GetMarkAt(i, 0) == player && board.GetMarkAt(i, 1) == player && board.GetMarkAt(i, 2) == player)) 
                return true;
            }
            return false;
        }

        private  bool CheckColoumn(MarkType player)
        {
            for (int i = 0; i < 3; i++)
            {
                if ((board.GetMarkAt(0, i) == player && board.GetMarkAt(1, i) == player && board.GetMarkAt(2, i) == player)) 
                return true;
            }
            return false;
        }

        private bool CheckDiagonal(MarkType player)
        {
            if ((board.GetMarkAt(0, 0) == player && board.GetMarkAt(1, 1) == player && board.GetMarkAt(2, 2) == player) ||
               (board.GetMarkAt(0, 2) == player && board.GetMarkAt(1, 1) == player && board.GetMarkAt(2, 0) == player))
            {
                return true;
            }
            return false;
        }


    }
}
