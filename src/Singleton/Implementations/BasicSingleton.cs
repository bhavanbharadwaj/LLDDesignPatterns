namespace Singleton.Implementations;

public class BasicSingleton
{
    private static BasicSingleton? _instance;

    private BasicSingleton(){}

    public static BasicSingleton GetInstance()
    {
        if (_instance == null)
            _instance = new BasicSingleton();

        return _instance;
    }
}