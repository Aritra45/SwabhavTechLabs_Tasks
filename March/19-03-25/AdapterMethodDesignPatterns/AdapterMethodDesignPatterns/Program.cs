using AdapterMethodDesignPatterns.Management;
using AdapterMethodDesignPatterns.Repository;
using AdapterMethodDesignPatterns.Service;

internal class Program
{
    private static void Main(string[] args)
    {
        NewServices newServices = new NewServices();
        I_Vehical properties = new Adapter(newServices);

        properties.Specifications();
    }
}