// not in use - using DI approach 
namespace Factory.Factories;

using Factory.Interfaces;

public abstract class PaymentFactory
{
    public abstract IPayment CreatePayment();
}