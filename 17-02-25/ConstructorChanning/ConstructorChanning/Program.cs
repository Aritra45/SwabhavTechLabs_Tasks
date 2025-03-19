class Channing
{
    public string Name;
    public int Age;
    public Channing() : this("Aritra", 23)
    {

    }
    public Channing(string name) : this(name, 24)
    {

    }
    public Channing(string name, int age)
    {
        Name = name;
        Age = age;
    }
}

internal class Program
{
    private static void Main(string[] args)
    {
        Channing c1 = new Channing();
        Channing c2 = new Channing("Rup");
        Channing c3 = new Channing("Ari", 25);

        Console.WriteLine($"{c1.Name} {c1.Age}");
        Console.WriteLine($"{c2.Name} {c2.Age}");
        Console.WriteLine($"{c3.Name} {c3.Age}");
    }
}