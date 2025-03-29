using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DecoratorMethodDesignPatterns.Repository;

namespace DecoratorMethodDesignPatterns.Service
{
    internal class PlanePizza : I_Pizza
    {
        public void Prepare()
        {
            Console.WriteLine("Pizza Prepared");
        }
    }
}
