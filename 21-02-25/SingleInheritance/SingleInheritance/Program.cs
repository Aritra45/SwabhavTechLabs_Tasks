using System.Security.Cryptography.X509Certificates;

class Vehical
{
    protected int wheel = 6;
    public virtual void NoOfWheel()
    {
        Console.WriteLine("Wheels are not present");
    }
}

class Truck : Vehical
{
    
    public override void NoOfWheel()
    {
        
        Console.WriteLine($"No Of Wheel: {wheel}");
    }
}

internal class Program
{
    private static void Main(string[] args)
    {
        Vehical obj = new Truck();
        obj.NoOfWheel();
    }
}