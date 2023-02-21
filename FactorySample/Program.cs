using System;

namespace FactorySample
{
    internal class Program
    {
        private static void Main(string[] args)
        {
            ICreditUnionFactory factory = new SavingsAcctFactory() as ICreditUnionFactory;

            SavingsAccount citiAcct = factory.GetSavingsAccount("CITI-321");
            SavingsAccount nationalAcct = factory.GetSavingsAccount("NATIONAL-987");

            Console.WriteLine($"My citi balance is ${citiAcct.Balance}" +
                $" and national balance is ${nationalAcct.Balance}");

            Console.WriteLine("Press any key to continue...");
            Console.ReadKey(true);
        }
    }

    // Abstraction: Product
    //This is an abstract base class and SavingsAccountBase would be more suitable
    public abstract class SavingsAccount
    {
        public decimal Balance { get; set; }
    }

    // Concretion: Product
    public class CitiSavingsAcct : SavingsAccount
    {
        public CitiSavingsAcct() => Balance = 5000;
    }

    // Concretion: Product
    public class NationalSavingsAcct : SavingsAccount
    {
        public NationalSavingsAcct() => Balance = 2000;
    }

    // Abstraction: Creator
    internal interface ICreditUnionFactory
    {
        SavingsAccount GetSavingsAccount(string acctNo);
    }

    // Concretion: Creators
    public class SavingsAcctFactory : ICreditUnionFactory
    {
        public SavingsAccount GetSavingsAccount(string acctNo)
        {
            if (acctNo.Contains("CITI")) { return new CitiSavingsAcct(); }
            else
            if (acctNo.Contains("NATIONAL")) { return new NationalSavingsAcct(); }
            else
            {
                throw new ArgumentException("Invalid Account Number");
            }
        }
    }

}
