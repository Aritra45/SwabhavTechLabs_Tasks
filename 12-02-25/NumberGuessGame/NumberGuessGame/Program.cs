using System;

internal class Program
{
    public void NumberGuess()
    {
        bool playAgain = true;

        while (playAgain)
        {
            string[] Range = { "1", "2", "3", "4", "5", "6", "7", "8", "9", "10" };
            Random r = new Random();
            int RandomNumber = r.Next(1, 10);
            int NumberOfGuesses = 0;

            Console.WriteLine("Guess a number between 1 to 10:");
            Console.WriteLine("!!!You have 3 chances to guess the currect number!!!");

            while (NumberOfGuesses < 3)
            {
                Console.Write("Enter Your Number: ");
                string num = Console.ReadLine();
                int number = 0;
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

                if (number < 1 || number > 10)
                {
                    Console.WriteLine("!!!Please enter a number between 1 and 10!!!");
                    continue;
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
                    break;
                }
                NumberOfGuesses++;
            }

            if (NumberOfGuesses == 3)
            {
                Console.WriteLine($"You lost all chances! The correct number was {RandomNumber}.");
            }

            Console.WriteLine(" ");
            Console.WriteLine("Would you like to play again? (Y/N)");

            string response = " ";
            while (response != "Y" && response != "N")
            {
                response = Console.ReadLine().ToUpper();
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
        }
    }
    private static void Main(string[] args)
    {
        Program obj = new Program();
        obj.NumberGuess();
    }
}