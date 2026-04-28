namespace Factory.Factories;

using Factory.Interfaces;
using Factory.payments;

public class UpiFactory : PaymentFactory
{
    public override IPayment CreatePayment()
    {
        return new UpiPayment();
    }
}