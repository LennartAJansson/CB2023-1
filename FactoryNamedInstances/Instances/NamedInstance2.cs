namespace FactoryNamedInstances.Instances;

using System.Threading.Tasks;

using Microsoft.Extensions.Logging;

public class NamedInstance2 : INamedInstance
{
    private readonly ILogger<NamedInstance2> logger;
    private readonly Guid id = Guid.NewGuid();

    public NamedInstance2(ILogger<NamedInstance2> logger)
    {
        this.logger = logger;
    }
    public Task Execute(string msg)
    {
        logger.LogInformation("Executing in {concrete}({id}): {message}", GetType().Name, id, msg);
        return Task.CompletedTask;
    }
}
