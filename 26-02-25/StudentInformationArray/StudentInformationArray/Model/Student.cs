using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StudentInformationArray.Model
{
    internal class Student
    {
        public string Name { get; set; }
        public int Age { get; set; }
        public int Roll { get; set; }
        public Student(string name, int age, int roll)
        {
            Name = name;
            Age = age;
            Roll = roll;
        }
    }
}
