namespace ExtensionsMethods;

using Microsoft.Extensions.DependencyInjection;

public static class MyServiceExtensions
{
    public static IServiceCollection AddMyServices(this IServiceCollection services)
    {
        _ = services.AddScoped<IMyService1, MyService1>();
        _ = services.AddScoped<IMyService2, MyService2>();

        return services;
    }
}
