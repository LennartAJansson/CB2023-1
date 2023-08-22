namespace AbstractFactory.Accounts;

using AbstractFactory.Interfaces;

public class CitiSavingsAccount : ISavingsAccount
{
    public CitiSavingsAccount() => Console.WriteLine("Returned Citi Savings Account");
}
