/*
internal class Program
{
    private static void Main(string[] args)
    {
        Console.WriteLine("Enter the length of the series:");
        int a = Convert.ToInt32(Console.ReadLine());
        int b = 0;
        int c = 1;
        int d;
        Console.WriteLine($"Fibonacii Series of {a}");
        if (a <= 0)
        {
            Console.WriteLine("Enter a Positive Number");
        }
        else if (a == 1)
        {
            Console.WriteLine($"{b}");
        }
        else
        {
            Console.WriteLine($"{b}");
            Console.WriteLine($"{c}");
            for (int i=2; i<a; i++)
            {
                d = b + c;
                Console.WriteLine(d);
                b = c;
                c = d;
            }
        }
    }
}
*/
internal class Program
{
    public void doFibonacii(int a)
    {
        int b = 0;
        int c = 1;
        int d;
        Console.WriteLine($"Fibonacii Series of {a}");
        if (a <= 0)
        {
            Console.WriteLine("Enter a Positive Number");
        }
        else if (a == 1)
        {
            Console.WriteLine($"{b}");
        }
        else
        {
            Console.WriteLine($"{b}");
            Console.WriteLine($"{c}");
            for (int i = 2; i < a; i++)
            {
                d = b + c;
                Console.WriteLine(d);
                b = c;
                c = d;
            }
        }
    }
    private static void Main(string[] args)
    {
        Console.WriteLine("Enter the length of the series:");
        int a = Convert.ToInt32(Console.ReadLine());

        Program obj = new Program();
        obj.doFibonacii(a);
    }
}