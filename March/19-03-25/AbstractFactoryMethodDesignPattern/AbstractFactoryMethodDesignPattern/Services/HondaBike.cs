using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AbstractFactoryMethodDesignPattern.Repository;

namespace AbstractFactoryMethodDesignPattern.Services
{
    internal class HondaBike : I_Bike
    {
        public void ManufactureBike()
        {
            Console.WriteLine("This is Honda Bike");
        }
    }
}
