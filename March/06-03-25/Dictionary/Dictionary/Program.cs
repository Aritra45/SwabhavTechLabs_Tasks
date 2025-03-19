using Dictionary;

internal class Program
{
    private static void Main(string[] args)
    {
        Dictionarys dictionarys = new Dictionarys();
        int a = 1;
        string b = "Aritra";
        object o1 = a;
        object o2 = b;
        dictionarys.AddElement(o1, o2);

        a = 2;
        b = "Abhishek";
        object o3 = a;
        object o4 = b;
        dictionarys.AddElement(o3, o4);

        a = 3;
        b = "Kalyanii";
        object o5 = a;
        object o6 = b;
        dictionarys.AddElement(o5, o6);

        a = 4;
        b = "Partha";
        object o7 = a;
        object o8 = b;
        dictionarys.AddElement(o7, o8);

        dictionarys.RemoveElement(o7, o8);

        dictionarys.Display();
    }
}