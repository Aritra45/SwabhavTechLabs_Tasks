using CompositeMethodDesignPatterns.Service;

internal class Program
{
    private static void Main(string[] args)
    {
        Folder root = new Folder(0.5m);
        root.AddChild(new Files(10));
        root.AddChild(new Files(2));
        root.AddChild(new Files(5));
        Folder subFolder1 = new Folder();
        Folder subFolder2 = new Folder();
        Folder subFolder3 = new Folder();
        subFolder3.AddChild(new Files(8));
        subFolder2.AddChild(subFolder3);
        subFolder2.AddChild(new Files(3));
        subFolder1.AddChild(subFolder2);
        root.AddChild(subFolder1);
        Console.WriteLine(root.GetSize());
    }
}