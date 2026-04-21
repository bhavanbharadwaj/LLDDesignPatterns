# Singleton Pattern

## 🧠 What
Ensures only one instance of a class exists and provides a global access point.

---

## 🎯 When to Use
- Logger
- Configuration manager
- Cache
- Shared resources

---

## ❌ Problem it Solves
Prevents multiple instances of a class that should be shared across the system.

---

## 🛠️ Implementations in C#

### 1. Basic Singleton (NOT thread-safe ❌)
- Simple but unsafe in multi-threaded environments

### 2. Static (Eager Initialization) ✅
- Thread-safe (handled by CLR)
- Instance created immediately

### 3. Lazy<T> Singleton ✅ (BEST)
- Thread-safe by default
- Lazy initialization
- Clean and recommended

---

## ⚡ Key Concepts

### Static Initialization
- Thread-safe by CLR
- Object created when class is first loaded
- Not lazy ❌

### Lazy<T>
- Object created only when `.Value` is accessed
- Thread-safe by default
- Preferred approach ✅

---

## 🔥 Comparison

| Approach | Thread-safe | Lazy | Notes |
|--------|------------|------|------|
| Basic | ❌ | ❌ | Not safe |
| Static (eager) | ✅ | ❌ | Simple but always created |
| Lazy<T> | ✅ | ✅ | Best option |

---

## 🚀 Example Output

=== Singleton Demo ===  
Logger Initialized  
Log: First message  
Log: Second message  
Same instance? True  

---

## 🔥 Interview Line

"Static initialization in .NET is thread-safe. For lazy initialization, I prefer Lazy<T> which ensures thread safety and creates the instance only when needed."

---

## ⚠️ Pitfalls
- Overuse leads to global state issues
- Harder to unit test
- Lazy<T> can be misconfigured (non-thread-safe mode)

---

## 🔗 Used With
- Factory
- Dependency Injection (alternative in real systems)