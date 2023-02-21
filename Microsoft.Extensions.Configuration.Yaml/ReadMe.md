﻿This project is using string resources to allow localisation, see more:

﻿[Localisation .NET 6.0](https://docs.microsoft.com/en-us/aspnet/core/fundamentals/localization?view=aspnetcore-6.0)

The extension method AddYamlFile extends IConfigurationBuilder and adds a FileConfigurationSource to the IConfigurationBuilder

The FileConfigurationSource adds a FileConfigurationProvider

The FileConfigurationProvider uses the overridden Load method to parse the yaml code with the help of a ConfigurationFileParser

The project will create a nuget package that could be used in other projects. Read more about versioning here:

[Versioning of packages](https://docs.microsoft.com/en-gb/nuget/concepts/package-versioning)

