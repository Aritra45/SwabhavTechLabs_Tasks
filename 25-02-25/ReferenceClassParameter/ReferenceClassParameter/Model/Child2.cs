using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ReferenceClassParameter.Model
{
    internal class Child2:Parent
    {
        public override void Show(string greeting)
        {
            Greeting = greeting;
            Console.WriteLine($"{Greeting} This is Child2");
        }
    }
}
