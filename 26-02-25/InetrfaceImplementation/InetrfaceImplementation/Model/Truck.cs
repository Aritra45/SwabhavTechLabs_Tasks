using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InetrfaceImplementation.Model
{
    internal class Truck : Vehical
    {
        public string Name;
        public string VehicalName(string name)
        {
            Name= name;
            return Name;
        }
        public void VehicalTires()
        {
            Console.WriteLine("Truck has 6 Tires");
        }

    }
}
