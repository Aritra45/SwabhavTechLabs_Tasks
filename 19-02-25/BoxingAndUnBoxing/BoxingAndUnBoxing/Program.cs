using System.Collections;

internal class Program
{
    private static void Main(string[] args)
    {
        ArrayList p = new ArrayList();

        Double x = 35.45;
        p.Add(x);
        int y = ((int)((double)p[0]));
        Console.WriteLine(y);
    }
}