namespace ExtensionsMethods.Services;

using ExtensionsMethods.Interfaces;

using Microsoft.Extensions.Logging;

public class MyService2 : IMyService2
{
    private readonly ILogger<MyService2> logger;

    public MyService2(ILogger<MyService2> logger)
    {
        this.logger = logger;
    }
    public void DoSomethingElse()
    {
        logger.LogInformation("Something else...");
    }
}
