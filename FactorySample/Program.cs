using FactorySample.Accounts;
using FactorySample.Factories;
using FactorySample.Interfaces;

IAccountFactory factory = new AccountFactory();

SavingsAccount citiAcct = factory.GetSavingsAccount("CITI-321");
SavingsAccount nationalAcct = factory.GetSavingsAccount("NATIONAL-987");

Console.WriteLine($"My citi balance is ${citiAcct.Balance} and national balance is ${nationalAcct.Balance}");
