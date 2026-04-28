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

            // Register concrete payment implementations
            services.AddTransient<CreditCardPayment>();
            services.AddTransient<BitcoinPayment>();
            services.AddTransient<UpiPayment>();

            // Register factory implementations
            services.AddSingleton<PaymentFactoryDI>();
            services.AddSingleton<PaymentFactoryDIWithDict>();
            services.AddSingleton<PaymentFactoryDICleanerVersion>();

            var serviceProvider = services.BuildServiceProvider();

            /*
             * ============================================================
             * 1. SWITCH-BASED FACTORY
             * ============================================================
             * Uses switch-case internally to resolve payment objects.
             * Cleaner than direct object creation but still requires
             * modifying switch statements when adding new payment types.
             */

            // var switchFactory =
            //     serviceProvider.GetRequiredService<PaymentFactoryDI>();

            // IPayment switchPayment =
            //     switchFactory.CreatePayment(PaymentType.CreditCard);

            // switchPayment.ProcessPayment(100.00m);



            /*
             * ============================================================
             * 2. DI + DICTIONARY FACTORY
             * ============================================================
             * Replaces switch-case with Dictionary<PaymentType, Func<IPayment>>
             * for cleaner and more maintainable resolver mapping.
             */

            // var dictFactory =
            //     serviceProvider.GetRequiredService<PaymentFactoryDIWithDict>();

            // IPayment dictPayment =
            //     dictFactory.CreatePayment(PaymentType.Bitcoin);

            // dictPayment.ProcessPayment(200.00m);



            /*
             * ============================================================
             * 3. CLEANER DICTIONARY-BASED FACTORY (CURRENT VERSION)
             * ============================================================
             * Uses:
             * - IReadOnlyDictionary
             * - Method group syntax
             * - DI container
             * - Resolver mapping approach
             */

            var cleanerFactory =
                serviceProvider.GetRequiredService<PaymentFactoryDICleanerVersion>();

            IPayment payment =
                cleanerFactory.CreatePayment(PaymentType.Upi);

            payment.ProcessPayment(300.00m);
        }
    }
}