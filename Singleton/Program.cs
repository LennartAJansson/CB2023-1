using Singleton;

SingletonSimple s1 = SingletonSimple.Instance;
Console.WriteLine($"s1 instance id = {s1.InstanceId}");

SingletonSimple s2 = SingletonSimple.Instance;
Console.WriteLine($"s2 instance id = {s2.InstanceId}");
