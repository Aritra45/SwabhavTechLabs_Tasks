using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using StrategyMethodDesignPattern.Repository;

namespace StrategyMethodDesignPattern.Services
{
    internal class UPIPayment : I_PaymentStrategy
    {
        public void Pay(double amount)
        {
            Console.WriteLine($"Paid {amount} using UPI.");
        }

    }
}
