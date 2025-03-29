using TemplateMethodDesignPattern;

internal class Program
{
    private static void Main(string[] args)
    {
        Recipe pasta = new PastaRecipe();
        Recipe salad = new SaladRecipe();

        Console.WriteLine("Preparing Pasta:");
        pasta.PrepareDish();

        Console.WriteLine("\nPreparing Salad:");
        salad.PrepareDish();
    }
}