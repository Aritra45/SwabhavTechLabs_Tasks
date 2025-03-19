
internal class Program
{
    static void CallByValue(int a)
    {
        a = a + 10;
        Console.WriteLine(a);
    }
    private static void Main(string[] args)
    {
        int a = 5;
        CallByValue(a);
        Console.WriteLine(a);
    }
}

/*
internal class Program
{
    static void CallByRef(ref int a)
    {
        a = a + 10;
        Console.WriteLine(a);
    }
    private static void Main(string[] args)
    {
        int a = 5;
        CallByRef(ref a);
        Console.WriteLine(a);
    }
}*/