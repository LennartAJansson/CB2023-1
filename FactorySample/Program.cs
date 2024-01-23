using FactorySample.Factories;
using FactorySample.Interfaces;

IAccountFactory factory = new AccountFactory();

ISavingsAccount citiAcct = factory.GetSavingsAccount("CITI-321");
ISavingsAccount nationalAcct = factory.GetSavingsAccount("NATIONAL-987");

Console.WriteLine($"My citi balance is ${citiAcct.Balance} and national balance is ${nationalAcct.Balance}");
