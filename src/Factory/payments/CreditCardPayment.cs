namespace Factory.payments;

using Factory.Interfaces;

public class CreditCardPayment : IPayment
{
    public void ProcessPayment(decimal amount)
    {
        Console.WriteLine($"Processing Credit Card payment of {amount:C}");
    }
}