namespace Factory.Factories;

using Factory.Interfaces;
using Factory.payments;

public interface IPaymentFactory
{
    IPayment CreatePayment(PaymentType type);
}