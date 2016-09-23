using LMB.SOLID.DIP.Solution.Contracts;

namespace LMB.SOLID.DIP.Solution
{
    public class SsnServices : ISsnServices
    {
        public bool IsValid(string ssn)
        {
            return ssn.Length == 9;
        }
    }
}