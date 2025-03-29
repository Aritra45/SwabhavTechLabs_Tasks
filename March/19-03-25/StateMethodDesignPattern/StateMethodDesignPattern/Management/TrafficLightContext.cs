using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using StateMethodDesignPattern.Repository;

namespace StateMethodDesignPattern.Management
{
    internal class TrafficLightContext
    {
        private I_State CurrentState;

        public TrafficLightContext(I_State initialState)
        {
            CurrentState = initialState;
        }

        public void SetState(I_State state)
        {
            CurrentState = state;
        }

        public void Request()
        {
            CurrentState.HandleState(this);
        }

    }
}
