namespace FactorySample.Factories;

using FactorySample.Accounts;
using FactorySample.Interfaces;

public class AccountFactory : IAccountFactory
{
    public ISavingsAccount GetSavingsAccount(string acctNo) => acctNo.Contains("CITI")
            ? new CitiSavingsAcct()
            : acctNo.Contains("NATIONAL")
                ? new NationalSavingsAcct()
                : throw new ArgumentException("Invalid Account Number");
}
