using Microsoft.Extensions.DependencyInjection;

using Scopes;

IServiceProvider serviceProvider = new ServiceCollection()
    .AddTransient<MyTransientService>()
    .AddScoped<MyScopedService>()
    .AddSingleton<MySingletonService>()
    .BuildServiceProvider();

for (int loop = 1; loop <= 2; loop++)
{
    using IServiceScope? scope = serviceProvider.CreateScope();

    IServiceProvider? services = scope.ServiceProvider;
    Console.WriteLine($"Creating a new scope");

    Console.WriteLine($"\nCreating the first instances of our three services, loop {loop}");
    await RunServices(scope.ServiceProvider);

    Console.WriteLine($"\nCreating the second instances of our three services, loop {loop}");
    await RunServices(scope.ServiceProvider);

    Console.WriteLine();
}

static async Task RunServices(IServiceProvider serviceProvider)
{
    MySingletonService? mySingleton = serviceProvider.GetRequiredService<MySingletonService>();
    await mySingleton.RunAsync();

    MyScopedService? myScopedService = serviceProvider.GetRequiredService<MyScopedService>();
    await myScopedService.RunAsync();

    MyTransientService? myTransientService = serviceProvider.GetRequiredService<MyTransientService>();
    await myTransientService.RunAsync();
}
