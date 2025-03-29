using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FactoryMethodDesignPattern.Repository;
using FactoryMethodDesignPattern.Service;

namespace FactoryMethodDesignPattern.Management
{
    internal class VehicalFactory
    {
        public static I_Vehicle GetVehicle(string vehical)
        {
            I_Vehicle vehicalType = null;

            if(vehical.ToUpper() == "BIKE")
            {
                vehicalType = new Bike();
            }
            else if (vehical.ToUpper() == "CAR")
            {
                vehicalType = new Car();
            }
            return vehicalType;
        }
    }
}
