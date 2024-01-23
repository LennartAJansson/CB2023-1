namespace Microsoft.Extensions.Configuration.Yaml;

using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

using YamlDotNet.Core;
using YamlDotNet.RepresentationModel;

public sealed class YamlConfigurationFileParser
{
  private readonly SortedDictionary<string, string> data = new(StringComparer.OrdinalIgnoreCase);
  private readonly Stack<string> context = new();
  private string currentPath;

  public IDictionary<string, string> Parse(Stream input)
  {
    data.Clear();
    context.Clear();

    YamlStream yaml = [];
    yaml.Load(new StreamReader(input, detectEncodingFromByteOrderMarks: true));

    if (yaml.Documents.Any())
    {
      YamlMappingNode mapping = (YamlMappingNode)yaml.Documents[0].RootNode;

      VisitYamlMappingNode(mapping);
    }

    return data;
  }

  private void VisitYamlNodePair(KeyValuePair<YamlNode, YamlNode> yamlNodePair)
  {
    string context = ((YamlScalarNode)yamlNodePair.Key).Value;
    VisitYamlNode(context, yamlNodePair.Value);
  }

  private void VisitYamlNode(string context, YamlNode node)
  {
    if (node is YamlScalarNode scalarNode)
    {
      VisitYamlScalarNode(context, scalarNode);
    }

    if (node is YamlMappingNode mappingNode)
    {
      VisitYamlMappingNode(context, mappingNode);
    }

    if (node is YamlSequenceNode sequenceNode)
    {
      VisitYamlSequenceNode(context, sequenceNode);
    }
  }

  private void VisitYamlScalarNode(string context, YamlScalarNode yamlValue)
  {
    EnterContext(context);

    string currentKey = currentPath;

    if (data.ContainsKey(currentKey))
    {
      throw new FormatException(Resources.FormatError_KeyIsDuplicated(currentKey));
    }

    data[currentKey] = IsNullValue(yamlValue) ? null : yamlValue.Value;

    ExitContext();
  }

  private void VisitYamlMappingNode(YamlMappingNode node)
  {
    foreach (KeyValuePair<YamlNode, YamlNode> yamlNodePair in node.Children)
    {
      VisitYamlNodePair(yamlNodePair);
    }
  }

  private void VisitYamlMappingNode(string context, YamlMappingNode yamlValue)
  {
    EnterContext(context);

    VisitYamlMappingNode(yamlValue);

    ExitContext();
  }

  private void VisitYamlSequenceNode(string context, YamlSequenceNode yamlValue)
  {
    EnterContext(context);

    VisitYamlSequenceNode(yamlValue);

    ExitContext();
  }

  private void VisitYamlSequenceNode(YamlSequenceNode node)
  {
    for (int i = 0; i < node.Children.Count; i++)
    {
      VisitYamlNode(i.ToString(), node.Children[i]);
    }
  }

  private void EnterContext(string context)
  {
    this.context.Push(context);
    currentPath = ConfigurationPath.Combine(this.context.Reverse());
  }

  private void ExitContext()
  {
    _ = context.Pop();
    currentPath = ConfigurationPath.Combine(context.Reverse());
  }

  private static bool IsNullValue(YamlScalarNode yamlValue) => yamlValue.Style == ScalarStyle.Plain
          && (yamlValue.Value == "~" || yamlValue.Value == "null"
              || yamlValue.Value == "Null" || yamlValue.Value == "NULL");
}