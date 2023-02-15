namespace FactoryNamedInstances;

public class Worker : BackgroundService
{
    private readonly ILogger<Worker> logger;
    private readonly NamedInstancesFactory<INamedInstances> factory;

    public Worker(ILogger<Worker> logger, NamedInstancesFactory<INamedInstances> factory)
    {
        this.logger = logger;
        this.factory = factory;
    }

    protected override async Task ExecuteAsync(CancellationToken stoppingToken)
    {
        while (!stoppingToken.IsCancellationRequested)
        {
            logger.LogInformation("Worker running at: {time}", DateTimeOffset.Now);

            //The name here could be controlled by configuration fx
            INamedInstances i1 = factory.Create("Instance1");
            await i1.Execute("Hello from Worker");

            //The name here could be controlled by configuration fx
            INamedInstances i2 = factory.Create("Instance2");
            await i2.Execute("Hello from Worker");

            await Task.Delay(1000, stoppingToken);
        }
    }
}
