using System;
using TicTacToeGame;
using TicTacToeGame.Exception;

internal class Program
{
    private static void Main(string[] args)
    {
        TicTac tictac = new TicTac();
        tictac.DisplayTicTacBoard();
        bool playGame = true;

        while (playGame && !tictac.IsBoardFull())
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

                if (tictac.IsBoardFull() && !tictac.CheckWinner(MarkType.X) && !tictac.CheckWinner(MarkType.O))
                {
                    Console.WriteLine("Game Over: It's a draw!");
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }

    }
}
