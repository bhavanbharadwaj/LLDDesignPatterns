using Microsoft.Extensions.DependencyInjection;
using Factory.Interfaces;
using Factory.Factories;
using Factory.payments;

namespace Factory
{
    class Program
    {
        static void Main()
        {
            var services = new ServiceCollection();

            services.AddTransient<CreditCardPayment>();
            services.AddTransient<BitcoinPayment>();
            services.AddTransient<UpiPayment>();

            services.AddSingleton<IPaymentFactory, PaymentFactoryDI>();

            var serviceProvider = services.BuildServiceProvider();

            var factory = serviceProvider.GetRequiredService<IPaymentFactory>();

            IPayment payment = factory.CreatePayment(PaymentType.CreditCard);
            payment.ProcessPayment(100.00m);
        }
    }
}