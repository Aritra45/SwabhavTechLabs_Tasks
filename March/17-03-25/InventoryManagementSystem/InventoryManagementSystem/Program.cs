using InventoryManagementSystem;
using InventoryManagementSystem.Management;
using InventoryManagementSystem.Services;

internal class Program
{
    private static void Main(string[] args)
    {
        Menu menu = new Store();
        menu.ChooseMenu();
    }
}