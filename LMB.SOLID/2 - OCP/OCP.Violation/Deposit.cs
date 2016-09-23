namespace LMB.SOLID.OCP.Violation
{
    public class Deposit
    {
        public void DepositValue(decimal amount, string account, AccountType accountType)
        {
            if (accountType == AccountType.Checking)
            {
                // put the amount into checking account number...
            }

            if (accountType == AccountType.Savings)
            {
                // put the amount into savings account number...
            }
        }
    }
}
