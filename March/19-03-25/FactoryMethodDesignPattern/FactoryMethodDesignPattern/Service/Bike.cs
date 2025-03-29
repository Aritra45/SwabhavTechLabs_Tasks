using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FactoryMethodDesignPattern.Repository;

namespace FactoryMethodDesignPattern.Service
{
    internal class Bike : I_Vehicle
    {
        private int _wheel = 2;
        public int NumberOfWheels()
        {
            return _wheel;
        }

        public string VehicalType()
        {
            return "Yamaha";
        }
    }
}
