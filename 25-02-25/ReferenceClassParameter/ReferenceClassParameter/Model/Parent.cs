using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ReferenceClassParameter.Model
{
    internal class Parent
    {
        public string Greeting { get; set; }
        public virtual void Show(string greeting)
        {
            Greeting = greeting;
            Console.WriteLine($"{Greeting} This is Parent");
        }
    }
}
