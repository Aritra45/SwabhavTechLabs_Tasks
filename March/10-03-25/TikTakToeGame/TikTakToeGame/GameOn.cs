using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TicTacToeGame.Exception;

namespace TicTacToeGame
{
    internal class Game
    {
        TicTac tictac = new TicTac();
        
        public void Start()
        {
            tictac.DisplayTicTacBoard();
            bool playGame = true;

            while (playGame && !tictac.board.IsBoardFull())
            {
                try
                {
                    Console.WriteLine($"\n \n Current Turn Player {tictac.turn}");
                    Console.Write("Enter a cell location (0-8): ");
                    int loc = Convert.ToInt32(Console.ReadLine());
                    if (loc < 0 || loc > 8)
                    {
                        throw new InvalidInputException("Invalid input. Please enter a number between 0 and 8.");
                    }
                    playGame = tictac.PlayTurn(loc);
                    tictac.DisplayTicTacBoard();

                    if (!playGame)
                        break;

                    if (tictac.board.IsBoardFull() && !tictac.board.CheckWinner(MarkType.X) && !tictac.board.CheckWinner(MarkType.O))
                    {
                        Console.WriteLine("Game Over: It's a draw!");
                    }
                }
                catch (InvalidInputException ex)
                {
                    Console.WriteLine(ex.Message);
                }
            }
        }

    }
}
