namespace Factory.payments;

using Factory.Interfaces;

public class BitcoinPayment : IPayment
{
    public void ProcessPayment(decimal amount)
    {
        Console.WriteLine($"Processing Bitcoin payment of {amount}");
    }
}