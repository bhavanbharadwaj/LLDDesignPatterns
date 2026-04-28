// not in use - using DI approach 
namespace Factory.Factories;

using Factory.Interfaces;
using Factory.payments;

public class CreditCardFactory : PaymentFactory
{
    public override IPayment CreatePayment()
    {
        return new CreditCardPayment();
    }
}