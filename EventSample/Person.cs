namespace EventSample;

internal class Person
{
  public required string Firstname { get; set; }
  public required string Lastname { get; set; }

  public static Person Create(string firstName, string lastName) =>
    new() { Firstname = firstName, Lastname = lastName };
}
