using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AbstractClass.Model
{
    internal class Truck : Vehicle
    {
        string Name;
        public override string VehicalName(string name)
        {
            Name = name;
            return Name;
        }
        public override void VehicalTires()
        {
            Console.WriteLine("Truck has 6 tires");
        }
    }
}
