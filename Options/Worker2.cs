namespace Options;

using System.Text.Json;

using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;


public sealed class Worker2 : BackgroundService
{
  private readonly ILogger<Worker2> logger;
  private readonly HttpSettings settings;
  private readonly JsonSerializerOptions jsonOptions = new() { WriteIndented = true };

  public Worker2(ILogger<Worker2> logger, IOptions<HttpSettings> options)
  {
    this.logger = logger;
    settings = options.Value;
  }

  protected override Task ExecuteAsync(CancellationToken stoppingToken)
  {
    string json = JsonSerializer.Serialize(settings, jsonOptions);
    logger.LogInformation("Settings in Worker2 is:\n{settings}", json);

    return Task.CompletedTask;
  }
}
