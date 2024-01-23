namespace Singleton;

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

//Jon Skeet C# Programming Book