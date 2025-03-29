using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CommandMethodDesignPattern.Command
{
    internal class CommandInvoker
    {
        private List<I_Order> orders = new List<I_Order>();
        public void AddOrderCommand(I_Order order)
        {
            orders.Add(order);
        }
        public void ExecuteCommand()
        {
            foreach (I_Order order in orders)
            {
                order.Execute();
            }
        }
    }
}
