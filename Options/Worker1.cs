namespace Options;

using System.Text.Json;

using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;


public sealed class Worker1 : BackgroundService
{
    private readonly ILogger<Worker1> logger;
    private readonly HttpSettings settings;

    public Worker1(ILogger<Worker1> logger, HttpSettings settings)
    {
        this.logger = logger;
        this.settings = settings;
    }

    protected override Task ExecuteAsync(CancellationToken stoppingToken)
    {
        string json = JsonSerializer.Serialize(settings, new JsonSerializerOptions { WriteIndented = true });
        logger.LogInformation("Settings are: {settings}", json);

        return Task.CompletedTask;
    }
}
