namespace Singleton.Implementations;

public class StaticSingleton
{
    private static readonly StaticSingleton _instance = new StaticSingleton();

    private StaticSingleton(){}

    public static StaticSingleton Instance => _instance;
}