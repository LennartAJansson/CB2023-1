using System;
using System.IO;

using YamlDotNet.Core;

namespace Microsoft.Extensions.Configuration.Yaml
{
    public sealed class YamlConfigurationProvider : FileConfigurationProvider
    {
        public YamlConfigurationProvider(YamlConfigurationSource source)
            : base(source)
        { }

        public override void Load(Stream stream)
        {
            YamlConfigurationFileParser parser = new YamlConfigurationFileParser();

            try
            {
                Data = parser.Parse(stream);
            }
            catch (YamlException e)
            {
                throw new FormatException(Resources.FormatError_YamlParseError(e.Message), e);
            }
        }
    }
}