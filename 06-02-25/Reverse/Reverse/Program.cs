/*
internal class Program
{
    private static void Main(string[] args)
    {
        Console.WriteLine("Enter any number more than 1 digit:");
        int a = Convert.ToInt32(Console.ReadLine());
        int b = a;
        int r = 0;
        while (a > 0)
        {
            int digit = a % 10;
            r = (r * 10) + digit;
            a /= 10;
        }
        Console.WriteLine($"{r} is reverse of {b}");
    }
}
*/
internal class Program
{
    public void doReverse(int a)
    {
        int b = a;
        int r = 0;
        while (a > 0)
        {
            int digit = a % 10;
            r = (r * 10) + digit;
            a /= 10;
        }
        Console.WriteLine($"{r} is reverse of {b}");
    }
    private static void Main(string[] args)
    {
        Console.WriteLine("Enter any number more than 1 digit:");
        int a = Convert.ToInt32(Console.ReadLine());

        Program obj = new Program();
        obj.doReverse(a);
    }
}