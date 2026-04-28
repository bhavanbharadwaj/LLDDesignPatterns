using Microsoft.Extensions.DependencyInjection;
using Factory.Interfaces;
using Factory.Factories;
using Factory.payments;
using Microsoft.Extensions.DependencyInjection.Extensions;

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
            services.AddSingleton<IPaymentFactory, PaymentFactoryDIWithDict>();
            services.AddSingleton<IPaymentFactory, PaymentFactoryDICleanerVersion>();

            var serviceProvider = services.BuildServiceProvider();

            //var factory = serviceProvider.GetRequiredService<IPaymentFactory>();
            //IPayment payment = factory.CreatePayment(PaymentType.CreditCard);

            // var payment = new PaymentFactoryDIWithDict(serviceProvider)
            //                  .CreatePayment(PaymentType.CreditCard);

            var payment = new PaymentFactoryDICleanerVersion(serviceProvider)
                             .CreatePayment(PaymentType.CreditCard);

            payment.ProcessPayment(100.00m);
        }
    }
}