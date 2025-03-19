class Test
{
    private static Test obj;

    private Test() { 
        
    }
    public static Test GetTest()
    {
        if (obj == null)
            obj = new Test();
        return obj;
        
    }
}

internal class Program
{
    private static void Main(string[] args)
    {
        Test obj1 = Test.GetTest(); 
        Test obj2 = Test.GetTest();

        Console.WriteLine(obj1==obj2); 
    }
}