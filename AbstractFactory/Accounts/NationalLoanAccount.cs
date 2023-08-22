namespace AbstractFactory.Accounts;

using AbstractFactory.Interfaces;

public class NationalLoanAccount : ILoanAccount
{
    public NationalLoanAccount() => Console.WriteLine("Returned National Loan Account");
}
