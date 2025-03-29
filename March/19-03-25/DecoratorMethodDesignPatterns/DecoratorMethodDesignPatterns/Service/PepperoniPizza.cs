using DecoratorMethodDesignPatterns.Repository;

namespace DecoratorMethodDesignPatterns.Service
{
    internal class PepperoniPizza : PizzaDecorator
    {
        public PepperoniPizza(I_Pizza pizza) : base (pizza)
        {

        }
        public override void Prepare()
        {
            base.Prepare();
            Console.WriteLine("Adding Pepperoni Topping...");
        }
    }
}
