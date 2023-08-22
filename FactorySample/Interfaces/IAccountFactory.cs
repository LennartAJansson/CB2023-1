namespace FactorySample.Interfaces;

using FactorySample.Accounts;

internal interface IAccountFactory
{
    SavingsAccount GetSavingsAccount(string acctNo);
}
