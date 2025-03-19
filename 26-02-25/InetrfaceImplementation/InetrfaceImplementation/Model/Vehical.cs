using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices.Marshalling;
using System.Text;
using System.Threading.Tasks;

namespace InetrfaceImplementation.Model
{
    internal interface Vehical
    {
        public abstract string VehicalName(string name);

        public virtual void VehicalTires()
        {
            Console.WriteLine("Showcase of Vehical Tires");
        }
    }
}
