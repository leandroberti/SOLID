using System;

namespace LMB.SOLID.SRP.Solution
{

    public class Customer
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
        public string Ssn { get; set; }
        public DateTime InsertDate { get; set; }

        public bool IsValid()
        {
            return EmailServices.IsValid(Email) && SsnServices.IsValid(Ssn);
        }
    }
}
