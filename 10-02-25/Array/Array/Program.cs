/*
using System.Globalization;

internal class Program
{
    private static void Main(string[] args)
    {
        int[] array = { 1, 2, 3, 4, 5 };
        for (int i = array.Length-1; i >= 0; i--)
        {
            Console.WriteLine(array[i]);
        }
    }
}
*/

using System.Globalization;

using System;

internal class Program
{
    public int[] ReversedArray(int[] array)
    {
        int[] reversedArray = new int[array.Length];
        int numberOfIndex = array.Length-1;
        foreach (int element in array)
        {
            reversedArray[numberOfIndex] = element;
            numberOfIndex--;
        }
        return reversedArray;
    }

    private static void Main(string[] args)
    {
        int[] array = { 1, 2, 3, 4, 5 };

        Program obj = new Program();
        int[] finalArray = obj.ReversedArray(array);

        foreach (int element in finalArray)
        {
            Console.WriteLine(element);
        }
    }
}