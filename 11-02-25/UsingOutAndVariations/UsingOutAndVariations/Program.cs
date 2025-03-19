/*
internal class Program
{
    void GetValues(out int a, out int b)
    {
        a = 10;
        b = 20;
    }
    private static void Main(string[] args)
    {
        int x, y;
        Program obj = new Program();
        obj.GetValues(out x, out y);
        Console.WriteLine("x: "+x+" , "+"y: "+y);
    }
}
*/

/*
internal class Program
{
    void GetValues(ref int a, out int b)
    {
        a = 10;
        b = 20;
    }
    private static void Main(string[] args)
    {
        int x=0, y;
        Program obj = new Program();
        obj.GetValues(ref x, out y);
        Console.WriteLine("x: " + x + " , " + "y: " + y);
    }
}
*/

/*
internal class Program
{
    int GetValues(ref int a, out int b)
    {
        a = 10;
        b = 20;
        return a;
    }
    private static void Main(string[] args)
    {
        int x = 0, y;
        Program obj = new Program();
        obj.GetValues(ref x, out y);
        Console.WriteLine("x: " + x + " , " + "y: " + y);
    }
}
*/


internal class Program
{
    int GetValues(int a, out int b)
    {
        a = 10;
        b = 20;
        return a;
    }
    private static void Main(string[] args)
    {
        int x=0, y;
        Program obj = new Program();
        x = obj.GetValues(x, out y);
        Console.WriteLine("x: " + x + " , " + "y: " + y);
    }
}







//Multiple Values Using Tuples 

/*
internal class Program
{
    (int,string) GetValues(int a, string b)
    {
        a = 10;
        b = "Aritra";
        return (a,b);
    }
    private static void Main(string[] args)
    {
        int x=0;
        string y="";
        Program obj = new Program();
        var value = obj.GetValues(x, y);
        Console.WriteLine("x: " + value.Item1 + " , " + "y: " + value.Item2);
    }
}
*/

/*
internal class Program
{
    (int, string, bool) GetValues(int a)
    {
        a = 10;
        string b = "Aritra";
        bool c = false;
        return (a, b, c);
    }
    private static void Main(string[] args)
    {
        int x = 0;
        string y = "";
        Program obj = new Program();
        var value = obj.GetValues(x);
        Console.WriteLine("x: " + value.Item1 + " , " + "y: " + value.Item2 + " , " + "z: " + value.Item3);
    }
}
*/

/*
internal class Program
{
    (int, string, string) GetValues(int a)
    {
        a = 10;
        string b = "Aritra";
        string c = "Deb";
        return (a, b, c);
    }
    private static void Main(string[] args)
    {
        int x = 0;
        string y = "";
        string z = "";
        Program obj = new Program();
        var value = obj.GetValues(x);
        Console.WriteLine("x: " + value.Item1 + " , " + "y: " + value.Item2 + " , " + "z: " + value.Item3);
    }
}
*/

/*
internal class Program
{
    (int, int) GetValues(int a)
    {
        a = 10;
        int b = 20;
        return (a, b) ;
    }
    private static void Main(string[] args)
    {
        int x = 0, y;
        Program obj = new Program();
        var value = obj.GetValues(x);
        Console.WriteLine("x: " + value.Item1 + " , " + "y: " + value.Item2);
    }
}
*/

/*
internal class Program
{
    (int, int) GetValues(int a, int b)
    {
        a = 10;
        b = 20;
        return (a, b);
    }
    private static void Main(string[] args)
    {
        int x = 0, y=0;
        Program obj = new Program();
        var value = obj.GetValues(x,y);
        Console.WriteLine("x: " + value.Item1 + " , " + "y: " + value.Item2);
    }
}
*/

/*
internal class Program
{
    (int, bool) GetValues(int a, bool b)
    {
        a = 10;
        b = true;
        return (a, b);
    }
    private static void Main(string[] args)
    {
        int x = 0;
        bool y= false;
        Program obj = new Program();
        var value = obj.GetValues(x, y);
        Console.WriteLine("x: " + value.Item1 + " , " + "y: " + value.Item2);
    }
}
*/

/*
using UsingOutAndVariations;
internal class Program
{
    (int, bool) GetValues(int a)
    {
        a = 10;
        bool b = true;
        return (a,b);
    }
    private static void Main(string[] args)
    {
        int x = 0;
        bool y= false;
        Program obj = new Program();

        Person person = new Person();
        Person p = person.GetPerson();
        Console.WriteLine($"Name: {p.Name} , Age: {p.Age}");

        var value = obj.GetValues(x);
        Console.WriteLine("x: " + value.Item1 + " , " + "y: " + y);
    }
}
*/