using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FactoryMethodDesignPattern.Repository
{
    internal interface I_Vehicle
    {
        public string VehicalType();
        public int NumberOfWheels();
    }
}
