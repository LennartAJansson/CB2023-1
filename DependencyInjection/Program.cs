using DependencyInjection;

using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

IHost host = Host.CreateDefaultBuilder(args)
    .ConfigureServices(services =>
    {
        _ = services.AddSingleton<IApplicationLayer, ApplicationLayer>();
        _ = services.AddTransient<IDomainLayer, DomainLayer>();
        _ = services.AddTransient<IServiceLayer, ServiceLayer>();
    })
    
    .Build();

using (IServiceScope scope = host.Services.CreateScope())
{
    IApplicationLayer applicationLayer = scope.ServiceProvider.GetRequiredService<IApplicationLayer>();
}
