
//Stack Example
/*
using System.Reflection;

internal class Program
{
    public static void MethodA()
    {
        Console.WriteLine("A");
        MethodB();
    }
    public static void MethodB()
    {
        Console.WriteLine("B");
        MethodC();
    }
    public static void MethodC()
    {
        Console.WriteLine("C");
        
    }
    private static void Main(string[] args)
    {
        Console.WriteLine("start");
        MethodA();
        Console.WriteLine("End");
    }
}
*/


//Stack Overflow Fix
using System.Reflection;

internal class Program
{
    public static void Recursive(int count)
    {
        if (count == 0) 
            return;
        Console.WriteLine(count);
        Recursive(count - 1);
    }
    private static void Main(string[] args)
    {
        Recursive(5);
    }
}