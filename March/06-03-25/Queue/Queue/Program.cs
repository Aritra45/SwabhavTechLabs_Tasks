using Queue;

internal class Program
{
    private static void Main(string[] args)
    {
        Queues queues = new Queues();
        int a = 10;
        object o = a;
        queues.AddElement(o);

        a = 20;
        o = a;
        queues.AddElement(o);

        a = 30;
        o = a;
        queues.AddElement(o);

        a = 40;
        o = a;
        queues.AddElement(o);

        a = 50;
        o = a;
        queues.AddElement(o);

        queues.RemoveElement();

        queues.Display();
    }
}