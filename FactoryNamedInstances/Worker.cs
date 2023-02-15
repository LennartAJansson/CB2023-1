namespace FactoryNamedInstances;

public class Worker : BackgroundService
{
    private readonly ILogger<Worker> _logger;
    private readonly Factory<II> factory;

    public Worker(ILogger<Worker> logger, Factory<II> factory)
    {
        _logger = logger;
        this.factory = factory;
    }

    protected override async Task ExecuteAsync(CancellationToken stoppingToken)
    {
        while (!stoppingToken.IsCancellationRequested)
        {
            _logger.LogInformation("Worker running at: {time}", DateTimeOffset.Now);
            II i1 = factory.Create("I1");
            await i1.Execute("Hello from Workern");
            II i2 = factory.Create("I2");
            await i2.Execute("Hello from Workern");
            await Task.Delay(1000, stoppingToken);
        }
    }
}
