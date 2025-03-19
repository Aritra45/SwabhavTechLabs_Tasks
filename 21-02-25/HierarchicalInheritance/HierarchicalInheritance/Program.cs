class Vehical
{
    public virtual void NoOfWheels()
    {
        Console.WriteLine("Wheels are not present");
    }
}

class Truck : Vehical
{
    private int wheels = 6;
    public override void NoOfWheels()
    {
        Console.WriteLine($"No of Wheels in Truck: {wheels}");
    }
}

class Car : Vehical
{
    private int wheels = 4;
    public override void NoOfWheels()
    {
        Console.WriteLine($"No of Wheels in Car: {wheels}");
    }
}

internal class Program
{
    private static void Main(string[] args)
    {
        Vehical v = new Vehical();
        v.NoOfWheels();
        Vehical t = new Truck();
        Vehical c = new Car();
        t.NoOfWheels();
        c.NoOfWheels();
    }
}