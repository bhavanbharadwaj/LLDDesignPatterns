namespace Factory.payments;

using Factory.Interfaces;

public class UpiPayment : IPayment
{
    public void ProcessPayment(decimal amount)
    {
        Console.WriteLine($"Processing UPI payment of {amount:C}");
    }
}