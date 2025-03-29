using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using StrategyMethodDesignPattern.Repository;

namespace StrategyMethodDesignPattern.Context
{
    internal class PaymentContext
    {
        private I_PaymentStrategy _paymentStrategy;

        public PaymentContext(I_PaymentStrategy paymentStrategy)
        {
            _paymentStrategy = paymentStrategy;
        }

        public void SetPaymentStrategy(I_PaymentStrategy paymentStrategy)
        {
            _paymentStrategy = paymentStrategy;
        }

        public void ExecutePayment(double amount)
        {
            _paymentStrategy.Pay(amount);
        }

    }
}
