using AbstractFactory.Interfaces;
using AbstractFactory.Providers;

List<string> accntNumbers = ["CITI-456", "NATIONAL-987", "CHASE-222"];

foreach (string accntNumber in accntNumbers)
{
  IAbstractBankFactory? bankFactory = BankFactoryProvider.GetBankFactory(accntNumber);
  if (bankFactory is null)
  {
    Console.WriteLine("Sorry. This bank with account number ' {0} ' is invalid.", accntNumber);
  }
  else
  {
    ILoanAccount loan = bankFactory.CreateLoanAccount();
    ISavingsAccount savings = bankFactory.CreateSavingsAccount();
    Console.WriteLine("Account Information:");
    Console.WriteLine("Account Number: {0}", accntNumber);
    Console.WriteLine("Loan Account: {0}", loan.GetType().Name);
    Console.WriteLine("Savings Account: {0}", savings.GetType().Name);
  }
    Console.WriteLine();
}
