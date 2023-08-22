using AbstractFactory.Interfaces;
using AbstractFactory.Providers;

List<string> accntNumbers = new() { "CITI-456", "NATIONAL-987", "CHASE-222" };

foreach (string accntNumber in accntNumbers)
{
    ICreditUnionFactory? anAbstractFactory = BankFactoryProvider.GetCreditUnionFactory(accntNumber);
    if (anAbstractFactory is null)
    {
        Console.WriteLine("Sorry. This bank w/ account number ' {0} ' is invalid.", accntNumber);
    }
    else
    {
        ILoanAccount loan = anAbstractFactory.CreateLoanAccount();
        ISavingsAccount savings = anAbstractFactory.CreateSavingsAccount();
    }
}
