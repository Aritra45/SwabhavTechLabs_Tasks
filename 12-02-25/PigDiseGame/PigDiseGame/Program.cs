using System;

internal class Program
{
    public void PigDice()
    {
        string Player1 = "Aritra";
        string Player2 = "Rup";
        int p1Sum = 0, p2Sum = 0;
        int TotalPoints = 20;
        Random r = new Random();

        while (p1Sum < TotalPoints && p2Sum < TotalPoints)
        {
            int p1RoundScore = 0;
            Console.WriteLine($" ");
            Console.WriteLine($"{Player1}'s Turn");

            while (true)
            {
                Console.WriteLine($"Your turn score is {p1RoundScore} and your total score is {p1Sum}");
                Console.Write("Press 'R' to Roll or 'H' to Hold: ");
                string roll = Console.ReadLine().ToUpper();

                if (roll != "R" && roll != "H")
                {
                    Console.WriteLine("Invalid Input. Please enter 'R' or 'H'.");
                    continue;
                }

                if (roll == "R")
                {
                    int rInt = r.Next(1, 7);
                    Console.WriteLine($"{Player1} rolled: {rInt}");

                    if (rInt == 1)
                    {
                        Console.WriteLine($"{Player1} rolled a {rInt}! Turn over, no points earned and total Score {p1Sum}");
                        
                        p1RoundScore = 0;
                        break;
                    }
                    
                    else if (rInt != 1)
                    {
                        p1RoundScore += rInt;
                        Console.WriteLine($"Your turn score is {p1RoundScore} and your total score is {p1Sum}");
                    }
                }
                else if (roll == "H")
                {
                    p1Sum += p1RoundScore;
                    Console.WriteLine($"{Player1} holds. Turn score: {p1RoundScore}. Total score: {p1Sum}.");
                    break;
                }

                if ((p1Sum + p1RoundScore) >= TotalPoints)
                {
                    
                    Console.WriteLine($"{Player1} holds. Turn score: {p1RoundScore}. Total score: {p1Sum + p1RoundScore}.");
                    Console.WriteLine($" ");
                    Console.WriteLine($"{Player1} wins with {p1Sum + p1RoundScore} points!");
                    return;
                }
            }

            int p2RoundScore = 0;
            Console.WriteLine($" ");
            Console.WriteLine($"{Player2}'s Turn");

            while (true)
            {
                Console.WriteLine($"Your turn score is {p2RoundScore} and your total score is {p2Sum}");
                Console.Write("Press 'R' to Roll or 'H' to Hold: ");
                string roll = Console.ReadLine().ToUpper();

                if (roll != "R" && roll != "H")
                {
                    Console.WriteLine("Invalid Input. Please enter 'R' or 'H'.");
                    continue;
                }

                if (roll == "R")
                {
                    int rInt = r.Next(1, 7);
                    Console.WriteLine($"{Player2} rolled: {rInt}");

                    if (rInt == 1)
                    {
                        Console.WriteLine($"{Player2} rolled a 1! Turn over, no points earned and total Score {p2Sum}");
                        p2RoundScore = 0;
                        break;
                    }
                    else
                    {
                        p2RoundScore += rInt;
                        Console.WriteLine($"Your turn score is {p2RoundScore} and your total score is {p2Sum}");
                    }
                }
                else if (roll == "H")
                {
                    p2Sum += p2RoundScore;
                    Console.WriteLine($"{Player2} holds. Turn score: {p2RoundScore}. Total score: {p2Sum}.");
                    break;
                }

                if ((p2Sum + p2RoundScore) >= TotalPoints)
                {
                    
                    Console.WriteLine($"Turn score: {p2RoundScore}. Total score: {p2Sum + p2RoundScore}.");
                    Console.WriteLine($" ");
                    Console.WriteLine($"{Player2} wins with {p2Sum + p2RoundScore} points!");
                    return;
                }
            }
        }
    }

    private static void Main(string[] args)
    {
        Program obj = new Program();
        obj.PigDice();
    }
}
