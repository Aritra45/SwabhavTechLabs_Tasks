using System;

internal class Program
{
    public void PlayerTakeInput(ref int p1RoundScore, ref int p1Sum, ref string Player1, ref int TotalPoints, Random r)
    {
        bool playGame = true;
        while (playGame)
        {
            Console.WriteLine($"Your turn score is {p1RoundScore} and your total score is {p1Sum}");
            Console.Write("Press 'R' to Roll or 'H' to Hold: ");
            string roll = Console.ReadLine().ToUpper();

            PlayerRollAndHold(ref roll, ref Player1, ref p1RoundScore, ref p1Sum, ref TotalPoints, r, ref playGame);
        }
    }

    public void PlayerRollAndHold(ref string roll, ref string Player1, ref int p1RoundScore, ref int p1Sum, ref int TotalPoints, Random r, ref bool playGame)
    {
        if (roll != "R" && roll != "H")
        {
            Console.WriteLine("Invalid Input. Please enter 'R' or 'H'.");
            PlayerTakeInput(ref p1RoundScore,ref  p1Sum, ref Player1, ref TotalPoints, r);
            //continue;
        }

        if (roll == "R")
        {
            int random = r.Next(1, 7);
            Console.WriteLine($"{Player1} rolled: {random}");
            CheckPlayerRollPoint(ref random, ref Player1, ref p1RoundScore, ref p1Sum, ref playGame);

        }
        else if (roll == "H")
        {
            p1Sum += p1RoundScore;
            Console.WriteLine($"{Player1} holds. Turn score: {p1RoundScore}. Total score: {p1Sum}.");
            playGame = false;
            //return;
        }

        if ((p1Sum + p1RoundScore) >= TotalPoints)
        {

            Console.WriteLine($"{Player1} holds. Turn score: {p1RoundScore}. Total score: {p1Sum + p1RoundScore}.");
            Console.WriteLine($" ");
            Console.WriteLine($"{Player1} wins with {p1Sum + p1RoundScore} points!");
            return;
        }
    }

        public static void CheckPlayerRollPoint(ref int random, ref string Player1, ref int p1RoundScore, ref int p1Sum, ref bool playGame)
    {
        if (random == 1)
        {
            Console.WriteLine($"{Player1} rolled a {random}! Turn over, no points earned and total Score {p1Sum}");

            p1RoundScore = 0;
            playGame = false;
        }

        else if (random != 1)
        {
            p1RoundScore += random;
            Console.WriteLine($"Your turn score is {p1RoundScore} and your total score is {p1Sum}");
        }
    }

    /*public void Player2TakeInput(ref int p2RoundScore, ref int p2Sum, ref string Player2, ref int TotalPoints, Random r)
    {
        while (true)
        {
            Console.WriteLine($"Your turn score is {p2RoundScore} and your total score is {p2Sum}");
            Console.Write("Press 'R' to Roll or 'H' to Hold: ");
            string roll = Console.ReadLine().ToUpper();
            Player1RollAndHold(ref roll, ref Player2, ref p2RoundScore, ref p2Sum, ref TotalPoints, r);

        }
    }*/
/*
        public void Player2RollAndHold(ref string roll, ref string Player2, ref int p2RoundScore, ref int p2Sum, ref int TotalPoints, Random r)
    {
        if (roll != "R" && roll != "H")
        {
            Console.WriteLine("Invalid Input. Please enter 'R' or 'H'.");
            Player2TakeInput(ref p2RoundScore, ref p2Sum, ref Player2, ref TotalPoints, r);
            //continue;
        }

        if (roll == "R")
        {
            int random = r.Next(1, 7);
            Console.WriteLine($"{Player2} rolled: {random}");
            CheckPlayer2RollPoint(random, ref Player2, ref p2RoundScore, ref p2Sum);

        }
        else if (roll == "H")
        {
            p2Sum += p2RoundScore;
            Console.WriteLine($"{Player2} holds. Turn score: {p2RoundScore}. Total score: {p2Sum}.");
            return;
        }

        if ((p2Sum + p2RoundScore) >= TotalPoints)
        {

            Console.WriteLine($"Turn score: {p2RoundScore}. Total score: {p2Sum + p2RoundScore}.");
            Console.WriteLine($" ");
            Console.WriteLine($"{Player2} wins with {p2Sum + p2RoundScore} points!");
            return;
        }
    }
    */
/*
    public static void CheckPlayer2RollPoint(int random, ref string Player2, ref int p2RoundScore, ref int p2Sum)
    {
        if (random == 1)
        {
            Console.WriteLine($"{Player2} rolled a 1! Turn over, no points earned and total Score {p2Sum}");
            p2RoundScore = 0;
            return;
        }
        else
        {
            p2RoundScore += random;
            Console.WriteLine($"Your turn score is {p2RoundScore} and your total score is {p2Sum}");
        }
    }
*/


    public void CheckTotalPoint(Random r, ref string Player1, ref string Player2, ref int p1Sum, ref int p2Sum, ref int TotalPoints)
    {
        while (p1Sum < TotalPoints && p2Sum < TotalPoints)
        {
            int p1RoundScore = 0;
            Console.WriteLine($" ");
            Console.WriteLine($"{Player1}'s Turn");

            PlayerTakeInput(ref p1RoundScore, ref p1Sum, ref Player1, ref TotalPoints, r);

            int p2RoundScore = 0;
            Console.WriteLine($" ");
            Console.WriteLine($"{Player2}'s Turn");

            PlayerTakeInput(ref p2RoundScore, ref p2Sum, ref Player2, ref TotalPoints, r);


        }
    }
    public void PigDice()
    {
        string Player1 = "Aritra";
        string Player2 = "Rup";
        int p1Sum = 0, p2Sum = 0;
        int TotalPoints = 20;
        Random r = new Random();

        CheckTotalPoint(r, ref Player1, ref Player2, ref p1Sum, ref p2Sum, ref TotalPoints);
    }

    private static void Main(string[] args)
    {
        Program obj = new Program();
        obj.PigDice();
    }
}
