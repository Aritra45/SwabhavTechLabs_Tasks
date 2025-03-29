using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DecoratorMethodDesignPatterns.Repository;

namespace DecoratorMethodDesignPatterns.Service
{
    internal abstract class PizzaDecorator : I_Pizza
    {
        private I_Pizza Pizza { get; set; }
        protected PizzaDecorator(I_Pizza pizza)
        {
            Pizza = pizza;
        }
        public virtual void Prepare()
        {
            Pizza.Prepare();
        }
    }
}
