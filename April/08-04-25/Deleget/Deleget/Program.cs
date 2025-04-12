internal class Program
{
    public delegate void GrandFather(string name);

    public static void Father(string name)
    {
        Console.WriteLine($"Hey I am {name}.....");
    }

    public static void Uncle(string name)
    {
        Console.WriteLine($"Hey I am {name}");
    }
    private static void Main(string[] args)
    {
        //GrandFather grandFather = Father;
        //grandFather += Uncle;
        //grandFather("Siddhartha");

        GrandFather grand = delegate (string name)
        {
            Console.WriteLine($"Hi {name}");
        };
        grand += delegate (string name)
        {
            Console.WriteLine($"bye {name}");
        };
        grand("BUBU");
    }
}