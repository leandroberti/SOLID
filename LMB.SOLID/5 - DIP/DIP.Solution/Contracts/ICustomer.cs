using System;

namespace LMB.SOLID.DIP.Solution.Contracts
{
    public interface ICustomer
    {
        int Id { get; set; }
        string Name { get; set; }
        string Email { get; set; }
        string Ssn { get; set; }
        DateTime InsertDate { get; set; }

        bool IsValid();
    }
}