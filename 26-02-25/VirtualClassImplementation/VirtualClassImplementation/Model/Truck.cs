using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace VirtualClassImplementation.Model
{
    internal class Truck:Vehical
    {
        public string VehicalName(string name)
        {
            return base.VehicalName(name);
        }

        public override void VehicalTires()
        {
            Console.WriteLine("Truck has 6 Tires");
        }
    }
}
