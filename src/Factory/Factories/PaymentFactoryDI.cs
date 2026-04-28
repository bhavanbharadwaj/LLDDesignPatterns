namespace Factory.Factories;

using Factory.Interfaces;
using Factory.payments;
using Microsoft.Extensions.DependencyInjection;

public class PaymentFactoryDI : IPaymentFactory
{
    private readonly IServiceProvider _serviceProvider;

    public PaymentFactoryDI(IServiceProvider serviceProvider)
    {
        _serviceProvider = serviceProvider;
    }

    public IPayment CreatePayment(PaymentType type)
    {
        return type switch
        {
            PaymentType.CreditCard => _serviceProvider.GetRequiredService<CreditCardPayment>(),
            PaymentType.Upi => _serviceProvider.GetRequiredService<UpiPayment>(),
            PaymentType.Bitcoin => _serviceProvider.GetRequiredService<BitcoinPayment>(),
            _ => throw new ArgumentException("Invalid payment type")
        };
    }
}