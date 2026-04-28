namespace Factory
{
    class Program
    {
        static void Main()
        {
            var services = new ServiceCollecition();

            services.AddTransient<IPayment, CreditCardPayment>();
            services.AddTransient<IPayment, BitcoinPayment>();
            services.AddTransient<IPayment, UpiPayment>();

            services.AddSingleton<IPaymentFactory, PaymentFactoryDI>();

            var serviceProvider = services.BuildServiceProvider();

            var factory = serviceProvider.GetService<IPaymentFactory>();

            IPayment payment = factory.CreatePayment(PaymentType.CreditCard);
            payment.ProcessPayment(100.00m);
        }
    }
}