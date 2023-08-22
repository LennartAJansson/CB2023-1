namespace AbstractFactory.Providers;

using AbstractFactory.Factories;
using AbstractFactory.Interfaces;

public class BankFactoryProvider
{
    public static ICreditUnionFactory? GetCreditUnionFactory(string accountNo)
    {
        if (accountNo.Contains("CITI")) 
        {
            return new CitiCreditUnionFactory();
        }
        else if (accountNo.Contains("NATIONAL"))
        {
            return new NationalCreditUnionFactory(); 
        }
        else
        {
            return null; 
        }
    }
}
