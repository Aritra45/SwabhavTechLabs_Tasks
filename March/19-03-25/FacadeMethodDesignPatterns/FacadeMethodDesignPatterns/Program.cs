using FacadeMethodDesignPatterns.Service;

internal class Program
{
    private static void Main(string[] args)
    {
        Car car = new Car();
        car.StartCar();

        car.StopCar();
    }
}