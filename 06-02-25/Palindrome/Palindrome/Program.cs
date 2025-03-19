/*using System;

internal class Program
{
    private static void Main(string[] args)
    {
        Console.WriteLine("Enter any Number more than One Digit:");
        int a = (int)(Convert.ToDouble(Console.ReadLine()));
        int b = a;
        int r = 0;
        while (a > 0)
        {
            int digit = a % 10;
            r = (r * 10) + digit;
            a /= 10;
        }
        if (b == r)
        {
            Console.WriteLine($"{b} is a Palindrom Number");
        }
        else {
            Console.WriteLine($"{b} is not a Palindrom Number");
        }
    }
}*/

using System;

internal class Program
{
    public void checkPalindrome(int a)
    {
        int b = a;
        int r = 0;
        while (a > 0)
        {
            int digit = a % 10;
            r = (r * 10) + digit;
            a /= 10;
        }
        if (b == r)
        {
            Console.WriteLine($"{b} is a Palindrom Number");
        }
        else
        {
            Console.WriteLine($"{b} is not a Palindrom Number");
        }
    }
    private static void Main(string[] args)
    {
        Console.WriteLine("Enter any Number more than One Digit:");
        int a = Convert.ToInt32(Console.ReadLine());

        Program obj = new Program();
        obj.checkPalindrome(a);
    }
}