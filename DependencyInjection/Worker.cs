namespace DependencyInjection;

using Microsoft.Extensions.Logging;

public sealed class ApplicationLayer
{
    private readonly DomainLayer domainLayer;

    public ApplicationLayer(ILogger<ApplicationLayer> logger, DomainLayer domainLayer)
    {
        logger.LogInformation("Creating applicationlayer");
        this.domainLayer = domainLayer;
    }
}

public sealed class DomainLayer
{
    public DomainLayer(ILogger<DomainLayer> logger, ServiceLayer serviceLayer)
    {
        logger.LogInformation("Creating domainlayer");
    }
}

public sealed class ServiceLayer
{
    public ServiceLayer(ILogger<ServiceLayer> logger)
    {
        logger.LogInformation("Creating servicelayer");
    }
}