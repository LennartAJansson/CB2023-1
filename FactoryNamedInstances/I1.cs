namespace FactoryNamedInstances;

using System.Threading.Tasks;

public class I1 : II
{
    private readonly ILogger<I1> logger;

    public I1(ILogger<I1> logger)
    {
        this.logger = logger;
    }
    public Task Execute(string msg)
    {
        logger.LogInformation("Executing in I1: {message}", msg);
        return Task.CompletedTask;
    }
}
