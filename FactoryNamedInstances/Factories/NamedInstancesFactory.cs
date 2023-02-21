namespace FactoryNamedInstances.Factories;

public class NamedInstancesFactory<T>
{
    private readonly Dictionary<string, Func<T>> factories = new();
    private readonly IConfiguration configuration;

    public NamedInstancesFactory(IConfiguration configuration)
    {
        this.configuration = configuration;
    }

    public void Register(string name, Func<T> factory)
    {
        factories.Add(name, factory);
    }

    public T? GetInstance(string worker)
    {
        string? name = configuration.GetSection("Workers")[worker] ??
            throw new ArgumentException("Didn't find any configured worker instance for {worker}", worker);

        return factories.ContainsKey(name) ? factories[name]() : default;
    }
}
