namespace Microsoft.Extensions.Configuration.Yaml;

public sealed class YamlConfigurationSource : FileConfigurationSource
{
    public override IConfigurationProvider Build(IConfigurationBuilder builder)
    {
        EnsureDefaults(builder);

        return new YamlConfigurationProvider(this);
    }
}