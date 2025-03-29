using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DecoratorMethodDesignPatterns.Repository;

namespace DecoratorMethodDesignPatterns.Service
{
    internal class OnionPizza : PizzaDecorator
    {
        public OnionPizza(I_Pizza pizza) : base(pizza)
        {

        }
        public override void Prepare()
        {
            base.Prepare();
            Console.WriteLine("Adding Onion Topping...");
        }
    }
}
