using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FacadeMethodDesignPatterns.Service
{
    internal class Car
    {
        private Engine engine = new Engine();
        private Lights lights = new Lights();

        public void StartCar()
        {
            engine.Start();
            lights.TurnOn();
            Console.WriteLine("Car is ready to drive");
        }

        public void StopCar()
        {
            lights.TurnOff();
            engine.Stop();
            Console.WriteLine("Car has stopped");
        }
    }
}
