using BuilderMethodDesignPattern.Model;
using BuilderMethodDesignPattern.Repository;
using BuilderMethodDesignPattern.Service;

internal class Program
{
    private static void Main(string[] args)
    {
        I_BuildCellPhone phone = new Configaration();
        Manufacturer manufacturer = new Manufacturer(phone);
        manufacturer.DisplayCellPhone();
        CellPhone cellPhone = manufacturer.GetCellPhone();
        Console.WriteLine($"CellPhone Configarations are: \n{cellPhone}");
    }
}