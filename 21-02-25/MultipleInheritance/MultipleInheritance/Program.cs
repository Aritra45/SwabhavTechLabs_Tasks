interface Papa
{
    public void Y();
}

interface Mamma
{
    public void X();
}

class Me : Papa, Mamma
{
    public void Y()
    {
        Console.WriteLine("This is my Papa");
    }

    public void X()
    {
        Console.WriteLine("This is my Mamma");
    }
}

internal class Program
{
    private static void Main(string[] args)
    {
        Me me = new Me();
        me.Y();
        me.X();
    }
}