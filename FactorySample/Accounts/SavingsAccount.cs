namespace FactorySample.Accounts;

using FactorySample.Interfaces;

public abstract class SavingsAccount : ISavingsAccount
{
    public decimal Balance { get; set; }
}
