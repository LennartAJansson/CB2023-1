using AbstractFactory.Accounts;

namespace AbstractFactory.Factories;
using AbstractFactory.Interfaces;


public class CitiBankFactory : IAbstractBankFactory
{
    public ILoanAccount CreateLoanAccount() => new CitiLoanAccount();

    public ISavingsAccount CreateSavingsAccount() => new CitiSavingsAccount();
}
