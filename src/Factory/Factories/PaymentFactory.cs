namespace Factory.Factories;

using Factory.Interfaces;

public abstract class PaymentFactory
{
    public abstract IPayment CreatePayment();
}