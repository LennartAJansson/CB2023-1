namespace FactoryNamedInstances;

public static class Setup
{
    public static IServiceCollection AddFactory(this IServiceCollection services)
    {
        _ = services.AddTransient<I1>();
        _ = services.AddTransient<I2>();

        _ = services.AddSingleton<Factory<II>>(sp =>
        {
            Factory<II> factory = new();
            factory.Register("I1", () => sp.GetRequiredService<I1>());
            factory.Register("I2", () => sp.GetRequiredService<I2>());
            return factory;
        });
        return services;
    }
}
