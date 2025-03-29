using StrategyMethodDesignPattern.Context;
using StrategyMethodDesignPattern.Services;

internal class Program
{
    private static void Main(string[] args)
    {
        PaymentContext paymentContext = new PaymentContext(new CreditCardPayment());
        paymentContext.ExecutePayment(500);

        paymentContext.SetPaymentStrategy(new PayPalPayment());
        paymentContext.ExecutePayment(1000);

        paymentContext.SetPaymentStrategy(new UPIPayment());
        paymentContext.ExecutePayment(200);

    }
}