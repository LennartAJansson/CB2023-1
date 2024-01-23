namespace AbstractFactory.Interfaces
{
    // Abstract Factory
    public interface IAbstractBankFactory
    {
        public ISavingsAccount CreateSavingsAccount();
        public ILoanAccount CreateLoanAccount();
    }
}
