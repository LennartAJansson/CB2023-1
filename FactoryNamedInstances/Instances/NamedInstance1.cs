namespace FactoryNamedInstances.Instances;

using System.Threading.Tasks;

public class NamedInstance1 : INamedInstance
{
    private readonly ILogger<NamedInstance1> logger;
    private readonly Guid id = Guid.NewGuid();

    public NamedInstance1(ILogger<NamedInstance1> logger)
    {
        this.logger = logger;
    }
    public Task Execute(string msg)
    {
        logger.LogInformation("Executing in {concrete}({id}): {message}", GetType().Name, id, msg);
        return Task.CompletedTask;
    }
}
