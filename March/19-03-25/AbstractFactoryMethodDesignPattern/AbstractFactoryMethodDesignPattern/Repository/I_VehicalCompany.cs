using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AbstractFactoryMethodDesignPattern.Repository
{
    internal interface I_VehicalCompany
    {
        I_Car GetCar();
        I_Bike GetBike();
    }
}
