using System;
using System.Numerics;
using static System.Runtime.InteropServices.JavaScript.JSType;

internal class Program
{
    public static void CheckLengthOfArray(ref string[] Range, ref string num, ref int number)
    {
        for (int i = 0; i <= Range.Length - 1; i++)
        {

            if (Range[i] == num)
            {
                number = Convert.ToInt32(num);
                break;
            }
            else if (i == Range.Length - 1)
            {
                Console.WriteLine("Invalid Input");
            }
        }
    }

    public static void CheckTheGuessednumber(ref int number, ref int RandomNumber, ref int NumberOfGuesses, ref string[] Range)
    {
        if (number < 1 || number > 10)
        {
            Console.WriteLine("!!!Please enter a number between 1 and 10!!!");
            TakeInputAndCheckGuess(ref NumberOfGuesses, ref Range, ref RandomNumber);
            //continue;
        }


        if (number > RandomNumber)
        {
            Console.WriteLine($"{number} is too high.");
        }
        else if (number < RandomNumber)
        {
            Console.WriteLine($"{number} is too low.");
        }
        else
        {
            Console.WriteLine("You guessed the correct number.");
            bool playAgain = false;
        }
    }

    public static  void TakeInputAndCheckGuess(ref int NumberOfGuesses, ref string[] Range, ref int RandomNumber)
    {
        while (NumberOfGuesses < 3)
        {
            Console.Write("Enter Your Number: ");
            string num = Console.ReadLine();
            int number = 0;
            CheckLengthOfArray(ref Range, ref num, ref number);
            CheckTheGuessednumber(ref number, ref RandomNumber, ref NumberOfGuesses, ref Range);

            NumberOfGuesses++;
        }
    }

    public static void CheckChances(ref int NumberOfGuesses, ref int RandomNumber)
    {
        if (NumberOfGuesses == 3)
        {
            Console.WriteLine($"You lost all chances! The correct number was {RandomNumber}.");
        }
    }

    public static void CheckResponse(ref string response, ref bool playAgain)
    {
        if (response == "Y")
        {
            playAgain = true;
            Console.WriteLine(" ");
        }
        else if (response == "N")
        {
            playAgain = false;
            Console.WriteLine(" ");
            Console.WriteLine("!!!Thanks for playing!!!");
        }
        else if (response != "Y" && response != "N")
        {
            Console.WriteLine("Invalid Input");
            Console.WriteLine("Please Enter Valid Input");
        }
    }

    public static void CheckPlayAgainOrNot(ref string response, ref bool playAgain)
    {
        while (response != "Y" && response != "N")
        {
            response = Console.ReadLine().ToUpper();
            CheckResponse(ref response, ref playAgain);
        }
    }

    public static void TakeRandomNumber(ref bool playAgain)
    {
        while (playAgain)
        {
            string[] Range = { "1", "2", "3", "4", "5", "6", "7", "8", "9", "10" };
            Random r = new Random();
            int RandomNumber = r.Next(1, 10);
            int NumberOfGuesses = 0;

            Console.WriteLine("Guess a number between 1 to 10:");
            Console.WriteLine("!!!You have 3 chances to guess the currect number!!!");
            TakeInputAndCheckGuess(ref NumberOfGuesses, ref Range, ref RandomNumber);
            CheckChances(ref NumberOfGuesses, ref RandomNumber);

            Console.WriteLine(" ");
            Console.WriteLine("Would you like to play again? (Y/N)");

            string response = " ";
            CheckPlayAgainOrNot(ref response, ref playAgain);
        }
    }

    public void NumberGuess()
    {
        bool playAgain = true;
        TakeRandomNumber(ref playAgain);
    }
    private static void Main(string[] args)
    {
        Program obj = new Program();
        obj.NumberGuess();
    }
}
