namespace Singleton.Implementations;

using System;

public class LazyLoadingSingleton
{
    private static readonly Lazy<LazyLoadingSingleton> _instance =
        new Lazy<LazyLoadingSingleton>(() => new LazyLoadingSingleton());

    private LazyLoadingSingleton(){}

    public static LazyLoadingSingleton Instance => _instance.Value;
}