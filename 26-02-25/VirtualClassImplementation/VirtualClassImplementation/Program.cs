using VirtualClassImplementation.Model;

internal class Program
{
    private static void Main(string[] args)
    {
        Truck t = new Truck();
        Vehical vt = new Truck();
        Vehical v = new Vehical();

        Console.WriteLine(vt.VehicalName("Mahindra"));
        vt.VehicalTires();

        Console.WriteLine(t.VehicalName("AirIndia"));
        t.VehicalTires();
        v.VehicalTires();
    }
}