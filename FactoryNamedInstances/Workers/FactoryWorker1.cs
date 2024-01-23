using FactoryNamedInstances.Factories;
using FactoryNamedInstances.Instances;

namespace FactoryNamedInstances.Workers;

public class FactoryWorker1 : BackgroundService
{
    private readonly ILogger<FactoryWorker1> logger;
    private readonly NamedInstancesFactory<INamedInstance> factory;

    public FactoryWorker1(ILogger<FactoryWorker1> logger, NamedInstancesFactory<INamedInstance> factory)
    {
        this.logger = logger;
        this.factory = factory;
    }

    protected override async Task ExecuteAsync(CancellationToken stoppingToken)
    {
        while (!stoppingToken.IsCancellationRequested)
        {
            logger.LogInformation("FactoryWorker1 running at: {time}", DateTimeOffset.Now);

            INamedInstance instance = factory.GetInstance(GetType().Name) ?? throw new NullReferenceException();
            await instance.Execute("Hello from FactoryWorker1");

            await Task.Delay(2000, stoppingToken);
        }
    }
}

