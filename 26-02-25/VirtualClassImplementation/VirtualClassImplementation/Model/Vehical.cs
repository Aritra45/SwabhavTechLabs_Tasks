using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VirtualClassImplementation.Model
{
    internal class Vehical
    {
        public string Name;

        public string VehicalName(string name)
        {
            Name = name;
            return Name;
        }
        public virtual void VehicalTires() {
            Console.WriteLine("Showcase of Vehical Tires");
        }
    }
}
