using LMB.SOLID.ISP.Solution.Contracts;

namespace LMB.SOLID.ISP.Solution
{
    public class CustomerRegistration : ICustomer
    {
        public string ValidateData()
        {
            return "Validating Customer Data...";

        }

        public string SaveData()
        {
            return "Saving Customer Data into Database...";
        }

        public string SendEmail()
        {
            return "Sending Customer Email...";
        }
    }
}