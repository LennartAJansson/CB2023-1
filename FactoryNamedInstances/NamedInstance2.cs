namespace FactoryNamedInstances;

using System.Threading.Tasks;

using Microsoft.Extensions.Logging;

public class NamedInstance2 : INamedInstances
{
    private readonly ILogger<NamedInstance2> logger;

    public NamedInstance2(ILogger<NamedInstance2> logger)
    {
        this.logger = logger;
    }
    public Task Execute(string msg)
    {
        logger.LogInformation("Executing in NamedInstance2: {message}", msg);
        return Task.CompletedTask;
    }
}
