using LinkedList;

internal class Program
{
    private static void Main(string[] args)
    {
        LinkedLists linkedList = new LinkedLists();
        int a = 10;
        object o = a;
        linkedList.AddFirst(o);
        a = 2;
        o = a;
        linkedList.AddFirst(o);
        a = 3;
        o = a;
        linkedList.AddFirst(o);
        a = 4;
        o = a;
        linkedList.AddAddBetween(o);
        a = 5;
        o = a;
        linkedList.AddEnd1(o);

        linkedList.Display();
    }
}