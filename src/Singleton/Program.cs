using System;
using Singleton.Implementations;

class Program
{
    static void Main()
    {
        Console.WriteLine("=== Static Singleton ===");

        var s1 = StaticSingleton.Instance;
        var s2 = StaticSingleton.Instance;

        Console.WriteLine(ReferenceEquals(s1, s2));

        Console.WriteLine("\n=== Lazy Singleton ===");

        var l1 = LazyLoadingSingleton.Instance;
        var l2 = LazyLoadingSingleton.Instance;

        Console.WriteLine(ReferenceEquals(l1, l2));
    }
}