/*
internal class Program
{
    private static void Main(string[] args)
    {
        Console.WriteLine("Enter Your Name:");
        string name = Console.ReadLine();
        int digit = name.Length;
        Console.WriteLine("Charectors of Your Name are:");
        for (int i = 0; i < digit; i++) {
            Console.WriteLine(name[i]);
        }
    }
}
*/
internal class Program
{
    private static void Main(string[] args)
    {
        Console.WriteLine("Enter Your Name:");
        string name = Console.ReadLine();
        int digit = name.Length;
        int i = 0;
        Console.WriteLine("Charectors of Your Name are:");
        while (i < digit) {
            Console.WriteLine(name[i]);
            i++;
        }
    }
}