using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace StudentApp.Model
{
    internal class Student
    {
        public string Name { get; set; }
        public int Roll {  get; set; }
        public double Cgpa { get; set; }
        public double Persentage { get; set; }

        public Student(string name, double cgpa, int roll) { 
            Name = name;
            Roll = roll;
            Cgpa = cgpa;
            Persentage = CalculateStudentPercentage();
        }

        public double CalculateStudentPercentage()
        {
            return Cgpa * 10;
        }
    }
}
