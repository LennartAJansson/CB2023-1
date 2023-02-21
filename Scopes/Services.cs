namespace Scopes;
using System;
using System.Threading.Tasks;

public class MyBaseService
{
    public Guid Id { get; set; } = Guid.NewGuid();

    public Task RunAsync()
    {
        Console.WriteLine($"In {GetType().Name}, instance {Id}");
        return Task.CompletedTask;
    }
}

public sealed class MyTransientService : MyBaseService
{
}

public sealed class MyScopedService : MyBaseService
{
}

public sealed class MySingletonService : MyBaseService
{
}
