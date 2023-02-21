using DependencyInjection;

using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

IHost host = Host.CreateDefaultBuilder(args)
    .ConfigureServices(services =>
    {
        _ = services.AddSingleton<ApplicationLayer>();
        _ = services.AddTransient<DomainLayer>();
        _ = services.AddTransient<ServiceLayer>();
    })
    .Build();

using (IServiceScope scope = host.Services.CreateScope())
{
    ApplicationLayer applicationLayer = scope.ServiceProvider.GetRequiredService<ApplicationLayer>();
}