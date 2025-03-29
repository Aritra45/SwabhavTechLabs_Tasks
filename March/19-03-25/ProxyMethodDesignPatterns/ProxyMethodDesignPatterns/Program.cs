using ProxyMethodDesignPatterns.Repository;
using ProxyMethodDesignPatterns.Service;

internal class Program
{
    private static void Main(string[] args)
    {
        I_Database proxy = new ProxyDatabase();
        Console.WriteLine(proxy.GetDataByID(3));
    }
}