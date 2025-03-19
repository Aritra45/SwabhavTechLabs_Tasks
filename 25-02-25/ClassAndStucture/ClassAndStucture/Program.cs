class Details
{
    public string Name;
    public int Age;

    public Details(string name,  int age)
    {
        Name = name;
        Age = age;
    }
}

struct StructDetails
{
    public string Name;
    public int Age;

    public StructDetails(string name, int age)
    {
        Name = name;
        Age = age;
    }
}
internal class Program
{
    private static void Main(string[] args)
    {
        Details d1 = new Details("Aritra", 23);
        Details d2 = d1;
        d2.Age = 24;
        Console.WriteLine($"{d1.Name} {d1.Age}");

        StructDetails d3 = new StructDetails("Aritra", 23);
        StructDetails d4 = d3;
        d4.Age = 24;
        Console.WriteLine($"{d4.Name} {d4.Age}");
    }
}