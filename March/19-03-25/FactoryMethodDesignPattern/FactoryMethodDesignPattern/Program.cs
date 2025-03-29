using FactoryMethodDesignPattern.Management;
using FactoryMethodDesignPattern.Repository;
using FactoryMethodDesignPattern.Service;

internal class Program
{
    private static void Main(string[] args)
    {
        Console.Write("Enter Vehical Type: ");
        string vehicalType = Console.ReadLine();

        I_Vehicle type = VehicalFactory.GetVehicle(vehicalType);

        Console.Write($"\nVehical Type is: {type.VehicalType()}");
        Console.Write($"\nNumber of Wheels Are: {type.NumberOfWheels()}");
    }
}

