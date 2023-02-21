using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

IHost host = Host.CreateDefaultBuilder(args)
    .ConfigureServices((context, services) =>
    {
        _ = services.AddScoped<IMyService1, MyService1>();
        _ = services.AddScoped<IMyService2, MyService2>();
        //_ = services.AddMyServices();
    })
    .Build();

using (IServiceScope scope = host.Services.CreateScope())
{
    scope.ServiceProvider.GetRequiredService<IMyService1>().DoSomething();
    scope.ServiceProvider.GetRequiredService<IMyService2>().DoSomethingElse();
}
