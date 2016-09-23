using System;
using System.Linq;

namespace LMB.SOLID.SRP.Solution
{
    public class CustomerRepository
    {
        public void Add(Customer customer)
        {
            CustomerInMemoryData.CustomerData.Add(customer);
        }

        public Customer GetById(int id)
        {
            return CustomerInMemoryData.CustomerData.Find(c => c.Id == id);
        }

        public Customer GetByName(string name)
        {
            return CustomerInMemoryData.CustomerData.Find(c => c.Name.Equals(name, StringComparison.InvariantCultureIgnoreCase));
        }

        public Customer GetBySsn(string ssn)
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