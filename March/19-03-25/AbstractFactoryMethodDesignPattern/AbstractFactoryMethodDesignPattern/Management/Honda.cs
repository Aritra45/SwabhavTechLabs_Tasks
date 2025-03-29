using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AbstractFactoryMethodDesignPattern.Repository;
using AbstractFactoryMethodDesignPattern.Services;

namespace AbstractFactoryMethodDesignPattern.Management
{
    internal class Honda : I_VehicalCompany
    {
        public I_Bike GetBike()
        {
            return new HondaBike();
        }

        public I_Car GetCar()
        {
            return new HondaCar();
        }
    }
}
