namespace FactorySample.Interfaces;
internal interface IAccountFactory
{
    ISavingsAccount GetSavingsAccount(string acctNo);
}
