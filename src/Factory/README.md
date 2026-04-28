🏭 Factory Design Pattern (C#)

📌 Overview

The Factory Design Pattern is a Creational Design Pattern used to create objects without exposing object creation logic to the client.

Instead of directly creating objects using new, object creation responsibility is delegated to a factory.

This project demonstrates the evolution of Factory Pattern implementations from:

1. Simple Factory using switch
2. Factory Method using inheritance
3. Factory + Dependency Injection
4. Dictionary-based resolver factory
⸻
🚨 Problem

Without Factory Pattern:

if(type  "upi")
{
    payment = new UpiPayment();
}
else if(type  "credit")
{
    payment = new CreditCardPayment();
}


❌ Issues

* Tight coupling
* Hard to maintain
* Difficult to scale
* Object creation logic scattered across the codebase
* Violates Open/Closed Principle
⸻
✅ Solution

Use a Factory to centralize object creation.

IPayment payment = factory.CreatePayment(PaymentType.Upi);

⸻
🧠 Key Idea

Factory Pattern helps in:

* Encapsulating object creation
* Reducing direct dependency on concrete classes
* Improving maintainability
* Supporting scalability

The client depends on abstractions (IPayment) instead of concrete implementations.
⸻
🏗️ Project Structure

Factory/
├── Factories/
│   ├── BitcoinFactory.cs
│   ├── CreditCardFactory.cs
│   ├── IPaymentFactory.cs
│   ├── PaymentFactory.cs
│   ├── PaymentFactoryDI.cs
│   ├── PaymentFactoryDIWithDict.cs
│   ├── PaymentFactoryDICleanerVersion.cs
│   └── UPIFactory.cs
│
├── Interfaces/
│   └── IPayment.cs
│
├── payments/
│   ├── BitcoinPayment.cs
│   ├── CreditCardPayment.cs
│   └── UpiPayment.cs
│
├── PaymentType.cs
├── Program.cs
├── Factory.csproj
└── README.md

⸻
⚙️ Implementation Breakdown

1️⃣ Product Interface

public interface IPayment
{
    void ProcessPayment(decimal amount);
}

⸻
2️⃣ Concrete Implementations

* CreditCardPayment
* UpiPayment
* BitcoinPayment

Each implementation contains its own payment processing behavior.
⸻
🏭 Factory Method Pattern

Abstract Factory

public abstract class PaymentFactory
{
    public abstract IPayment CreatePayment();
}

⸻
Concrete Factories

* CreditCardFactory
* UpiFactory
* BitcoinFactory

Each factory is responsible for creating its corresponding payment object.
⸻
🚀 Factory + Dependency Injection

This project also demonstrates a more practical real-world approach using:

* Dependency Injection
* IServiceProvider
* Runtime object resolution
⸻
🔁 Switch-Based DI Factory

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
            PaymentType.Upi =>
                _serviceProvider.GetRequiredService<UpiPayment>(),

            PaymentType.CreditCard =>
                _serviceProvider.GetRequiredService<CreditCardPayment>(),

            PaymentType.Bitcoin =>
                _serviceProvider.GetRequiredService<BitcoinPayment>(),

            _ => throw new ArgumentException("Invalid payment type")
        };
    }
}

⸻
📚 Dictionary-Based Factory

Instead of procedural switch-case branching, this implementation uses:

Dictionary<PaymentType, Func<IPayment>>


to map payment types to resolver functions.
⸻
✅ Why Dictionary-Based Factory?

The dictionary approach converts:

conditional logic


into:

resolver mapping


This makes the factory:

* Cleaner
* More maintainable
* Easier to extend
* More declarative
⸻
Example

private readonly IReadOnlyDictionary<PaymentType, Func<IPayment>> _paymentMappings;


return _paymentMappings.TryGetValue(type, out var resolver)
    ? resolver()
    : throw new NotSupportedException($"Payment type '{type}' is not supported.");

⸻
🔥 Why Use Dependency Injection Here?

Using DI provides:

* Centralized dependency management
* Better testability
* Better scalability
* Runtime object resolution
* Cleaner architecture
⸻
🧠 Important Insight

The dictionary-based implementation improves extensibility compared to switch-case implementations.

However, adding new payment types still requires:

* Adding new implementation
* Registering dependency
* Updating resolver mapping

So the implementation is not fully closed for modification.
⸻
⚔️ Factory vs Dependency Injection
Feature	Factory	Dependency Injection
Responsibility	Creates objects	Provides objects
Control	Inside factory	External container
Usage	Object creation logic	Runtime wiring

👉 In real-world systems, Factory Pattern is commonly combined with Dependency Injection.
⸻
✅ Benefits

* Loose coupling
* Centralized object creation
* Better maintainability
* Improved extensibility
* Easier testing
* Cleaner architecture
⸻
⚠️ Trade-offs

* Additional abstraction layer
* More setup compared to direct object creation
* Dictionary registration still requires modification for new types
⸻
🚀 When to Use

Use Factory Pattern when:

* Object creation is complex
* Multiple implementations exist
* Type is decided at runtime
* You want scalable architecture
* You want to decouple creation logic from business logic
⸻
🧪 Example Flow

Client
   ↓
Factory
   ↓
Resolver Mapping / DI Container
   ↓
Concrete Payment Object
   ↓
ProcessPayment()

⸻
🧑‍💻 Run Project

dotnet run

⸻
📦 Dependencies

dotnet add package Microsoft.Extensions.DependencyInjection

⸻
🔮 Future Improvements

* Remove manual resolver registration
* Reflection-based auto registration
* Keyed services (.NET 8)
* Add Strategy Pattern
* Add Unit Tests
* Integrate Logging
⸻
📌 Conclusion

Factory Pattern helps separate object creation from business logic and improves maintainability and scalability.

This project demonstrates the evolution from simple factories to cleaner Dependency Injection and dictionary-based resolver approaches used in modern backend systems.