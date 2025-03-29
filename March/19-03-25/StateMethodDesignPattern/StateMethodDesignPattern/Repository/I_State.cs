using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using StateMethodDesignPattern.Management;

namespace StateMethodDesignPattern.Repository
{
    internal interface I_State
    {
        public void HandleState(TrafficLightContext context);

    }
}
