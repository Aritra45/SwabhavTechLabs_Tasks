using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UsingOutAndVariations
{
    internal class Person
    {
        public string Name { get; set; }
        public int Age { get; set; }


        public Person GetPerson()
        {
            return new Person { Name = "Aritra", Age= 23};
        }
    }
}
