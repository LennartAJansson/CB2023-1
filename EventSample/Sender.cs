namespace EventSample;

internal delegate void NewPersonDelegate(object sender, Person person);

internal class Sender
{
  public event NewPersonDelegate? NewPerson;

  public void AddPerson(Person person) =>
    NewPerson?.Invoke(this, person);
}
