namespace FactorySample.Factories;

using FactorySample.Accounts;
using FactorySample.Interfaces;

public class AccountFactory : IAccountFactory
{
    public SavingsAccount GetSavingsAccount(string acctNo)
    {
        if (acctNo.Contains("CITI")) 
        { 
            return new CitiSavingsAcct(); 
        }
        else
        {
            return acctNo.Contains("NATIONAL") ? 
                new NationalSavingsAcct() : 
                throw new ArgumentException("Invalid Account Number");
        }
    }
}
