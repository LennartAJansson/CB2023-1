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

//Jon Skeet C# Programming Book