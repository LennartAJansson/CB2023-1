namespace FactoryNamedInstances;

using System.Threading.Tasks;

using Microsoft.Extensions.Logging;

public class I2 : II
{
    private readonly ILogger<I2> logger;

    public I2(ILogger<I2> logger)
    {
        this.logger = logger;
    }
    public Task Execute(string msg)
    {
        logger.LogInformation("Executing in I2: {message}", msg);
        return Task.CompletedTask;
    }
}
