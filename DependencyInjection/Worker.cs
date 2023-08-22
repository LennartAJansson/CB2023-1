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
        this.logger = logger;
        this.logger.LogInformation("Creating applicationlayer");
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
        this.logger = logger;
        this.logger.LogInformation("Creating domainlayer");
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
        this.logger = logger;
        this.logger.LogInformation("Creating servicelayer");
    }
}