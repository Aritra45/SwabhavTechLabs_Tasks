using System;
using System.Text;
using static System.Runtime.InteropServices.JavaScript.JSType;

internal class Program
{

    public static void CalculateNotes(ref int[] denomination, ref int[] noOfNotes, ref int number)
    {
        for (int i = 0; i < denomination.Length; i++)
        {
            noOfNotes[i] = number / denomination[i];
            number %= denomination[i];
        }
    }
    public static void CheckArrayElement(ref string[] range, char c, ref bool isInvalid)
    {
        isInvalid = true;

        for (int i = 0; i < range.Length; i++)
        {
            if (range[i] == c.ToString())
            {
                isInvalid = false;
                break; 
            }
        }
    }

    public static bool CheckString(ref string[] range, ref string amount, ref bool isInvalid)
    {
        foreach (char c in amount)
        {
            CheckArrayElement(ref range, c, ref isInvalid);
            if (isInvalid)
            {
                break; 
            }
        }
        return isInvalid;
    }
    
    private static void Main(string[] args)
    {
        bool calculateAgain = true;
        while (calculateAgain)
        {
            bool isInvalid = true;
            string amount = "";
            while (isInvalid)
            {
                Console.WriteLine("Enter Amount (must be a multiple of 100 and not exceed 50000): ");
                amount = Console.ReadLine();
                string[] range = { "0", "1", "2", "3", "4", "5", "6", "7", "8", "9" };

                CheckString(ref range, ref amount, ref isInvalid);


                if (isInvalid == true)
                {
                    Console.WriteLine("Invalid input. Please enter a numeric value.");
                }
                else
                {
                    int number = Convert.ToInt32(amount);

                    if (number > 50000 || number % 100 != 0)
                    {
                        Console.WriteLine("Invalid input. Please enter an amount less than or equal to 50000 and a multiple of 100.");
                        continue;
                    }

                    int[] denomination = { 2000, 500, 200, 100 };
                    int[] noOfNotes = new int[denomination.Length];

                    CalculateNotes(ref denomination, ref noOfNotes, ref number);

                    Console.WriteLine("Currency Denomination:");
                    for (int i = 0; i < denomination.Length; i++)
                    {
                        Console.WriteLine($"{denomination[i]}: {noOfNotes[i]}");
                    }
                }
            }

            

            Console.WriteLine(" ");
            Console.WriteLine("Would you like to Calculate again? (Y/N)");

            string response = " ";
            while (response != "Y" && response != "N")
            {
                response = Console.ReadLine().ToUpper();
                if (response == "Y")
                {
                    calculateAgain = true;
                    Console.WriteLine(" ");
                }
                else if (response == "N")
                {
                    calculateAgain = false;
                    Console.WriteLine(" ");
                    Console.WriteLine("!!!Bye!!!");
                }
                else if (response != "Y" && response != "N")
                {
                    Console.WriteLine("Invalid Input");
                    Console.WriteLine("Please Enter Valid Input");
                }
            }
        }
    }
}