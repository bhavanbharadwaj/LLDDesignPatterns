using Factory.Interfaces;
using Factory.payments;
using Microsoft.Extensions.DependencyInjection;

namespace Factory.Factories
{
    public class PaymentFactoryDICleanerVersion : IPaymentFactory
    {
        private IReadOnlyDictionary<PaymentType, Func<IPayment>> _paymentMappings;


        public PaymentFactoryDICleanerVersion(IServiceProvider serviceProvider)
        {
            _paymentMappings = new Dictionary<PaymentType, Func<IPayment>>()
            {
                [PaymentType.CreditCard] = serviceProvider.GetRequiredService<CreditCardPayment>,
                [PaymentType.Bitcoin] = serviceProvider.GetRequiredService<BitcoinPayment>,
                [PaymentType.Upi] = serviceProvider.GetRequiredService<UpiPayment>
            };
        }

        public IPayment CreatePayment(PaymentType type)
        {
            return _paymentMappings.TryGetValue(type, out var paymentFunc) 
                ? paymentFunc() 
                : throw new ArgumentException($"Payment type {type} is not supported.");
        }
    }
}