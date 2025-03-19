using System;
using System.Formats.Asn1;
using System.Reflection.Metadata.Ecma335;
using System.Runtime.InteropServices;
using System.Text;

internal class Program
{
    public static void CalculateBill(ref double numberOfUnits, ref double charge, ref int meter_Charge)
    {
        if (numberOfUnits <= 100)
        {
            charge = numberOfUnits * 5;
        }
        else if (numberOfUnits <= 250)
        {
            charge = numberOfUnits * 10;
        }
        else
        {
            charge = numberOfUnits * 20;
        }
    }

    public static void CheckArrayInput(ref string[] range, ref string num, ref bool isInvalid, ref int i, char c)
    {
        if (range[i] == c.ToString())
        {
            isInvalid = false;
        }
        else
        {
            isInvalid = true;
        }
    }

    public static void TakeEachElementFromString(ref string[] range, ref string num, ref bool isInvalid, ref int i)
    {
        foreach (char c in num)
        {
            CheckArrayInput(ref range, ref num, ref isInvalid, ref i, c);
        }
    }

    public static bool CheckInput(ref string[] range, ref string num, ref bool isInvalid, ref double charge, ref int meter_Charge)
    {
        for (int i = 0; i <= range.Length - 1; i++)
        {
            TakeEachElementFromString(ref range, ref num, ref isInvalid, ref i);

            if (isInvalid == true)
            {
                break;
            }
        }

        return isInvalid;
    }

    /*
    public static void CheckResponse(ref string billAgain)
    {
        billAgain = Console.ReadLine().ToUpper();

        if (billAgain == "Y")
        {
            billAgain = true;
        }
        else if (billAgain == "N")
        {
            billAgain = false;
        }
        else if (billAgain != "Y" && billAgain != "N")
        {
            Console.WriteLine("Please Enter a Valid Input");
        }
    }
    */

    private static void Main(string[] args)
    {
        string billAgain = "Y";

        while (billAgain == "Y")
        {
            bool isInvalid = true;

            while (isInvalid)
            {
                Console.WriteLine("Enter Number of Units Consumed: ");
                string num = Console.ReadLine().ToLower();

                int meter_Charge = 75;
                double charge = 0;
                string[] range = { "0", "1", "2", "3", "4", "5", "6", "7", "8", "9" };

                CheckInput(ref range, ref num, ref isInvalid, ref charge, ref meter_Charge);

                if (isInvalid == true)
                {
                    Console.WriteLine("Invalid Input!!! Please Enter a Number\n");
                }
                else
                {
                    double numberOfUnits = Convert.ToDouble(num);
                    CalculateBill(ref numberOfUnits, ref charge, ref meter_Charge);
                    double Total_Water_Bill = charge + meter_Charge;
                    Console.WriteLine($"Total Water Bill: {Total_Water_Bill}\n");
                }
            }

            Console.WriteLine("Would You Like To Bill Again? (Y/N)");
            bool inValid = true;

            while (inValid)
            {
                billAgain = Console.ReadLine().ToUpper();

                if (billAgain != "Y" && billAgain != "N")
                {
                    Console.WriteLine("Please Enter Valid Input");
                    inValid = true;
                }
                else
                {
                    inValid = false;
                }
            }
        }
    }
}
