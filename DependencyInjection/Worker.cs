namespace DependencyInjection;

using Microsoft.Extensions.Logging;

public interface IApplicationLayer
{
}
public sealed class ApplicationLayer: IApplicationLayer
{
    private readonly ILogger<ApplicationLayer> logger;
    private readonly IDomainLayer domainLayer;

    public ApplicationLayer(ILogger<ApplicationLayer> logger, IDomainLayer domainLayer)
    {
        logger.LogInformation("Creating applicationlayer");
        this.logger = logger;
        this.domainLayer = domainLayer;
    }
}

public interface IDomainLayer
{
}
public sealed class DomainLayer: IDomainLayer
{
    private readonly ILogger<DomainLayer> logger;
    private readonly IServiceLayer serviceLayer;

    public DomainLayer(ILogger<DomainLayer> logger, IServiceLayer serviceLayer)
    {
        logger.LogInformation("Creating domainlayer");
        this.logger = logger;
        this.serviceLayer = serviceLayer;
    }
}

public interface IServiceLayer
{
}
public sealed class ServiceLayer:IServiceLayer
{
    private readonly ILogger<ServiceLayer> logger;

    public ServiceLayer(ILogger<ServiceLayer> logger)
    {
        logger.LogInformation("Creating servicelayer");
        this.logger = logger;
    }
}