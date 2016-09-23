using System;
using LMB.SOLID.DIP.Solution.Contracts;

namespace LMB.SOLID.DIP.Solution
{
    public class Customer : ICustomer
    {
        private readonly ISsnServices _ssnServices;
        private readonly IEmailServices _emailServices;

        public int Id { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
        public string Ssn { get; set; }
        public DateTime InsertDate { get; set; }

        public Customer(ISsnServices ssnServices, IEmailServices emailServices)
        {
            _ssnServices = ssnServices;
            _emailServices = emailServices;
        }

        public bool IsValid()
        {
            return _emailServices.IsValid(Email) && _ssnServices.IsValid(Ssn);
        }
    }
}
