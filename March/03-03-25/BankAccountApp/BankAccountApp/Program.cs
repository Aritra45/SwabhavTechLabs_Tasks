using BankAccountApp.Services;

internal class Program
{
    private static void Main(string[] args)
    {
        BankStore bankStore = new BankStore();
        bankStore.ShowMenu();
    }
}