namespace LMB.SOLID.OCP.Solution
{
    public static class DepositSavingsAccount
    {
        public static string DepositIntoSavingsAccount(this Account savingsAccount)
        {
            // Business rules for Savings Account Deposit
            return savingsAccount.GetTransactionNumber();
        }
    }
}