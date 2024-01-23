namespace Microsoft.Extensions.Logging.ColorConsole;

public class ColorConsoleLogger : ILogger
{
    private readonly string name;
    private readonly Func<ColorConsoleLoggerConfiguration> getCurrentConfig;
    private readonly string[] text = { "trc ", "dbg ", "inf ", "wrn ", "err ", "crit", "none" };

    public ColorConsoleLogger(string name, Func<ColorConsoleLoggerConfiguration> getCurrentConfig) =>
        (this.name, this.getCurrentConfig) = (name, getCurrentConfig);

    public IDisposable BeginScope<TState>(TState state) => default!;

    public bool IsEnabled(LogLevel logLevel) =>
        getCurrentConfig().LogLevels.ContainsKey(logLevel);

    public void Log<TState>(LogLevel logLevel, EventId eventId, TState state, Exception? exception, Func<TState, Exception?, string> formatter)
    {
        if (!IsEnabled(logLevel))
        {
            return;
        }

        ColorConsoleLoggerConfiguration config = getCurrentConfig();

        if (config.EventId == 0 || config.EventId == eventId.Id)
        {
            ConsoleColor originalColor = Console.ForegroundColor;

            Console.ForegroundColor = config.LogLevels[logLevel];

            if (eventId.Id > 0)
            {
                Console.Write($"[{eventId.Id,2}: {text[(int)logLevel]}]");
            }
            else
            {
                Console.Write($"[{text[(int)logLevel]}]");
            }

            Console.ForegroundColor = originalColor;

            Console.WriteLine($"  {name} - {formatter(state, exception)}");
        }
    }
}

/*
{
  "Logging": {
    "LogLevel": { // ALL providers, LogLevel applies to all the enabled providers.
      "Default": "Error", // Default logging, Error and higher.
      "Microsoft": "Warning" // ALL Microsoft* categories, Warning and higher.
    },
    "Debug": { // Debug provider.
      "LogLevel": {
        "Default": "Information", // Overrides preceding LogLevel:Default setting.
        "Microsoft.Hosting": "Trace" // Debug:Microsoft.Hosting category.
      }
    },
    "EventSource": { // EventSource provider
      "LogLevel": {
        "Default": "Warning" // All categories of EventSource provider.
      }
    },
    "Console": {
      "IncludeScopes": true,
      "LogLevel": {
        "Default": "Information",
        "Microsoft": "Warning"
      }
    } 
  }
}

If a provider supports log scopes, IncludeScopes indicates whether they're enabled.

Settings in Logging.{providername}.LogLevel override settings in Logging.LogLevel

Trace = 0, Debug = 1, Information = 2, Warning = 3, Error = 4, Critical = 5, and None = 6



builder.Host.ConfigureLogging(logging =>
               logging.AddFilter("System", LogLevel.Debug)
                  .AddFilter<DebugLoggerProvider>("Microsoft", LogLevel.Information)
                  .AddFilter<ConsoleLoggerProvider>("Microsoft", LogLevel.Trace));*/