using FactoryNamedInstances.Instances;

namespace FactoryNamedInstances.Workers;

public class NonFactoryWorker1 : BackgroundService
{
    private readonly ILogger<NonFactoryWorker1> logger;
    private readonly IEnumerable<INamedInstance> instances;

    public NonFactoryWorker1(ILogger<NonFactoryWorker1> logger, IEnumerable<INamedInstance> instances)
    {
        this.logger = logger;
        this.instances = instances;
    }

    protected override async Task ExecuteAsync(CancellationToken stoppingToken)
    {
        while (!stoppingToken.IsCancellationRequested)
        {
            logger.LogInformation("NonFactoryWorker1 running at: {time}", DateTimeOffset.Now);

            INamedInstance instance = instances.First(i => i is NamedInstance1) ?? throw new ArgumentNullException();

            await instance.Execute("Hello from NonFactoryWorker1");

            await Task.Delay(3000, stoppingToken);
        }
    }
}
