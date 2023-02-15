namespace FactoryNamedInstances;

public static class SetupFactoryExtensions
{
    public static IServiceCollection AddFactory(this IServiceCollection services)
    {
        _ = services.AddTransient<NamedInstance1>();
        _ = services.AddTransient<NamedInstance2>();

        _ = services.AddSingleton<NamedInstancesFactory<INamedInstances>>(sp =>
        {
            NamedInstancesFactory<INamedInstances> factory = new();
            factory.Register("Instance1", () => sp.GetRequiredService<NamedInstance1>());
            factory.Register("Instance2", () => sp.GetRequiredService<NamedInstance2>());
            return factory;
        });
        return services;
    }
}
