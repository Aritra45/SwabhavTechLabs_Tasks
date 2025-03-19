using AbstractClass.Model;

internal class Program
{
    private static void Main(string[] args)
    {
        Truck t = new Truck();
        Console.WriteLine(t.VehicalName("Mahindra"));
        t.VehicalTires();
    }
}