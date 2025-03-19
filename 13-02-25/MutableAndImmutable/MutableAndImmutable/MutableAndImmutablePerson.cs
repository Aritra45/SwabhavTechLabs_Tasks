using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MutableAndImmutable
{
    internal class MutableAndImmutablePerson
    {
        public string Name { get; }
        public string Surname { get; }
        public int Age { get; set; }

        public MutableAndImmutablePerson(string name, string surname, int age)
        {
            Name = name;
            Surname = surname;
            Age = age;
        }
    }

}
