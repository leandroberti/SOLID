namespace LMB.SOLID.DIP.Solution.Contracts
{
    public interface ICustomerRepository
    {
        void Add(ICustomer customer);
        ICustomer GetById(int id);
        ICustomer GetByName(string name);
        ICustomer GetBySsn(string ssn);
        int CustomerCount();
        string GetAllIds();
        string GetAllNames();
        string GetAllSsn();
    }
}