/*
internal class Program
{
    private static void Main(string[] args)
    {
        Console.WriteLine("Enter a number more than 1 digit:");
        int a = Convert.ToInt32(Console.ReadLine());
        int b = a;
        int s = 0;
        int d = a.ToString().Length;
        while (a > 0)
        {
            int digit = a % 10;
            s += (int)Math.Pow(digit, d);
            a /= 10;
        }
        if (b == s)
        {
            Console.WriteLine($"{b} is an Armstrong Number");
        }
        else
        {
            Console.WriteLine($"{b} is not an Armstrong Number");
        }
    }
}
*/
internal class Program
{
    public void checkArmstrong(int a)
    {
        int b = a;
        int s = 0;
        int d = a.ToString().Length;
        while (a > 0)
        {
            int digit = a % 10;
            s += (int)Math.Pow(digit, d);
            a /= 10;
        }
        if (b == s)
        {
            Console.WriteLine($"{b} is an Armstrong Number");
        }
        else
        {
            Console.WriteLine($"{b} is not an Armstrong Number");
        }
    }
    private static void Main(string[] args)
    {
        Console.WriteLine("Enter a number more than 1 digit:");
        int a = Convert.ToInt32(Console.ReadLine());

        Program obj = new Program();
        obj.checkArmstrong(a);
    }
}