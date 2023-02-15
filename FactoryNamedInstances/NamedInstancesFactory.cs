namespace FactoryNamedInstances;

public class NamedInstancesFactory<T>
{
    private readonly Dictionary<string, Func<T>> _factories = new();

    public void Register(string name, Func<T> factory)
    {
        _factories.Add(name, factory);
    }

    public T Create(string name)
    {
        return _factories[name]();
    }
}
