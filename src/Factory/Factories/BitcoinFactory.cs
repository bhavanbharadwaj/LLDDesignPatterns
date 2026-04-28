// not in use - using DI approach 

namespace Factory.Factories;

using Factory.Interfaces;
using Factory.payments;

public class BitcoinFactory : PaymentFactory
{
    public override IPayment CreatePayment()
    {
        return new BitcoinPayment();
    }
}