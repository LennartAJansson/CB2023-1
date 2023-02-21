namespace FactoryNamedInstances.Factories;

using System.Reflection;

public static class SetupFactoryExtensions
{

    public static IServiceCollection AddFactory<T>(this IServiceCollection services, params Assembly[] assemblies)
    {
        //This registers all the concrete types that implement the interface T
        //They will be injectable as an IEnumerable<T> showed in the samples NonFactoryWorker1 and 2
        foreach (Assembly assembly in assemblies)
        {
            foreach (Type? concrete in assembly.GetTypes().Where(t => t.GetInterfaces().Contains(typeof(T))))
            {
                _ = services.AddTransient(typeof(T), concrete);
                //_ = services.AddSingleton(typeof(T), concrete);
            }
        }

        //This registers a factory for all IEnumerable<T>
        //They will be injectable through NamedInstancesFactory<T>
        //and through the factory reachable by their name showed in the samples FactoryWorker1 and 2
        _ = services.AddSingleton(sp =>
        {
            NamedInstancesFactory<T> factory = new(sp.GetRequiredService<IConfiguration>());

            foreach (Assembly assembly in assemblies)
            {
                //Get all implementations for our T interface
                foreach (Type? implementation in assembly.GetTypes().Where(t => t.GetInterfaces().Contains(typeof(T))))
                {
#pragma warning disable CS8603 // Possible null reference return.
                    //Register the implementation in the factory by using a lambda that will return the implementation
                    factory.Register(implementation.Name, () =>
                        sp.GetServices<T>().FirstOrDefault(s => s!.GetType().Name.Equals(implementation.Name)) ?? default);
#pragma warning restore CS8603 // Possible null reference return.
                }
            }

            return factory;
        });

        return services;
    }
}
