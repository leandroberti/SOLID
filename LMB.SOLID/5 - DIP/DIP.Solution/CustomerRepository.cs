using System;
using System.Linq;
using LMB.SOLID.DIP.Solution.Contracts;

namespace LMB.SOLID.DIP.Solution
{
    public class CustomerRepository : ICustomerRepository
    {
        public void Add(ICustomer customer)
        {
            CustomerInMemoryData.CustomerData.Add((Customer)customer);
        }

        public ICustomer GetById(int id)
        {
            return CustomerInMemoryData.CustomerData.Find(c => c.Id == id);
        }

        public ICustomer GetByName(string name)
        {
            return CustomerInMemoryData.CustomerData.Find(c => c.Name.Equals(name, StringComparison.InvariantCultureIgnoreCase));
        }

        public ICustomer GetBySsn(string ssn)
        {
            return CustomerInMemoryData.CustomerData.Find(c => c.Name.Equals(ssn, StringComparison.InvariantCultureIgnoreCase));
        }

        public int CustomerCount()
        {
            return CustomerInMemoryData.CustomerData.Count;
        }

        public string GetAllIds()
        {
            return string.Join(" | ", CustomerInMemoryData.CustomerData.Select(c => c.Id));
        }

        public string GetAllNames()
        {
            return string.Join(" | ", CustomerInMemoryData.CustomerData.Select(c => c.Name));
        }

        public string GetAllSsn()
        {
            return string.Join(" | ", CustomerInMemoryData.CustomerData.Select(c => c.Ssn));
        }
    }
}