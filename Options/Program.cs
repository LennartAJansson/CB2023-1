using Options;

IHost host = Host.CreateDefaultBuilder(args)
    .ConfigureServices((context, services) =>
    {
      //Read config value and add as a singleton
      _ = services.AddSingleton(context.Configuration.GetSection(HttpSettings.SectionName).Get<HttpSettings>() ??
              throw new ArgumentException($"Setting for {HttpSettings.SectionName} is null"));

      //Set values manually
      _ = services.Configure<HttpSettings>(options =>
      {
        options.BaseUrl = "https://localhost:5001";
        options.TimeOut = 30;
        options.Retries = 3;
      });

      //Bind value to an IOption of HttpSettings
      _ = services.Configure<HttpSettings>(options =>
          context.Configuration.GetSection(HttpSettings.SectionName).Bind(options));

      //Bind value to an IOption of HttpSettings
      _ = services.Configure<HttpSettings>(context.Configuration.GetSection(HttpSettings.SectionName));

      //Inspect the worker classes to see how to use the IOptions
      _ = services.AddHostedService<Worker1>();
      _ = services.AddHostedService<Worker2>();
      _ = services.AddHostedService<Worker3>();
    })
    .Build();

host.Run();
