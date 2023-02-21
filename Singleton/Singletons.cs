namespace Singleton;

public sealed class SingletonSimple
{
    private static SingletonSimple? instance;

    private SingletonSimple()
    {
    }

    public static SingletonSimple Instance
    {
        get
        {
            if (instance == null)
            {
                instance = new SingletonSimple();
            }

            return instance;
        }
    }
}

public class SingletonMediumSafe
{
    private static SingletonMediumSafe? instance;
    private static readonly object lockObject = new object();
    
    private SingletonMediumSafe()
    {
    }

    public static SingletonMediumSafe Instance
    {
        get
        {
            lock (lockObject)
            {
                if (instance == null)
                {
                    instance = new SingletonMediumSafe();
                }
            }
            return instance;
        }
    }
}

public sealed class SingletonWaterproof
{
    private static SingletonWaterproof? instance;
    private static readonly object lockObject = new object();

    private SingletonWaterproof()
    {
    }

    public static SingletonWaterproof Instance
    {
        get
        {
            if (instance == null)
            {
                lock (lockObject)
                {
                    if (instance == null)
                    {
                        instance = new SingletonWaterproof();
                    }
                }
            }
            return instance;
        }
    }
}