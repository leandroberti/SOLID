using System.Collections.Generic;

namespace LMB.SOLID.SRP.Solution
{
    public static class CustomerInMemoryData
    {
        public static List<Customer> CustomerData { get; }

        static CustomerInMemoryData()
        {
            CustomerData = new List<Customer>();
        }
    }
}