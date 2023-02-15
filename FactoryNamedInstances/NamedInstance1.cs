namespace FactoryNamedInstances;

using System.Threading.Tasks;

public class NamedInstance1 : INamedInstances
{
    private readonly ILogger<NamedInstance1> logger;

    public NamedInstance1(ILogger<NamedInstance1> logger)
    {
        this.logger = logger;
    }
    public Task Execute(string msg)
    {
        logger.LogInformation("Executing in NamedInstance1: {message}", msg);
        return Task.CompletedTask;
    }
}
