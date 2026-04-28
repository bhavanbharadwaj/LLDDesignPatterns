# 🏭 Factory Design Pattern (C#)

## 📌 Overview

The **Factory Design Pattern** is a **creational design pattern** used to create objects **without exposing the instantiation logic to the client**.

Instead of directly using `new`, object creation is delegated to a factory.

> “Define an interface for creating an object, but let subclasses decide which class to instantiate.” ([GeeksforGeeks][1])

---

## 🚨 Problem

Without Factory Pattern:

```csharp
if(type == "upi")
    payment = new UpiPayment();
else if(type == "credit")
    payment = new CreditCardPayment();
```

### Issues:

* Tight coupling ❌
* Violates Open/Closed Principle ❌
* Hard to scale ❌
* Object creation logic scattered ❌

---

## ✅ Solution

Use a **Factory** to centralize object creation.

```csharp
IPayment payment = factory.CreatePayment(PaymentType.Upi);
```

---

## 🧠 Key Idea

👉 Encapsulate object creation
👉 Depend on abstractions, not concrete classes

Factory pattern helps in **decoupling client code from implementation details** ([TutorialsPoint][2])

---

## 🏗️ Project Structure

```
/FactoryPattern
 ├── Interfaces/
 │    └── IPayment.cs
 │
 ├── Models/
 │    ├── CreditCardPayment.cs
 │    ├── UpiPayment.cs
 │    ├── BitcoinPayment.cs
 │    └── PaymentType.cs
 │
 ├── Factories/
 │    ├── PaymentFactory.cs              (Factory Method - Abstract)
 │    ├── CreditCardFactory.cs
 │    ├── UpiFactory.cs
 │    ├── BitcoinFactory.cs
 │    ├── IPaymentFactory.cs            (DI-based abstraction)
 │    └── PaymentFactoryDI.cs           (DI-based factory)
 │
 ├── Program.cs
 └── README.md
```

---

## ⚙️ Implementation Breakdown

### 1. Product Interface

```csharp
public interface IPayment
{
    void ProcessPayment();
}
```

---

### 2. Concrete Implementations

* CreditCardPayment
* UpiPayment
* BitcoinPayment

---

### 3. Factory Method Pattern

* `PaymentFactory` → Abstract class
* `UpiFactory`, `CreditCardFactory` → Concrete factories

👉 Subclasses decide object creation

---

### 4. DI-Based Factory (Real-world)

```csharp
public interface IPaymentFactory
{
    IPayment CreatePayment(PaymentType type);
}
```

```csharp
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
            PaymentType.Upi => _serviceProvider.GetRequiredService<UpiPayment>(),
            PaymentType.CreditCard => _serviceProvider.GetRequiredService<CreditCardPayment>(),
            PaymentType.Bitcoin => _serviceProvider.GetRequiredService<BitcoinPayment>(),
            _ => throw new ArgumentException("Invalid type")
        };
    }
}
```

---

## 🔥 Why Factory Pattern?

### ✅ Loose Coupling

Client depends on `IPayment`, not concrete classes
→ Changes don’t ripple across code

---

### ✅ Open/Closed Principle

Add new payment:

* Create new class
* Register in DI
  👉 No change in existing logic

---

### ✅ Centralized Object Creation

All object creation logic in one place

---

### ✅ Better Testability

Factory can be mocked easily

---

## ⚠️ Trade-offs

* Adds extra abstraction layer
* Slightly more complex
* Overkill for small applications

---

## ⚔️ Factory vs Dependency Injection

| Feature        | Factory               | Dependency Injection |
| -------------- | --------------------- | -------------------- |
| Responsibility | Creates objects       | Provides objects     |
| Control        | Inside factory        | External container   |
| Usage          | Object creation logic | Runtime wiring       |

👉 In real-world systems → **Factory + DI together**

---

## 🚀 When to Use

Use Factory Pattern when:

* Object creation is complex
* Multiple implementations exist
* Type is decided at runtime
* You want scalable architecture

---

## 💡 Key Insight

Loose coupling does NOT mean:

> “No code changes ever”

It means:

> “Changes are localized and safe”

---

## 🧪 Example Flow

1. Client requests payment
2. Factory decides implementation
3. Object returned via interface
4. Client executes behavior

---

## 🧑‍💻 Run Project

```bash
dotnet run
```

---

## 📦 Dependencies

```bash
dotnet add package Microsoft.Extensions.DependencyInjection
```

---

## 🔮 Future Improvements

* Add Strategy Pattern
* Replace switch with Dictionary
* Add Unit Tests
* Integrate Logging

---

## 📌 Conclusion

Factory Pattern helps build:

* Scalable systems
* Maintainable code
* Clean architecture

👉 In production systems, it is commonly combined with **Dependency Injection** for maximum flexibility.

---

[1]: https://www.geeksforgeeks.org/java/factory-method-design-pattern-in-java/?utm_source=chatgpt.com "Factory Method Design Pattern in Java"
[2]: https://www.tutorialspoint.com/design_pattern/factory_pattern.htm?utm_source=chatgpt.com "Design Patterns - Factory Pattern"
