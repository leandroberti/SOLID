using System;

namespace LMB.SOLID.OCP.Solution
{
    public class AtmMachineService
    {
        public static void AtmOperations()
        {
            while (true)
            {
                ShowMenu();

                var option = Console.ReadKey();
                Account account;

                switch (option.KeyChar)
                {
                    case '0':
                        return;
                    case '1':
                        Console.WriteLine();
                        Console.WriteLine();
                        Console.WriteLine("Checking Account Operation");
                        account = GetAccountData();
                        ReturnTransaction(account.DepositIntoCheckingAccount());
                        break;
                    case '2':
                        Console.WriteLine();
                        Console.WriteLine();
                        Console.WriteLine("Savings Account Operation");
                        account = GetAccountData();
                        ReturnTransaction(account.DepositIntoSavingsAccount());
                        break;
                    case '3':
                        Console.WriteLine();
                        Console.WriteLine();
                        Console.WriteLine("Investing Account Operation");
                        account = GetAccountData();
                        ReturnTransaction(account.DepositIntoInvestingAccount());
                        break;
                    default:
                        Console.WriteLine();
                        Console.WriteLine();
                        Console.WriteLine("This option is invalid!");
                        Console.ReadKey();
                        break;
                }
            }
        }

        private static void ShowMenu()
        {
            Console.Clear();
            Console.WriteLine("SOLID OCP ATM Machine Service Sample");
            Console.WriteLine("------------------------------------");
            Console.WriteLine();
            Console.WriteLine("0 - Exit From ATM Service");
            Console.WriteLine("1 - Deposit into Checking Account");
            Console.WriteLine("2 - Deposit into Savings Account");
            Console.WriteLine("3 - Deposit into Investing Account");
            Console.WriteLine();
            Console.Write("Please, choose one option: ");
        }

        private static Account GetAccountData()
        {
            var account = new Account();
            decimal amount;

            Console.WriteLine("..............................");
            Console.WriteLine();

            Console.Write("Enter Account Number: ");
            account.Number = Console.ReadLine();

            Console.Write("Enter Amount: ");

            while (!decimal.TryParse(Console.ReadLine(), out amount))
            {
                Console.WriteLine();
                Console.WriteLine("Amount is invalid!");
                Console.WriteLine();
                Console.Write("Enter Amount: ");
            };

            account.Amount = amount;

            return account;
        }

        private static void ReturnTransaction(string transaction)
        {
            Console.WriteLine();
            Console.WriteLine("Success! Transaction Number: " + transaction);
            Console.ReadKey();
        }
    }
}