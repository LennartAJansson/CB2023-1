namespace DependencyInjection;

using Microsoft.Extensions.Logging;
public sealed class ServiceLayer:IServiceLayer
{
    private readonly ILogger<ServiceLayer> logger;

    public ServiceLayer(ILogger<ServiceLayer> logger)
    {
        this.logger = logger;
        this.logger.LogInformation("Creating servicelayer");
    }
}