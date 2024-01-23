using EventSample;

Sender sender = new();
Receiver receiver = new(sender);

receiver.StartListen();

sender.AddPerson(Person.Create("John", "Doe"));
sender.AddPerson(Person.Create("Jane", "Doe"));
sender.AddPerson(Person.Create("John", "Smith"));
sender.AddPerson(Person.Create("Jane", "Smith"));

receiver.StopListen();

sender.AddPerson(Person.Create("John", "Doe"));
sender.AddPerson(Person.Create("Jane", "Doe"));
sender.AddPerson(Person.Create("John", "Smith"));
sender.AddPerson(Person.Create("Jane", "Smith"));

