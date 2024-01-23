namespace DependencyInjection;

using Microsoft.Extensions.Logging;

public sealed class DomainLayer: IDomainLayer
{
    private readonly ILogger<DomainLayer> logger;
    private readonly IServiceLayer serviceLayer;

    public DomainLayer(ILogger<DomainLayer> logger, IServiceLayer serviceLayer)
    {
        this.logger = logger;
        this.logger.LogInformation("Creating domainlayer");
        this.serviceLayer = serviceLayer;
    }
}
