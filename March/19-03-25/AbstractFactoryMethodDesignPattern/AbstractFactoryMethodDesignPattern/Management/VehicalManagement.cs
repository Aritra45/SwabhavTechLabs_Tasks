using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AbstractFactoryMethodDesignPattern.Repository;

namespace AbstractFactoryMethodDesignPattern.Management
{
    internal class VehicalManagement
    {
        public static I_VehicalCompany GetVehical(string company)
        {
            I_VehicalCompany vehical = null;
            if (company.ToUpper() == "HONDA")
            {
                I_VehicalCompany honda = new Honda();
                I_Car hondaCar = honda.GetCar();
                I_Bike hondaBike = honda.GetBike();

                hondaCar.ManufactureCar();
                hondaBike.ManufactureBike();
            }
            else if(company.ToUpper() == "SUZUKI")
            {
                I_VehicalCompany suzuki = new Suzuki();
                I_Car suzukiCar = suzuki.GetCar();
                I_Bike suzukiBike = suzuki.GetBike();



                suzukiCar.ManufactureCar();
                suzukiBike.ManufactureBike();
            }
            return vehical;
        }
    }
}
