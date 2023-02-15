namespace FactoryNamedInstances;

public class Program
{
    public static void Main(string[] args)
    {
        IHost host = Host.CreateDefaultBuilder(args)
            .ConfigureServices(services =>
            {
                _ = services.AddFactory();
                _ = services.AddHostedService<Worker>();
            })
            .Build();

        host.Run();
    }
}