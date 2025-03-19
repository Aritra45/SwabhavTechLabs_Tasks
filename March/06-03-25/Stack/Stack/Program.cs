using Stack;

internal class Program
{
    private static void Main(string[] args)
    {
        Stacks stacks = new Stacks();
        int a = 10;
        object o = a;
        stacks.AddElement(o);

        a = 20;
        o = a;
        stacks.AddElement(o);

        a = 30;
        o = a;
        stacks.AddElement(o);

        stacks.RemoveElement();

        stacks.Display();
    }
}