namespace DependencyInjection;

using Microsoft.Extensions.Logging;

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
