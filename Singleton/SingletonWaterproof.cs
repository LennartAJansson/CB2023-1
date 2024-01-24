namespace Singleton;

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
            if (instance is null)
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