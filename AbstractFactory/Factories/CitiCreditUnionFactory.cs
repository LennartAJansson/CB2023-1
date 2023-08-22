using AbstractFactory.Accounts;

namespace AbstractFactory.Factories;
using AbstractFactory.Interfaces;


public class CitiCreditUnionFactory : ICreditUnionFactory
{
    public ILoanAccount CreateLoanAccount() => new CitiLoanAccount();

    public ISavingsAccount CreateSavingsAccount() => new CitiSavingsAccount();
}
