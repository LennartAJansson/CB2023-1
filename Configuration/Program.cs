using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Configuration.Yaml;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;

IHost host = Host.CreateDefaultBuilder(args)
    //.ConfigureAppConfiguration((hostingContext, config) =>
    //{
    //    _ = config.AddYamlFile("Test.yaml");
    //})
    .ConfigureServices((context, services) =>
    {
    })
    .Build();

using (IServiceScope scope = host.Services.CreateScope())
{
    ILogger<Program> logger = scope.ServiceProvider.GetRequiredService<ILogger<Program>>();
    IConfiguration configuration = scope.ServiceProvider.GetRequiredService<IConfiguration>();
    logger.LogInformation("Json: {Test}", configuration.GetValue<string>("JsonTopSection:JsonSubSection1:JsonKey"));
    //logger.LogInformation("Yaml: {Test}", configuration.GetValue<string>("YamlTopSection:YamlSubSection1:YamlKey"));
}