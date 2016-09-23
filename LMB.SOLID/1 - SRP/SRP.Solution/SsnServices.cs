namespace LMB.SOLID.SRP.Solution
{
    public static class SsnServices
    {
        public static bool IsValid(string ssn)
        {
            return ssn.Length == 9;
        }
    }
}