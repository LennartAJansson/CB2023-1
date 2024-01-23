using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
//using Microsoft.Extensions.Logging.ColorConsole;

IHost host = Host.CreateDefaultBuilder(args)
    .ConfigureServices(services =>
    {
      _ = services.AddLogging(builder => builder.SetMinimumLevel(LogLevel.Trace));
      _ = services.AddLogging(builder =>
      {
        _ = builder.ClearProviders();
        _ = builder.SetMinimumLevel(LogLevel.Trace);
        _ = builder.AddConsole();
        //_ = builder.AddColorConsoleLogger(configuration =>
        //  {
        //    configuration.LogLevels.Add(LogLevel.Trace, ConsoleColor.DarkGray);
        //    configuration.LogLevels.Add(LogLevel.Debug, ConsoleColor.Gray);
        //    configuration.LogLevels.Add(LogLevel.Information, ConsoleColor.DarkGreen);
        //    configuration.LogLevels.Add(LogLevel.Warning, ConsoleColor.DarkYellow);
        //    configuration.LogLevels.Add(LogLevel.Error, ConsoleColor.DarkRed);
        //    configuration.LogLevels.Add(LogLevel.Critical, ConsoleColor.Red);
        //  });
      });
    })
    .Build();

using (IServiceScope scope = host.Services.CreateScope())
{
  ILogger<Program> logger = scope.ServiceProvider.GetRequiredService<ILogger<Program>>();
  logger.LogTrace("Trace");
  logger.LogDebug("Debug");
  logger.LogInformation("Information");
  logger.LogWarning("Warning");
  logger.LogError("Error");
  logger.LogCritical("Critical");
}