using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StrategyMethodDesignPattern.Repository
{
    internal interface I_PaymentStrategy
    {
        void Pay(double amount);

    }
}
