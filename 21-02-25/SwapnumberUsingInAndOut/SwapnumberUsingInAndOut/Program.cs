internal class Program
{
    void GetValues(out int a, out int b)
    {
        a = 10;
        b = 20;
    }

    void SwapValues(ref int a, ref int b)
    {
        a = a ^ b;
        b = a ^ b;
        a = a ^ b;
    }

    void DisplayValues(in int a, in int b)
    {
        Console.WriteLine($"After: a:{a}, b:{b}");
    }
    private static void Main(string[] args)
    {
        int x, y;
        Program p = new Program();
        p.GetValues(out x, out y);
        Console.WriteLine($"Before: a:{x}, b:{y}");
        p. SwapValues(ref x, ref y);
        p.DisplayValues(in x, in y);
    }
}