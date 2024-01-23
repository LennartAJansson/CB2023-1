using FactoryNamedInstances.Instances;

namespace FactoryNamedInstances.Workers;

public class NonFactoryWorker2 : BackgroundService
{
    private readonly ILogger<NonFactoryWorker2> logger;
    private readonly IEnumerable<INamedInstance> instances;

    public NonFactoryWorker2(ILogger<NonFactoryWorker2> logger, IEnumerable<INamedInstance> instances)
    {
        this.logger = logger;
        this.instances = instances;
    }

    protected override async Task ExecuteAsync(CancellationToken stoppingToken)
    {
        while (!stoppingToken.IsCancellationRequested)
        {
            logger.LogInformation("NonFactoryWorker2 running at: {time}", DateTimeOffset.Now);

            INamedInstance instance = instances.First(i => i is NamedInstance2) ?? throw new ArgumentNullException();

            await instance.Execute("Hello from NonFactoryWorker2");

            await Task.Delay(3000, stoppingToken);
        }
    }
}
