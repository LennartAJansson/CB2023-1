namespace EventSample;

internal class Receiver
{
  private readonly Sender sender;

  public Receiver(Sender sender) => this.sender = sender;

  public void StartListen() => sender.NewPerson += OnNewPerson;

  private void OnNewPerson(object sender, Person person) =>
    Console.WriteLine($" From: {sender} - New person received: {person.Firstname} {person.Lastname}");

  public void StopListen() => sender.NewPerson -= OnNewPerson;
}