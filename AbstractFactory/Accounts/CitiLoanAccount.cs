namespace AbstractFactory.Accounts;

using AbstractFactory.Interfaces;

public class CitiLoanAccount : ILoanAccount
{
    public CitiLoanAccount() => Console.WriteLine("Returned Citi Loan Account");
}
