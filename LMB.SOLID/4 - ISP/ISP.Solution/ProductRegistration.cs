using LMB.SOLID.ISP.Solution.Contracts;

namespace LMB.SOLID.ISP.Solution
{
    public class ProductRegistration : IProduct
    {
        public string ValidateData()
        {
            return "Validating Product Data...";

        }

        public string SaveData()
        {
            return "Saving Product Data into Database...";
        }
    }
}