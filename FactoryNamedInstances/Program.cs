using FactoryNamedInstances.Factories;
using FactoryNamedInstances.Instances;
using FactoryNamedInstances.Workers;

namespace FactoryNamedInstances;

public class Program
{
    public static void Main(string[] args)
    {
        IHost host = Host.CreateDefaultBuilder(args)
            .ConfigureServices(services =>
            {
                _ = services.AddFactory<INamedInstance>(typeof(Program).Assembly);
                
                _ = services.AddHostedService<FactoryWorker1>();
                _ = services.AddHostedService<FactoryWorker2>();
                //_ = services.AddHostedService<NonFactoryWorker1>();
                //_ = services.AddHostedService<NonFactoryWorker2>();
            })
            .Build();

        host.Run();
    }
}