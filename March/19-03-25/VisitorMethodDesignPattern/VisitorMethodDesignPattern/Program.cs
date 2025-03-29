using VisitorMethodDesignPattern;

internal class Program
{
    private static void Main(string[] args)
    {
        I_Element book = new Book("Mahabharat");
        I_Element dvd = new DVD("KGF");

        I_Visitor priceCalculator = new PriceCalculator();

        book.Accept(priceCalculator);
        dvd.Accept(priceCalculator);
    }
}