namespace AbstractFactory.Accounts;

using AbstractFactory.Interfaces;

public class NationalSavingsAccount : ISavingsAccount
{
    public NationalSavingsAccount() => Console.WriteLine("Returned National Savings Account");
}
