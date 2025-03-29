using StateMethodDesignPattern.Management;
using StateMethodDesignPattern.States;

internal class Program
{
    private static void Main(string[] args)
    {
        TrafficLightContext context = new TrafficLightContext(new RedState());

        context.Request(); 
        context.Request(); 
        context.Request();
        context.Request();
        context.Request();
    }
}