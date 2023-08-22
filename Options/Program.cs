using Options;

IHost host = Host.CreateDefaultBuilder(args)
    .ConfigureServices((context, services) =>
    {
        _ = services.AddSingleton(sp => context.Configuration.GetValue<HttpSettings>(HttpSettings.SectionName) ??
                throw new ArgumentException($"Setting for {HttpSettings.SectionName} is null"));

        _ = services.Configure<HttpSettings>(options =>
        {
            options.BaseUrl = "https://localhost:5001";
            options.TimeOut = 30;
            options.Retries = 3;
        });

        _ = services.Configure<HttpSettings>(options =>
            context.Configuration.GetSection(HttpSettings.SectionName).Bind(options));

        _ = services.AddHostedService<Worker1>();
        _ = services.AddHostedService<Worker2>();
    })
    .Build();

host.Run();
