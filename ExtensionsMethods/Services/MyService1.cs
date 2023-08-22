namespace ExtensionsMethods.Services;

using ExtensionsMethods.Interfaces;

using Microsoft.Extensions.Logging;

public class MyService1 : IMyService1
{
    private readonly ILogger<MyService1> logger;

    public MyService1(ILogger<MyService1> logger)
    {
        this.logger = logger;
    }

    public void DoSomething()
    {
        logger.LogInformation("Something...");
    }
}
