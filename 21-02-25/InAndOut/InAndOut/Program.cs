using System;

internal class Program
{
    public int GetValues(out int a, int b){

        a = 10;
        b = 20;
        return b;
    }

    void Display(in int a, int b){

        Console.WriteLine($"In Display method, a: {a+10}, b: {b-10}");
    }

    private static void Main(string[] args){

        int x, y=0;
        Program obj = new Program();
        y = obj.GetValues(out x, y);

        Console.WriteLine("x: " + x + " , " + "y: " + y);

        obj.Display(in x, y); 
    }
}
