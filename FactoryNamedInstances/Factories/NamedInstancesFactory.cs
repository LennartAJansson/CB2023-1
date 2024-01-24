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

    public T? GetInstance(string name)
    {
        string? worker = configuration.GetSection("Workers")[name] ??
            throw new ArgumentException("Didn't find any configured worker instance for {worker}", name);

        return factories.ContainsKey(worker) ? factories[worker]() : default;
    }
}
