using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AbstractClass.Model
{
    internal abstract class Vehicle
    {
        public string name;
        public abstract string VehicalName(string name);
        public abstract void VehicalTires();
    }
}
