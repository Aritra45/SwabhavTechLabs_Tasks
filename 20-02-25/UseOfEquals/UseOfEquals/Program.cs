using UseOfEquals;

internal class Program
{
    private static void Main(string[] args)
    {
        Person p1 = new Person("Aritra", 23);
        Person p2 = new Person("Aritra", 23);

        Console.WriteLine(p1.Equals(p2));
    }
}