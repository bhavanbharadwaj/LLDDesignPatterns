using Factory.Interfaces;
using Factory.payments;
using Microsoft.Extensions.DependencyInjection;

namespace Factory.Factories
{
    public class PaymentFactoryDIWithDict : IPaymentFactory
    {
        private readonly Dictionary<PaymentType, Func<IPayment>> _payments;

        public PaymentFactoryDIWithDict(IServiceProvider serviceProvider)
        {
            _payments = new Dictionary<PaymentType, Func<IPayment>>()
            {
                {PaymentType.Bitcoin, () => serviceProvider.GetRequiredService<BitcoinPayment>()},
                {PaymentType.CreditCard, () => serviceProvider.GetRequiredService<CreditCardPayment>()},
                {PaymentType.Upi, () => serviceProvider.GetRequiredService<UpiPayment>()}
            };
        }
        public IPayment CreatePayment(PaymentType type)
        {
            if (_payments.TryGetValue(type, out var paymentFunc))
            {
                return paymentFunc();
            }
            else
            {
                throw new ArgumentException($"Payment type {type} is not supported.");
            }
        }
    }
}