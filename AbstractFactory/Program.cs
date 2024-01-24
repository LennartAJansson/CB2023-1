using AbstractFactory.Interfaces;
using AbstractFactory.Providers;

/*
Svenska koder på bankkort:
Först siffran står för branschtillhörighet och brukar kallas för MII (Major Industry Identifier). 
Har du 4:a som första siffra är det ett VISA kort och 5:a står för Mastercard kort.
Första 6 siffrorna bildar BIN (Bank Identifier Number) och det berättar vilken bank eller finansiellt institut som utfärdar kortet.
Ex: 
406461 är ett kort utfärdat av SEB.
539040 är ett kort utfärdat av Nordea.

Nummer 7-15 bildar kontonumret som hjälper banken hitta kortinnehavarens konto. 
På detta sättet kan de säkerställa att du har tillräckligt med pengar på kortet för transaktionen.
Sista siffran är endast för att kontrollera att allt blivit rätt. Det räknas ut med hjälp av de övriga siffrorna i kortnumret genom en viss teknik.
*/

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
