class Narayan
{
    public string grandFather = "Narayan";
    public void Relation()
    {
        Console.WriteLine($"I am {grandFather} and I am Aritra's GrandFather and I am Partha's Father");
    }
}

class Partha : Narayan
{
    public string father = "Partha";
    public void Relation()
    {
        base.Relation();
        Console.WriteLine($"I am {father} and I am Aritra's Father");
    }
}

class Aritra : Partha
{
    private string son = "Aritra";
    public void Relation()
    {
        base.Relation();
        Console.WriteLine($"I am {son} and I am {father}'s Son and Narayan's GrandSon");
    }
}

internal class Program
{
    private static void Main(string[] args)
    {
        Aritra aritra = new Aritra();
        aritra.Relation();
    }
}