namespace Singleton;

public sealed class SingletonSimple
{
    public Guid InstanceId { get; set; } = Guid.NewGuid();

    private static SingletonSimple? instance;

    private SingletonSimple()
    {
    }

    public static SingletonSimple Instance
    {
        get
        {
            instance ??= new SingletonSimple();

            return instance;
        }
    }
}

public sealed class SingletonMediumSafe
{
    public Guid InstanceId { get; set; } = Guid.NewGuid();

    private static SingletonMediumSafe? instance;
    private static readonly object lockObject = new();

    private SingletonMediumSafe()
    {
    }

    public static SingletonMediumSafe Instance
    {
        get
        {
            lock (lockObject)
            {
                instance ??= new SingletonMediumSafe();
            }
            return instance;
        }
    }
}

public sealed class SingletonWaterproof
{
    public Guid InstanceId { get; set; } = Guid.NewGuid();

    private static SingletonWaterproof? instance;
    private static readonly object lockObject = new();

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
                    instance ??= new SingletonWaterproof();
                }
            }
            return instance;
        }
    }
}

//Jon Skeet C# Programming Book