namespace AbstractFactory.Interfaces
{
    // Abstract Factory
    public interface ICreditUnionFactory
    {
        public ISavingsAccount CreateSavingsAccount();
        public ILoanAccount CreateLoanAccount();
    }
}
