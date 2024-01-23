namespace Options;

public sealed class HttpSettings
{
  public const string SectionName = "HttpSettings";
  public string? BaseUrl { get; set; }
  public int TimeOut { get; set; }
  public int Retries { get; set; }
}
