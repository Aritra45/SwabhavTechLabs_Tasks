using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AbstractFactoryMethodDesignPattern.Repository;

namespace AbstractFactoryMethodDesignPattern.Services
{
    internal class SuzukiCar : I_Car
    {
        public void ManufactureCar()
        {
            Console.WriteLine("This is Suzuki Car");
        }
    }
}
