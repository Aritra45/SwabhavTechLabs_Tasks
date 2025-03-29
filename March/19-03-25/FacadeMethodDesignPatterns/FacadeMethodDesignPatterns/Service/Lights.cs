using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FacadeMethodDesignPatterns.Service
{
    internal class Lights
    {
        public void TurnOn()
        {
            Console.WriteLine("Lights on");
        }

        public void TurnOff()
        {
            Console.WriteLine("Lights off");
        }
    }
}
