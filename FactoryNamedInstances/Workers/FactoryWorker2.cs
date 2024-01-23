using FactoryNamedInstances.Factories;
using FactoryNamedInstances.Instances;

namespace FactoryNamedInstances.Workers;

public class FactoryWorker2 : BackgroundService
{
    private readonly ILogger<FactoryWorker2> logger;
    private readonly NamedInstancesFactory<INamedInstance> factory;

    public FactoryWorker2(ILogger<FactoryWorker2> logger, NamedInstancesFactory<INamedInstance> factory)
    {
        this.logger = logger;
        this.factory = factory;
    }

    protected override async Task ExecuteAsync(CancellationToken stoppingToken)
    {
        while (!stoppingToken.IsCancellationRequested)
        {
            logger.LogInformation("FactoryWorker2 running at: {time}", DateTimeOffset.Now);

            //The name here could be controlled by configuration fx
            //These Namedinstances they will be new fresh each time
            INamedInstance instance = factory.GetInstance(GetType().Name) ?? throw new NullReferenceException();
            await instance.Execute("Hello from FactoryWorker2");

            await Task.Delay(2000, stoppingToken);
        }
    }
}

