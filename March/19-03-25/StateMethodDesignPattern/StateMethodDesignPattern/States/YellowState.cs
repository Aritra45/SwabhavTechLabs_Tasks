using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using StateMethodDesignPattern.Management;
using StateMethodDesignPattern.Repository;

namespace StateMethodDesignPattern.States
{
    internal class YellowState : I_State
    {
        public void HandleState(TrafficLightContext context)
        {
            Console.WriteLine("Traffic Light is YELLOW. Slow down!");
            context.SetState(new RedState());
        }

    }
}
