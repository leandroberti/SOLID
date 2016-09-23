namespace LMB.SOLID.OCP.Solution
{
    public static class DepositCheckingAccount
    {
        public static string DepositIntoCheckingAccount(this Account checkingAccount)
        {
            // Business rules for Checking Account Deposit
            return checkingAccount.GetTransactionNumber();
        }
    }
}