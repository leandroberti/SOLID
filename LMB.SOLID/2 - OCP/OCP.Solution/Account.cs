using System;
using System.Linq;

namespace LMB.SOLID.OCP.Solution
{
    public class Account
    {
        public string Number { get; set; }
        public decimal Amount { get; set; }
        public string TransactionNumber { get; set; }

        public string GetTransactionNumber()
        {
            const string chars = "ABCDEFGHIJKLMNOPQRSTUVWXYZ0123456789";
            var random = new Random();

            TransactionNumber = new string(Enumerable.Repeat(chars, 15)
                .Select(s => s[random.Next(s.Length)]).ToArray());

            return TransactionNumber;
        }
    }
}
