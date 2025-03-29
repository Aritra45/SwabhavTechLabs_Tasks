using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using StateMethodDesignPattern.Management;
using StateMethodDesignPattern.Repository;

namespace StateMethodDesignPattern.States
{
    internal class GreenState : I_State
    {
        public void HandleState(TrafficLightContext context)
        {
            Console.WriteLine("Traffic Light is GREEN. Go!");
            context.SetState(new YellowState());
        }

    }
}
