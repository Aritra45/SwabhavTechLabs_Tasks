using GetHashCodeOverriding;

internal class Program
{
    private static void Main(string[] args)
    {
        Person p1 = new Person("Aritra", 23);
        Person p2 = new Person("Rup", 24);

        Console.WriteLine(p1.GetHashCode());
    }
}