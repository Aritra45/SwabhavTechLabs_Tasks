using AbstractFactoryMethodDesignPattern.Management;
using AbstractFactoryMethodDesignPattern.Repository;

internal class Program
{
    private static void Main(string[] args)
    {
        Console.Write("Enter Company: ");
        string vehicalType = Console.ReadLine();

        I_VehicalCompany type = VehicalManagement.GetVehical(vehicalType);
    }
}