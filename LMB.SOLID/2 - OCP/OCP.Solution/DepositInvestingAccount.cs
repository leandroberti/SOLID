namespace LMB.SOLID.OCP.Solution
{
    public static class DepositInvestingAccount
    {
        public static string DepositIntoInvestingAccount(this Account investingAccount)
        {
            // Business rules for Investing Account Deposit
            return investingAccount.GetTransactionNumber();
        }
    }
}