using AbstractFactory.Accounts;

namespace AbstractFactory.Factories;

using AbstractFactory.Interfaces;

public class NationalBankFactory : IAbstractBankFactory
{
    public ILoanAccount CreateLoanAccount() => new NationalLoanAccount();

    public ISavingsAccount CreateSavingsAccount() => new NationalSavingsAccount();
}
