using DecoratorMethodDesignPatterns.Repository;
using DecoratorMethodDesignPatterns.Service;

internal class Program
{
    private static void Main(string[] args)
    {
        I_Pizza pizza = new CapsicumPizza(new OnionPizza(new PepperoniPizza(new PlanePizza())));
        pizza.Prepare();
    }
}