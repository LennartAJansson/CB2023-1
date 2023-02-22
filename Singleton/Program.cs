using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

using Singleton;

IHost host = Host.CreateDefaultBuilder(args)
    .ConfigureServices(services =>
    {
    })
    .Build();

using (IServiceScope scope = host.Services.CreateScope())
{

    SingletonSimple s = SingletonSimple.Instance;
    SingletonSimple s2 = SingletonSimple.Instance;  
}