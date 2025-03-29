using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FactoryMethodDesignPattern.Repository;

namespace FactoryMethodDesignPattern.Service
{
    internal class Car : I_Vehicle
    {
        public int _wheel = 4;
        public int NumberOfWheels()
        {
            return _wheel;
        }

        public string VehicalType()
        {
            return "Renold";
        }
    }
}
