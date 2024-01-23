namespace Options;

using System.Text.Json;

using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;

public sealed class Worker3 : BackgroundService
{
  private readonly ILogger<Worker3> logger;
  private HttpSettings settings;
  private readonly JsonSerializerOptions jsonOptions = new() { WriteIndented = true };

  public Worker3(ILogger<Worker3> logger, IOptionsMonitor<HttpSettings> options)
  {
    this.logger = logger;
    settings = options.CurrentValue;
    _ = options.OnChange(UpdateValue);
  }

  private void UpdateValue(HttpSettings settings, string? arg)
  {
    if (settings is not null)
    {
      //Triggers twice due to FileSystemWatchers nature
      this.settings = settings;
      string json = JsonSerializer.Serialize(settings, jsonOptions);
      logger.LogInformation("Settings in Worker3 is changed to:\n{settings}", json);
    }
  }

  protected override async Task ExecuteAsync(CancellationToken stoppingToken)
  {
    while (!stoppingToken.IsCancellationRequested)
    {
      string json = JsonSerializer.Serialize(settings, jsonOptions);
      logger.LogInformation("Settings in Worker3 is:\n{settings}", json);

      await Task.Delay(10000, stoppingToken);
    }
  }
}
