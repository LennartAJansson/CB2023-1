namespace Microsoft.Extensions.Logging.ColorConsole
{
    public class ColorConsoleLoggerConfiguration
    {
        public int EventId { get; set; }

        public Dictionary<LogLevel, ConsoleColor> LogLevels { get; set; } = new()
        {
            //[LogLevel.Information] = ConsoleColor.Green
        };

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