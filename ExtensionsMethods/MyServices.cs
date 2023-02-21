using Microsoft.Extensions.Logging;

public interface IMyService1
{
    void DoSomething();
}

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

public interface IMyService2
{
    void DoSomethingElse();
}

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
